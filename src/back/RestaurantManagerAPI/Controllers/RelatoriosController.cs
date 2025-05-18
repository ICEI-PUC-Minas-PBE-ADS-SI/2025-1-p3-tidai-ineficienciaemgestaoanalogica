using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

[ApiController]
[Route("api/[controller]")]
public class RelatoriosController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly PedidoService _pedidoService;

    public RelatoriosController(AppDbContext context, PedidoService pedidoService)
    {
        _context = context;
        _pedidoService = pedidoService;
    }
    //[Authorize(Policy = "Gerente")]
    [HttpGet("periodo")]
    public async Task<IActionResult> RelatorioPorPeriodo(DateTime inicio, DateTime fim)
    {
        var relatorios = await _context.RelatorioPedidos
            .Where(r => r.DataHoraFim.Date >= inicio && r.DataHoraFim.Date <= fim)
            .Include(r => r.Itens)
            .Select(r => _pedidoService.MapearRelatorioPedido(r))
            .ToListAsync();

        var agrupadosPorDia = relatorios
            .GroupBy(r => r.DataHoraFim.Date)
            .Select(g => new RelatorioPeriodo
            {
                Dia = g.Key,
                PrecoFinal = g.Sum(r => r.PrecoFinal)
            })
            .OrderBy(r => r.Dia)
            .ToList();
        
        return Ok(agrupadosPorDia);
    }

    //[Authorize(Policy = "Gerente")]
    [HttpGet("dia")]
    public async Task<IActionResult> RelatorioPorDia(DateTime dia)
    {
        var relatorio = await _context.RelatorioPedidos
            .Where(r => r.DataHoraFim.Date == dia.Date)
            .Include(r => r.Itens)
            .Select(r => _pedidoService.MapearRelatorioPedido(r))
            .ToListAsync();
        
        return Ok(relatorio);
    }
     //[Authorize(Policy = "Gerente")]
    [HttpGet("{id}")]
    public async Task<IActionResult> RelatorioPorId(int id)
    {
        var relatorio = await _context.RelatorioPedidos
            .Where(r => r.Id == id)
            .Include(r => r.Itens)
            .FirstOrDefaultAsync();

        if (relatorio == null)
        {
            return NotFound();
        }
        var relatorioDTO = _pedidoService.MapearRelatorioPedido(relatorio);
        
        return Ok(relatorioDTO);
    }
}