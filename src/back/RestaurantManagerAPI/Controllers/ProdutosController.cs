using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ProdutoService _produtoService;

    public ProdutosController(AppDbContext context, ProdutoService produtoService)
    {
        _context = context;
        _produtoService = produtoService;
    }

    [HttpGet("categoria/{categoriaId}")]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutosPorCategoria(int categoriaId)
    {
        var produtos = await _context.Produtos
            .Where(p => p.CategoriaId == categoriaId)
            .ToListAsync();

        var response = new List<ProdutoDTO>();
        foreach (var p in produtos)
        {
            var dto = await _produtoService.MapearProdutoResponse(p.Id);

            if(dto != null ) response.Add(dto);
        }

        return Ok(response);
    }

    [HttpGet("pedido/{pedidoId}")]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutosPorPedido(int pedidoId)
    {
        var produtos = await _context.ItensPedido
            .Where(i => i.PedidoId == pedidoId)
            .Include(i => i.Produto)
            .Select(i => i.Produto)
            .Distinct()
            .ToListAsync();

        if (produtos == null)
            return NotFound();
        
        var response = new List<ProdutoDTO>();
        foreach (var p in produtos)
        {
            if (p == null) continue;
            var dto = await _produtoService.MapearProdutoResponse(p.Id);

            if(dto != null ) response.Add(dto);
        }

        return Ok(response); 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProdutoDTO>> GetProduto(int id)
    {
        var produto = await _produtoService.MapearProdutoResponse(id);

        if (produto == null)
            return NotFound();

        return Ok(produto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduto(int id, AtualizarProdutoDTO dto)
    {
        if (!id.Equals(dto.Id)) return BadRequest();

        var produto = await _produtoService.AtualizarProdutoAsync(dto);

        if (produto == null)
            return NotFound();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
            return NotFound();

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> PostProduto(CriarProdutoDTO dto)
    {
        var produto = await _produtoService.CriarProdutoAsync(dto);

        if (produto == null)
            return BadRequest();

        return Ok();
    }

    [HttpPost("upload-imagem")]
    public async Task<IActionResult> UploadImagem(IFormFile arquivo, [FromForm] string? caminhoAntigo)
    {
        if(arquivo == null || arquivo.Length == 0)
            return BadRequest("Arquivo inválido");
        
        var nomeArquivo = Guid.NewGuid() + Path.GetExtension(arquivo.FileName);
        var diretorioDestino = Path.Combine("wwwroot", "uploads", "produtos");
        Directory.CreateDirectory(diretorioDestino);

        var caminho = Path.Combine(Directory.GetCurrentDirectory(), diretorioDestino , nomeArquivo);

        using (var stream = new FileStream(caminho, FileMode.Create))
        {
            await arquivo.CopyToAsync(stream);
        }

        if (!string.IsNullOrWhiteSpace(caminhoAntigo))
        {
            var caminhoAntigoAbsoluto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", caminhoAntigo.TrimStart('/'));
            if (System.IO.File.Exists(caminhoAntigoAbsoluto))
            {
                System.IO.File.Delete(caminhoAntigoAbsoluto);
            }
        }

        var caminhoRelativo = $"/uploads/produtos/{nomeArquivo}";
        return Ok(new { caminho = caminhoRelativo });
    }
}