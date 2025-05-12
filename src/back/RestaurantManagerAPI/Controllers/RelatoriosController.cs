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
    [HttpGet("relatorio/periodo")]
    public async Task<IActionResult> RelatorioPorPeriodo(DateTime inicio, DateTime fim)
    {
        var relatorios = await _context.RelatorioPedidos
            .Where(r => r.DataHoraFim >= inicio && r.DataHoraFim <= fim)
            .Select(r => _pedidoService.MapearRelatorioPedido(r))
            .ToListAsync();
        return Ok(relatorios);
    }

    //[Authorize(Policy = "Gerente")]
    [HttpGet("relatorio/dia")]
    public async Task<IActionResult> RelatorioPorDia(DateTime dia)
    {
        var relatorio = await _context.RelatorioPedidos
            .Where(r => r.DataHoraFim.Date == dia.Date)
            .Select(r => _pedidoService.MapearRelatorioPedido(r))
            .ToListAsync();
        return Ok(relatorio);
    }
}