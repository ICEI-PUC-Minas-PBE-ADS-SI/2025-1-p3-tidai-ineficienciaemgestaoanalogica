using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    protected readonly AppDbContext _context;

    public CategoriasController(AppDbContext context)
    {
        _context = context;
    }

    //[Authorize(Policy = "Gerente")]
    [HttpGet]
    public async Task<ActionResult<List<CategoriaDTO>>> GetAll() 
    {
        var categorias = await _context.Categorias
            .Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Nome = c.Nome
            })
            .ToListAsync();
        if(categorias == null) return NotFound();
        return Ok(categorias);
    }

    //[Authorize(Policy = "Gerente")]
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoriaDTO>> Get(int id)
    {
        var categoria = await _context.Categorias
                        .Where(c => c.Id == id)
                        .Select(c => new CategoriaDTO
                        {
                            Id = c.Id,
                            Nome = c.Nome,
                        })
                        .ToListAsync();
        if (categoria == null) return NotFound();
        return Ok(categoria);
    }

    //[Authorize(Policy = "Gerente")]
    [HttpPost]
    public async Task<IActionResult> Post(CategoriaDTOInput categoria)
    {
        _context.Categorias.Add(new Categoria
        {
            Nome = categoria.Nome
        });
        await _context.SaveChangesAsync();
        return Ok();
    }

    //[Authorize(Policy = "Gerente")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, CategoriaDTO categoria)
    {
        if(!id.Equals(categoria.Id))
            return BadRequest();

        var categoriaOriginal = await _context.Categorias.Where(c => c.Id == categoria.Id).FirstOrDefaultAsync();
        if (categoriaOriginal == null)
            return NotFound();

        categoriaOriginal.Nome = categoria.Nome;
        _context.Categorias.Update(categoriaOriginal);
        await _context.SaveChangesAsync();
        return Ok();
    }

    //[Authorize(Policy = "Gerente")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var categoria = await _context.Categorias.Where(c => c.Id == id).FirstOrDefaultAsync();
        if (categoria == null) return NotFound();

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}