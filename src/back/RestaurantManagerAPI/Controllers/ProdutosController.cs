using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
public class ProdutosController : Controller
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
        
        var response = new List<ProdutoDTO>();
        foreach (var p in produtos)
        {
            var dto = await _produtoService.MapearProdutoResponse(p.Id);

            if(dto != null ) response.Add(dto);
        }

        return Ok(response); 
    }

    [HttpPost("upload-imagem")]
    public async Task<IActionResult> UploadImagem(IFormFile arquivo)
    {
        if(arquivo == null || arquivo.Length == 0)
            return BadRequest("Arquivo inválido");
        
        var nomeArquivo = Guid.NewGuid() + Path.GetExtension(arquivo.FileName);

        var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "produtos", nomeArquivo);

        Directory.CreateDirectory(Path.GetDirectoryName(caminho)!);

        using (var stream = new FileStream(caminho, FileMode.Create))
        {
            await arquivo.CopyToAsync(stream);
        }

        var caminhoRelativo = $"/uploads/produtos/{nomeArquivo}";

        return Ok(new { caminho = caminhoRelativo });
    }
}