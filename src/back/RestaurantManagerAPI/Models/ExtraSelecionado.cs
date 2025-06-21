using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ExtraSelecionado
{
    [Required]
    public int ItemPedidoId { get; set; }
    [Required]
    public int ExtraId { get; set;}

    [ForeignKey("ExtraId")]
    public Extra? Extra { get; set; }

    [ForeignKey("ItemPedidoId")]
    public ItemPedido? ItemPedido { get; set; }
}
