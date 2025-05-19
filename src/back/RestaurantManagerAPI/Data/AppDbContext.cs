using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Extra> Extras { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Mesa> Mesas { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItemPedido> ItensPedido { get; set; }
    public DbSet<ExtraSelecionado> ExtrasSelecionados { get; set;} 
    public DbSet<RelatorioPedido> RelatorioPedidos { get; set; }
    public DbSet<ItemRelatorioPedido> ItensRelatorioPedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ItemPedido>().HasKey(ip => new { ip.ProdutoId, ip.PedidoId });
        modelBuilder.Entity<ExtraSelecionado>().HasKey(es => new { es.ProdutoId, es.PedidoId, es.ExtraId });
        modelBuilder.Entity<ExtraSelecionado>().HasOne(es => es.ItemPedido).WithMany(ip => ip.ExtrasSelecionados).HasForeignKey(es => new { es.ProdutoId, es.PedidoId });

        modelBuilder.Entity<Funcionario>().HasData(
            new Funcionario { Id = 1, Nome = "Administrador", Usuario = "admin", Senha = BCrypt.Net.BCrypt.HashPassword("admin"), Tipo = "Gerente" },
            new Funcionario { Id = 2, Nome = "João da Silva", Usuario = "joao", Senha = BCrypt.Net.BCrypt.HashPassword("senha123"), Tipo = "Funcionario" }
        );

        modelBuilder.Entity<Mesa>().HasData(
            new Mesa { Id = 1, Nome = "Mesa 01" },
            new Mesa { Id = 2, Nome = "Mesa 02" },
            new Mesa { Id = 3, Nome = "Mesa 03" },
            new Mesa { Id = 4, Nome = "Mesa 04" },
            new Mesa { Id = 5, Nome = "Mesa 05" }
        );

        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nome = "Pizzas" },
            new Categoria { Id = 2, Nome = "Bebidas" },
            new Categoria { Id = 3, Nome = "Sobremesas" },
            new Categoria { Id = 4, Nome = "Acompanhamentos" }
        );

        modelBuilder.Entity<Produto>().HasData(
            new Produto { Id = 1, Nome = "Pizza de Calabresa", CategoriaId = 1, Descricao = "Calabresa, molho de tomate, mussarela e cebola", Foto = "/uploads/produtos/pizza-calabresa.jpg", Preco = 23.40m },
            new Produto { Id = 2, Nome = "Pizza Marguerita", CategoriaId = 1, Descricao = "Mussarela, tomate, manjericão e molho de tomate", Foto = "/uploads/produtos/pizza-marguerita.jpg", Preco = 25.90m },
            new Produto { Id = 3, Nome = "Pizza Portuguesa", CategoriaId = 1, Descricao = "Presunto, mussarela, ovo, cebola, azeitona e molho de tomate", Foto = "/uploads/produtos/pizza-portuguesa.jpg", Preco = 28.50m },
            new Produto { Id = 4, Nome = "Pizza Chocolate com Morango", CategoriaId = 1, Descricao = "Chocolate ao leite, morangos frescos e leite condensado", Foto = "/uploads/produtos/pizza-choco-morango.jpg", Preco = 32.00m },
            
            new Produto { Id = 5, Nome = "Água com Gás", CategoriaId = 2, Descricao = "Garrafa de 500ml", Foto = "/uploads/produtos/agua-com-gas.jpg", Preco = 4.50m },
            new Produto { Id = 6, Nome = "Água sem Gás", CategoriaId = 2, Descricao = "Garrafa de 500ml", Foto = "/uploads/produtos/agua-sem-gas.jpg", Preco = 3.50m },
            new Produto { Id = 7, Nome = "Coca-Cola Lata", CategoriaId = 2, Descricao = "Lata 350ml", Foto = "/uploads/produtos/coca-cola-lata.jpg", Preco = 5.00m },
            new Produto { Id = 8, Nome = "Guaraná Lata", CategoriaId = 2, Descricao = "Lata 350ml", Foto = "/uploads/produtos/guarana-lata.jpg", Preco = 4.80m },
            new Produto { Id = 9, Nome = "Cerveja Skol", CategoriaId = 2, Descricao = "Lata 350ml", Foto = "/uploads/produtos/cerveja-skol.jpg", Preco = 6.50m },
            new Produto { Id = 10, Nome = "Cerveja Brahma", CategoriaId = 2, Descricao = "Lata 350ml", Foto = "/uploads/produtos/cerveja-brahma.jpg", Preco = 6.50m },
            new Produto { Id = 11, Nome = "Suco de Laranja", CategoriaId = 2, Descricao = "Copo 300ml", Foto = "/uploads/produtos/suco-laranja.jpg", Preco = 7.50m },
            new Produto { Id = 12, Nome = "Suco de Abacaxi", CategoriaId = 2, Descricao = "Copo 300ml", Foto = "/uploads/produtos/suco-abacaxi.jpg", Preco = 7.50m },
            new Produto { Id = 13, Nome = "Vinho Tinto Taça", CategoriaId = 2, Descricao = "Taça de 200ml", Foto = "/uploads/produtos/vinho-tinto-taca.jpg", Preco = 12.00m },
            new Produto { Id = 14, Nome = "Vinho Branco Taça", CategoriaId = 2, Descricao = "Taça de 200ml", Foto = "/uploads/produtos/vinho-branco-taca.jpg", Preco = 12.00m },
            
            new Produto { Id = 15, Nome = "Mousse de Maracujá", CategoriaId = 3, Descricao = "Porção individual", Foto = "/uploads/produtos/mousse-maracuja.jpg", Preco = 9.90m },
            new Produto { Id = 16, Nome = "Açaí na Tigela", CategoriaId = 3, Descricao = "300ml com granola e banana", Foto = "/uploads/produtos/acai-tigela.jpg", Preco = 14.50m },
            
            new Produto { Id = 17, Nome = "Pão de Alho", CategoriaId = 4, Descricao = "Porção com 8 unidades", Foto = "/uploads/produtos/pao-alho.jpg", Preco = 12.00m },
            new Produto { Id = 18, Nome = "Calabresa Acebolada", CategoriaId = 4, Descricao = "Porção para 2 pessoas", Foto = "/uploads/produtos/calabresa-acebolada.jpg", Preco = 18.00m }
        );

        modelBuilder.Entity<Extra>().HasData(
            // Extras para pizzas
            new Extra { Id = 1, Nome = "Média", PrecoAdicional = 8.50m, ProdutoId = 1 },
            new Extra { Id = 2, Nome = "Grande", PrecoAdicional = 12.50m, ProdutoId = 1 },
            new Extra { Id = 3, Nome = "Média", PrecoAdicional = 8.50m, ProdutoId = 2 },
            new Extra { Id = 4, Nome = "Grande", PrecoAdicional = 12.50m, ProdutoId = 2 },
            new Extra { Id = 5, Nome = "Média", PrecoAdicional = 8.50m, ProdutoId = 3 },
            new Extra { Id = 6, Nome = "Grande", PrecoAdicional = 12.50m, ProdutoId = 3 },
            new Extra { Id = 7, Nome = "Média", PrecoAdicional = 8.50m, ProdutoId = 4 },
            new Extra { Id = 8, Nome = "Grande", PrecoAdicional = 12.50m, ProdutoId = 4 },
            
            new Extra { Id = 9, Nome = "Gelo", PrecoAdicional = 1.00m, ProdutoId = 13 },
            new Extra { Id = 10, Nome = "Gelo", PrecoAdicional = 1.00m, ProdutoId = 14 },
            
            new Extra { Id = 11, Nome = "Molho Extra", PrecoAdicional = 2.50m, ProdutoId = 17 },
            new Extra { Id = 12, Nome = "Molho Extra", PrecoAdicional = 2.50m, ProdutoId = 18 }
        );
    }
}