using System.ComponentModel.DataAnnotations;

public class Categoria
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    public ICollection<Produto>? Produtos { get; set; }
}