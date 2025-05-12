public class ItemRelatorioPedidoDTO
{
    public string NomeProduto { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public List<string> Extras { get; set; } = new();
}