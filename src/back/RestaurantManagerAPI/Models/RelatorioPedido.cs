using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RelatorioPedido
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime DataHoraInicio { get; set;}
    [Required]
    public DateTime DataHoraFim { get; set;}

    [StringLength(100)]
    public string? NomeMesa { get; set; }
    [StringLength(100)]
    public string? NomeFuncionario { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecoFinal { get; set; }

    public List<ItemRelatorioPedido>? Itens { get; set; }
}

public class ItemRelatorioPedido
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int RelatorioPedidoId { get; set; }
    [ForeignKey("RelatorioPedidoId")]
    public RelatorioPedido? RelatorioPedido { get; set; }

    [Required]
    [StringLength(100)]
    public string NomeProduto { get; set; } = string.Empty;
    [Required]
    public int Quantidade { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecoUnitario { get; set; }

    public List<string> ExtrasSelecionados { get; set; } = new();
}