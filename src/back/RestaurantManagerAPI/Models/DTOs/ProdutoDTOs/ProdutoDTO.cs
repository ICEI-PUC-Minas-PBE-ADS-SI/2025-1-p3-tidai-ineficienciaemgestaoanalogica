public class ProdutoDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public string Foto { get; set; } = string.Empty;
    public int CategoriaId { get; set; }
    public List<ExtraDTO> Extras { get; set; } = new List<ExtraDTO>();
}