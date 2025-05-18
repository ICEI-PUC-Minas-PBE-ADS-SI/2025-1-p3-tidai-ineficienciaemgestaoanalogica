public class CriarProdutoDTO
{
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public string Foto { get; set; } = string.Empty;
    public int CategoriaId { get; set; }
    public List<ExtraInputDTO>? Extras { get; set; }
}