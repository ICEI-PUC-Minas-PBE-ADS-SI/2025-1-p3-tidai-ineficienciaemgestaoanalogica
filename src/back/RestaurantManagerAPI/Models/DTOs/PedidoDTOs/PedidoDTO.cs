public class PedidoDTO
{
    public int Id { get; set; }
    public int MesaId { get; set; }
    public int FuncionarioId { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public DateTime? DataHoraFim { get; set; }
    public decimal PrecoFinal { get; set; }
    public string Observacao { get; set; } = "";
    public List<ItemPedidoDTO> ItensPedido { get; set; } = new();
}