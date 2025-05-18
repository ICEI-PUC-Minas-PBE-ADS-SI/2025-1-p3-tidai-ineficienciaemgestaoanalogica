public class CriarPedidoDTO
{
    public int MesaId { get; set; }
    public int FuncionarioId { get; set; }
    public string Observacao { get; set; }  = "";
    public List<ItemPedidoInputDTO> ItensPedido { get; set; } = new ();
}