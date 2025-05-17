using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class FuncionariosController : ControllerBase
{
    private readonly AppDbContext _context;

    public FuncionariosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<FuncionarioDTO>>> GetFuncionarios()
    {
        var funcionarios = await _context.Funcionarios
            .Select(f => new FuncionarioDTO
            {
                Id = f.Id,
                Nome = f.Nome,
                Usuario = f.Usuario,
                Tipo = f.Tipo
            }).ToListAsync();

        return Ok(funcionarios);
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> RegistrarFuncionario([FromBody] Funcionario funcionario)
    {
        funcionario.Senha = BCrypt.Net.BCrypt.HashPassword(funcionario.Senha);
        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();
        return Ok("Funcionario registrado.");
    }

    [HttpPost("login")]
    public async Task<ActionResult<FuncionarioLogadoDTO>> LoginFuncionario([FromBody] LoginDTO dto)
    {
        var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(f => f.Usuario == dto.Usuario);

        if(funcionario == null || !BCrypt.Net.BCrypt.Verify(dto.Senha, funcionario.Senha))
            return Unauthorized("Usuário ou senha inválidos.");

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, funcionario.Nome),
            new Claim(ClaimTypes.NameIdentifier, funcionario.Id.ToString()),
            new Claim(ClaimTypes.Role, funcionario.Tipo)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        var funcionarioLogado = new FuncionarioLogadoDTO
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            Tipo = funcionario.Tipo
        };

        return Ok();
    }

    [HttpGet("logado")]
    public IActionResult GetFuncionarioLogado()
    {
        if (User?.Identity?.IsAuthenticated != true)
            return Unauthorized();

        var funcionario = new FuncionarioLogadoDTO
        {
            Id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value),
            Nome = User.Identity.Name!,
            Tipo = User.FindFirst(ClaimTypes.Role)!.Value
        };

        return Ok(funcionario);
    }
}