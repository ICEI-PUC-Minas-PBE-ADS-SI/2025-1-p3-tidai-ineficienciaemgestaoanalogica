public class RelatorioPedidoDTO
{
    public string NomeMesa { get; set; } = string.Empty;
    public string NomeFuncionario { get; set; } = string.Empty;
    public DateTime DataHoraInicio { get; set;}
    public DateTime DataHoraFim { get; set; }
    public decimal PrecoFinal { get; set; }
    public List<ItemRelatorioPedidoDTO> Itens { get; set;} = new();
}