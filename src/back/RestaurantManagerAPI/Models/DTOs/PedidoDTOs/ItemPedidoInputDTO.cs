public class ItemPedidoInputDTO
{
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public List<int> ExtrasSelecionados { get; set; } = new();
}
