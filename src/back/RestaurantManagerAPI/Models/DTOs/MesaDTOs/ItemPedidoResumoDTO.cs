public class ItemPedidoResumoDTO
{
    public string NomeProduto { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public List<string> ExtrasSelecionados { get; set; } = new();
}