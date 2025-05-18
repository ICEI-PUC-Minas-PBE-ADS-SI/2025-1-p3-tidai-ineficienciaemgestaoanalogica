using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ExtraSelecionado
{
    [Required]
    public int ProdutoId { get; set; }
    [Required]
    public int PedidoId { get; set; }
    [Required]
    public int ExtraId { get; set;}


    [ForeignKey("ExtraId")]
    public Extra? Extra { get; set; }
    public ItemPedido? ItemPedido { get; set; }

}