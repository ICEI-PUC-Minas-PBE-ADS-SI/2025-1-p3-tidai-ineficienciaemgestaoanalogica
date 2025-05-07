using System.ComponentModel.DataAnnotations;
public class Funcionario
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Usuario { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string Senha { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Tipo { get; set; } = string.Empty;

    public ICollection<Pedido>? Pedidos { get; set; }
}
