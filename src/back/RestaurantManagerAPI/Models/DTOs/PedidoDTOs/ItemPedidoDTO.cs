public class ItemPedidoDTO
{
    public ProdutoDTO Produto { get; set; } = new();
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public List<int> ExtrasSelecionados { get; set;} = new();
}