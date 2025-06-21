using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ItemPedido
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PedidoId { get; set; }
    [ForeignKey("PedidoId")]
    public Pedido? Pedido { get; set; }

    [Required]
    public int ProdutoId { get; set; }

    [ForeignKey("ProdutoId")]
    public Produto? Produto { get; set; }

    public ICollection<ExtraSelecionado>? ExtrasSelecionados { get; set; }

    [Required]
    public int Quantidade { get; set; } = 1;

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecoUnitario { get; set; }
}
