public class MesaComPedidoAbertoDTO 
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Observacao { get; set; } = string.Empty;
    public List<ItemPedidoResumoDTO> ItensPedido { get; set; } = new();
}