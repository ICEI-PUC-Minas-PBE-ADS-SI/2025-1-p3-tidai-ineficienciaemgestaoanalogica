using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pedido
{
    [Key]
    public int Id { get; set; }

    public int MesaId { get; set; }

    [ForeignKey("MesaId")]
    public Mesa? Mesa { get; set; }

    public int FuncionarioId { get; set; }

    [ForeignKey("FuncionarioId")]
    public Funcionario? Funcionario { get; set; }

    [Required]
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraAtualizacao { get; set; }
    public DateTime? DataHoraFim { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecoFinal { get; set; }

    [StringLength(255)]
    public string Observacao { get; set; } = "";

    public ICollection<ItemPedido>? ItensPedido { get; set; }
}
