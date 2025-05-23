using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly PedidoService _pedidoService;
    private readonly IHubContext<PedidoHub> _hubContext;

    public PedidosController(AppDbContext context, PedidoService pedidoService, IHubContext<PedidoHub> hubContext)
    {
        _context = context;
        _pedidoService = pedidoService;
        _hubContext = hubContext;
    }

    //[Authorize(Policy = "Funcionario")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPedido(int id)
    {
        var response = await _pedidoService.MapearPedidoResponse(id); 
        return response == null ? NotFound() : Ok(response);
    }

    [HttpGet("pedidos-da-mesa/{mesaId}")]
    public async Task<ActionResult<PedidoDTO>> GetPedidoDaMesa(int mesaId)
    {
        var pedidoId = await _context.Pedidos
            .Where(p => p.MesaId == mesaId && p.DataHoraFim == null)
            .Select(p => p.Id)
            .FirstOrDefaultAsync();
        
        if(pedidoId == 0) return NotFound("Nenhum pedido aberto encontrado para a mesa");

        var pedido = await _pedidoService.MapearPedidoResponse(pedidoId);
        return Ok(pedido);
    }

    //[Authorize(Policy = "Funcionario")]
    [HttpPost]
    public async Task<IActionResult> CriarPedido(CriarPedidoDTO dto)
    {
        var pedido = await _pedidoService.CriarPedidoAsync(dto);
        var response = await _pedidoService.MapearPedidoResponse(pedido.Id);

        await _hubContext.Clients.All.SendAsync("ReceberAtualizacao");
        return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPedido(int id, AtualizarPedidoDTO dto)
    {
        if (id != dto.Id)
            return BadRequest("ID do pedido não confere com o ID da URL.");

        var pedidoAtualizado = await _pedidoService.AtualizarPedidoAsync(dto);
        if (pedidoAtualizado == null)
            return NotFound("Pedido não encontrado.");

        var response = await _pedidoService.MapearPedidoResponse(id);
        await _hubContext.Clients.All.SendAsync("ReceberAtualizacao");
        return Ok(response);
    }


    //[Authorize(Policy = "Funcionario")]
    [HttpPost("fechar/{id}")]
    public async Task<ActionResult<RelatorioPedidoDTO>> FecharPedido(int id)
    {
        var relatorio = await _pedidoService.FecharPedidoAsync(id);
        if(relatorio == null)
            return NotFound(new { mensagem = "Pedido nào encontrado" });

        await _hubContext.Clients.All.SendAsync("ReceberAtualizacao");
        return Ok(relatorio);
    }

    //[Authorize(Policy = "Funcionario")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> CancelarPedido(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);
        if(pedido == null)
            return NotFound();      
        if(pedido.DataHoraFim != null)
            return BadRequest();

        _context.Remove(pedido);
        await _context.SaveChangesAsync();
        await _hubContext.Clients.All.SendAsync("ReceberAtualizacao");
        return NoContent();
    }
}