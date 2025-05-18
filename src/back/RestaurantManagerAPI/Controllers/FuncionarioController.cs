using System.Security.Claims;
using System.Threading.Tasks;
using BCrypt.Net;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<FuncionarioDTO>> GetFuncionario(int id)
    {
        var funcionario = await _context.Funcionarios
            .Where(f => f.Id == id)
            .Select(f => new FuncionarioDTO
            {
                Id = f.Id,
                Nome = f.Nome,
                Usuario = f.Usuario,
                Tipo = f.Tipo
            }).FirstOrDefaultAsync();

        return Ok(funcionario);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarFuncionario(int id)
    {
        var funcionario = await _context.Funcionarios
            .Where(f => f.Id == id)
            .FirstOrDefaultAsync();

        if (funcionario == null)
            return NotFound();

        _context.Funcionarios.Remove(funcionario);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> RegistrarFuncionario([FromBody] RegistrarDTO dto)
    {
        var funcionario = new Funcionario
        {
            Nome = dto.Nome,
            Tipo = dto.Tipo,
            Usuario = dto.Usuario,
            Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha)
        };

        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();
        return Ok();
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

    [HttpPut("{id}")]
    public async Task<IActionResult> EditarFuncionario(int id, [FromBody] EditarDTO dto)
    {
        if (!id.Equals(dto.Id))
            return BadRequest();

        var funcionario = await _context.Funcionarios.Where(f => f.Id.Equals(dto.Id)).FirstOrDefaultAsync();

        if (funcionario == null)
            return NotFound();

        funcionario.Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha);
        funcionario.Usuario = dto.Usuario;
        funcionario.Nome = dto.Nome;
        funcionario.Tipo = dto.Tipo;

        _context.Funcionarios.Update(funcionario);
        await _context.SaveChangesAsync();
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