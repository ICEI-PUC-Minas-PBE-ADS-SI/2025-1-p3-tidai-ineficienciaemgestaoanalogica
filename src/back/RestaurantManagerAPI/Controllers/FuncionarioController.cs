using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
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

    [HttpPost("registrar")]
    public async Task<IActionResult> RegistrarFuncionario([FromBody] Funcionario funcionario)
    {
        funcionario.Senha = BCrypt.Net.BCrypt.HashPassword(funcionario.Senha);
        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();
        return Ok("Funcionario registrado.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginFuncionario([FromBody] Funcionario login)
    {
        var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(f => f.Usuario == login.Usuario);

        if(funcionario == null || !BCrypt.Net.BCrypt.Verify(login.Senha, funcionario.Senha))
            return Unauthorized("Usuário ou senha inválidos.");

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, funcionario.Nome),
            new Claim(ClaimTypes.Role, funcionario.Tipo)
        };

        var identity = new ClaimsIdentity(claims, "CookieAuth");
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("CookieAuth", principal);
        return Ok("Login ralizado");
    }

    [Authorize]
    [HttpGet("dados-logado")]
    public IActionResult GetFuncionarioLogado()
    {
        var nome = User.FindFirstValue(ClaimTypes.Name);

        return Ok(nome);
    }
}