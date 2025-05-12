using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
public class MesasController : Controller<Mesa>
{
    public MesasController(AppDbContext context) : base(context) {}

    [HttpGet("com-pedidos-abertos")]
    public async Task<ActionResult<IEnumerable<Mesa>>> GetMesasComPedidosAbertos()
    {
        var mesas = await _context.Mesas
            .Include(m => m.Pedidos.Where(p => p.DataHoraFim == null))
                .ThenInclude(p => p.ItensPedido)
                    .ThenInclude(i => i.Produto)
            .Where(m => m.Pedidos.Any(p => p.DataHoraFim == null))
            .OrderBy(m => m.Pedidos
                .Where(p => p.DataHoraFim == null)
                .Select(p => p.DataHoraInicio)
                .FirstOrDefault())
            .Select(m => new MesaComPedidoAbertoDTO {
                Id = m.Id,
                Nome = m.Nome,
                Observacao = m.Pedidos.Select(p => p.Observacao).FirstOrDefault(),
                ItensPedido = m.Pedidos
                    .Where(p => p.DataHoraFim == null)
                    .SelectMany(p => p.ItensPedido)
                    .Select(i => new ItemPedidoResumoDTO{
                        NomeProduto = i.Produto.Nome,
                        Quantidade = i.Quantidade,
                        ExtrasSelecionados = i.ExtrasSelecionados.Select(e => e.Extra.Nome).ToList()
                    }).ToList()
            }).ToListAsync();

        return Ok(mesas);
    }

    [HttpGet("sem-pedidos-abertos")]
    public async Task<ActionResult<IEnumerable<Mesa>>> GetMesasSemPedidosAbertos()
    {
        var mesas = await _context.Mesas
            .Include(m => m.Pedidos)
            .Where(m => m.Pedidos == null || !m.Pedidos.Any() || m.Pedidos.All(p => p.DataHoraFim != null))
            .Select(m => new MesaComPedidoAbertoDTO {
                Id = m.Id,
                Nome = m.Nome,
            })
            .ToListAsync();
        return Ok(mesas);
    }
}