using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public class ProdutoService
{
    private readonly AppDbContext _context;

    public ProdutoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Produto> CriarProdutoAsync(CriarProdutoDTO dto)
    {
        var produto = new Produto
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao ?? "",
            Preco = dto.Preco,
            Foto = dto.Foto,
            CategoriaId = dto.CategoriaId,
            Extras = dto.Extras!.Select(e => new Extra {
                Nome = e.Nome,
                PrecoAdicional = e.PrecoAdicional
            }).ToList()
        };

        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto?> AtualizarProdutoAsync(AtualizarProdutoDTO dto)
    {
        var produto = await _context.Produtos
            .Include(p => p.Extras)
            .FirstOrDefaultAsync(p => p.Id == dto.Id);

        if (produto == null) return null;

        produto.Nome = dto.Nome;
        produto.Descricao = dto.Descricao ?? produto.Descricao;
        produto.Preco = dto.Preco;
        produto.Foto = dto.Foto;
        produto.CategoriaId = dto.CategoriaId;

        _context.Extras.RemoveRange(produto.Extras!);

        produto.Extras = dto.Extras!.Select(e => new Extra{
            Nome = e.Nome,
            PrecoAdicional = e.PrecoAdicional
        }).ToList();

        await _context.SaveChangesAsync();
        return produto;
    }
    public async Task<ProdutoDTO?> MapearProdutoResponse(int id)
    {
        var produto = await _context.Produtos
            .Include(p => p.Extras)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (produto == null) return null;

        return new ProdutoDTO
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
            Foto = produto.Foto,
            CategoriaId = produto.CategoriaId,
            Extras = produto.Extras!.Select(e => new ExtraDTO{
                Id = e.Id,
                Nome = e.Nome,
                PrecoAdicional = e.PrecoAdicional
            }).ToList()
        };
    }
}