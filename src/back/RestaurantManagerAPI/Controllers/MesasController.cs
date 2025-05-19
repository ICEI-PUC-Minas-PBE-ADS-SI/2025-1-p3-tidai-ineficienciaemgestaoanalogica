using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class MesasController : ControllerBase
{
    private readonly AppDbContext _context;
    public MesasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("com-pedidos-abertos")]
    public async Task<ActionResult<IEnumerable<Mesa>>> GetMesasComPedidosAbertos()
    {
        var mesas = await _context.Mesas
            .Include(m => m.Pedidos!.Where(p => p.DataHoraFim == null))
                .ThenInclude(p => p.ItensPedido!)
                    .ThenInclude(i => i.Produto)
            .Where(m => m.Pedidos!.Any(p => p.DataHoraFim == null))
            .OrderBy(m => m.Pedidos!
                .Where(p => p.DataHoraFim == null)
                .Select(p => p.DataHoraInicio)
                .FirstOrDefault())
            .Select(m => new MesaComPedidoAbertoDTO {
                Id = m.Id,
                Nome = m.Nome,
                Observacao = m.Pedidos!
                        .Where(p => p.DataHoraFim == null)
                        .Select(p => p.Observacao)
                        .FirstOrDefault() ?? string.Empty,
                ItensPedido = m.Pedidos!
                    .Where(p => p.DataHoraFim == null)
                    .SelectMany(p => p.ItensPedido ?? new List<ItemPedido>())
                    .Select(i => new ItemPedidoResumoDTO{
                        NomeProduto = i.Produto != null ? i.Produto.Nome : string.Empty,
                        Quantidade = i.Quantidade,
                        ExtrasSelecionados = (i.ExtrasSelecionados != null ? i.ExtrasSelecionados
                                            .Where(e => e.Extra != null)
                                            .Select(e => e.Extra!.Nome)
                                            : new List<string>()).ToList()
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

    //[Authorize(Policy = "Gerente")]
    [HttpGet]
    public async Task<ActionResult<List<MesaDTO>>> GetMesas() 
    {
        var mesas = await _context.Mesas
            .Select(m => new MesaDTO
            {
                Id = m.Id,
                Nome = m.Nome
            })
            .ToListAsync();
        if(mesas == null) return NotFound();
        return Ok(mesas);
    }

    //[Authorize(Policy = "Gerente")]
    [HttpGet("{id}")]
    public async Task<ActionResult<MesaDTO>> Get(int id)
    {
        var mesa = await _context.Mesas
                        .Where(m => m.Id == id)
                        .Select(m => new MesaDTO
                        {
                            Id = m.Id,
                            Nome = m.Nome,
                        })
                        .ToListAsync();
        if (mesa == null) return NotFound();
        return Ok(mesa);
    }

    //[Authorize(Policy = "Gerente")]
    [HttpPost]
    public async Task<IActionResult> Post(MesaDTOInput mesa)
    {
        _context.Mesas.Add(new Mesa
        {
            Nome = mesa.Nome
        });
        await _context.SaveChangesAsync();
        return Ok();
    }

    //[Authorize(Policy = "Gerente")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, MesaDTO mesa)
    {
        if(!id.Equals(mesa.Id))
            return BadRequest();

        var mesaOriginal = await _context.Mesas.Where(m => m.Id == mesa.Id).FirstOrDefaultAsync();
        if (mesaOriginal == null)
            return NotFound();

        mesaOriginal.Nome = mesa.Nome;
        _context.Mesas.Update(mesaOriginal);
        await _context.SaveChangesAsync();
        return Ok();
    }

    //[Authorize(Policy = "Gerente")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var mesa = await _context.Mesas.Where(m => m.Id == id).FirstOrDefaultAsync();
        if (mesa == null) return NotFound();

        _context.Mesas.Remove(mesa);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}