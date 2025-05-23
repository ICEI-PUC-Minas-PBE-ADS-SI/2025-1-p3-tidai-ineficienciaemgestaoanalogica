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
            new Categoria { Id = 2, Nome = "Pizzas Doces" },
            new Categoria { Id = 3, Nome = "Acompanhamentos" },
            new Categoria { Id = 4, Nome = "Sobremesas" },
            new Categoria { Id = 5, Nome = "Bebidas" },
            new Categoria { Id = 6, Nome = "Bebidas Alcoólicas" }
        );

        modelBuilder.Entity<Produto>().HasData(
            new Produto { Id = 1, Nome = "Pizza de Calabresa", CategoriaId = 1, Descricao = "Calabresa, molho de tomate, mussarela e cebola", Foto = "/uploads/produtos/pizza-calabresa.jpg", Preco = 23.40m },
            new Produto { Id = 2, Nome = "Pizza Marguerita", CategoriaId = 1, Descricao = "Mussarela, tomate, manjericão e molho de tomate", Foto = "/uploads/produtos/pizza-marguerita.jpg", Preco = 25.90m },
            new Produto { Id = 3, Nome = "Pizza Portuguesa", CategoriaId = 1, Descricao = "Presunto, mussarela, ovo, cebola, azeitona e molho de tomate", Foto = "/uploads/produtos/pizza-portuguesa.jpg", Preco = 28.50m },
            new Produto { Id = 4, Nome = "Pizza Pepperoni", CategoriaId = 1, Descricao = "Pepperoni, mussarela e molho de tomate", Foto = "/uploads/produtos/pizza-pepperoni.jpg", Preco = 29.90m },
            new Produto { Id = 5, Nome = "Pizza Frango Catupiry", CategoriaId = 1, Descricao = "Frango desfiado, catupiry e milho", Foto = "/uploads/produtos/pizza-frango.jpg", Preco = 30.50m },
            new Produto { Id = 6, Nome = "Pizza Vegetariana", CategoriaId = 1, Descricao = "Berinjela, abobrinha, pimentão, cebola e azeitonas", Foto = "/uploads/produtos/pizza-vegetariana.jpg", Preco = 31.00m },

            new Produto { Id = 7, Nome = "Pizza Chocolate com Morango", CategoriaId = 2, Descricao = "Chocolate ao leite, morangos frescos e leite condensado", Foto = "/uploads/produtos/pizza-choco-morango.jpg", Preco = 32.00m },
            new Produto { Id = 8, Nome = "Pizza Romeu e Julieta", CategoriaId = 2, Descricao = "Goiabada e queijo mussarela", Foto = "/uploads/produtos/pizza-romeu-julieta.jpg", Preco = 28.50m },
            new Produto { Id = 9, Nome = "Pizza Banana Canela", CategoriaId = 2, Descricao = "Banana caramelizada, canela e leite condensado", Foto = "/uploads/produtos/pizza-banana.jpg", Preco = 27.90m },
            new Produto { Id = 10, Nome = "Pizza Nutella com Morango", CategoriaId = 2, Descricao = "Nutella, morangos frescos e chocolate branco", Foto = "/uploads/produtos/pizza-nutella.jpg", Preco = 35.00m },
            new Produto { Id = 11, Nome = "Pizza Brigadeiro", CategoriaId = 2, Descricao = "Chocolate, granulado e leite condensado", Foto = "/uploads/produtos/pizza-brigadeiro.jpg", Preco = 26.50m },
            new Produto { Id = 12, Nome = "Pizza Doce de Leite", CategoriaId = 2, Descricao = "Doce de leite argentino e coco ralado", Foto = "/uploads/produtos/pizza-doce-leite.jpg", Preco = 29.00m },

            new Produto { Id = 13, Nome = "Pão de Alho", CategoriaId = 3, Descricao = "Porção com 8 unidades", Foto = "/uploads/produtos/pao-alho.jpg", Preco = 12.00m },
            new Produto { Id = 14, Nome = "Calabresa Acebolada", CategoriaId = 3, Descricao = "Porção para 2 pessoas", Foto = "/uploads/produtos/calabresa-acebolada.jpg", Preco = 18.00m },
            new Produto { Id = 15, Nome = "Batata Frita", CategoriaId = 3, Descricao = "Porção grande com cheddar e bacon", Foto = "/uploads/produtos/batata-frita.jpg", Preco = 15.00m },
            new Produto { Id = 16, Nome = "Anéis de Cebola", CategoriaId = 3, Descricao = "Porção com 10 unidades", Foto = "/uploads/produtos/aneis-cebola.jpg", Preco = 14.50m },
            new Produto { Id = 17, Nome = "Bruschetta", CategoriaId = 3, Descricao = "6 unidades com tomate e manjericão", Foto = "/uploads/produtos/bruschetta.jpg", Preco = 13.00m },
            new Produto { Id = 18, Nome = "Nuggets", CategoriaId = 3, Descricao = "10 unidades com molho barbecue", Foto = "/uploads/produtos/nuggets.jpg", Preco = 16.00m },

            new Produto { Id = 19, Nome = "Mousse de Maracujá", CategoriaId = 4, Descricao = "Porção individual", Foto = "/uploads/produtos/mousse-maracuja.jpg", Preco = 9.90m },
            new Produto { Id = 20, Nome = "Açaí na Tigela", CategoriaId = 4, Descricao = "300ml com granola e banana", Foto = "/uploads/produtos/acai-tigela.jpg", Preco = 14.50m },
            new Produto { Id = 21, Nome = "Brownie com Sorvete", CategoriaId = 4, Descricao = "Brownie quente com sorvete de creme", Foto = "/uploads/produtos/brownie.jpg", Preco = 18.00m },
            new Produto { Id = 22, Nome = "Cheesecake de Morango", CategoriaId = 4, Descricao = "Fatia com calda de morango", Foto = "/uploads/produtos/cheesecake.jpg", Preco = 16.50m },
            new Produto { Id = 23, Nome = "Pudim de Leite", CategoriaId = 4, Descricao = "Fatia tradicional", Foto = "/uploads/produtos/pudim.jpg", Preco = 8.50m },
            new Produto { Id = 24, Nome = "Sorvete 2 Bolas", CategoriaId = 4, Descricao = "Escolha dois sabores", Foto = "/uploads/produtos/sorvete.jpg", Preco = 12.00m },

            new Produto { Id = 25, Nome = "Água com Gás", CategoriaId = 5, Descricao = "Garrafa de 500ml", Foto = "/uploads/produtos/agua-com-gas.jpg", Preco = 4.50m },
            new Produto { Id = 26, Nome = "Água sem Gás", CategoriaId = 5, Descricao = "Garrafa de 500ml", Foto = "/uploads/produtos/agua-sem-gas.jpg", Preco = 3.50m },
            new Produto { Id = 27, Nome = "Coca-Cola Lata", CategoriaId = 5, Descricao = "Lata 350ml", Foto = "/uploads/produtos/coca-cola-lata.jpg", Preco = 5.00m },
            new Produto { Id = 28, Nome = "Guaraná Lata", CategoriaId = 5, Descricao = "Lata 350ml", Foto = "/uploads/produtos/guarana-lata.jpg", Preco = 4.80m },
            new Produto { Id = 29, Nome = "Suco de Laranja", CategoriaId = 5, Descricao = "Copo 300ml", Foto = "/uploads/produtos/suco-laranja.jpg", Preco = 7.50m },
            new Produto { Id = 30, Nome = "Suco de Abacaxi", CategoriaId = 5, Descricao = "Copo 300ml", Foto = "/uploads/produtos/suco-abacaxi.jpg", Preco = 7.50m },

            new Produto { Id = 31, Nome = "Cerveja Skol", CategoriaId = 6, Descricao = "Lata 350ml", Foto = "/uploads/produtos/cerveja-skol.jpg", Preco = 6.50m },
            new Produto { Id = 32, Nome = "Cerveja Brahma", CategoriaId = 6, Descricao = "Lata 350ml", Foto = "/uploads/produtos/cerveja-brahma.jpg", Preco = 6.50m },
            new Produto { Id = 33, Nome = "Vinho Tinto Taça", CategoriaId = 6, Descricao = "Taça de 200ml", Foto = "/uploads/produtos/vinho-tinto-taca.jpg", Preco = 12.00m },
            new Produto { Id = 34, Nome = "Vinho Branco Taça", CategoriaId = 6, Descricao = "Taça de 200ml", Foto = "/uploads/produtos/vinho-branco-taca.jpg", Preco = 12.00m },
            new Produto { Id = 35, Nome = "Caipirinha", CategoriaId = 6, Descricao = "Tradicional de limão (300ml)", Foto = "/uploads/produtos/caipirinha.jpg", Preco = 15.00m },
            new Produto { Id = 36, Nome = "Heineken Long Neck", CategoriaId = 6, Descricao = "Garrafa 330ml", Foto = "/uploads/produtos/heineken.jpg", Preco = 9.90m }
        );

        modelBuilder.Entity<Extra>().HasData(
            new Extra { Id = 1, Nome = "Média", PrecoAdicional = 8.50m, ProdutoId = 1 },
            new Extra { Id = 2, Nome = "Grande", PrecoAdicional = 12.50m, ProdutoId = 1 },
            new Extra { Id = 3, Nome = "Média", PrecoAdicional = 8.50m, ProdutoId = 2 },
            new Extra { Id = 4, Nome = "Grande", PrecoAdicional = 12.50m, ProdutoId = 2 },
            new Extra { Id = 5, Nome = "Média", PrecoAdicional = 8.50m, ProdutoId = 3 },
            new Extra { Id = 6, Nome = "Grande", PrecoAdicional = 12.50m, ProdutoId = 3 },
            new Extra { Id = 7, Nome = "Média", PrecoAdicional = 8.50m, ProdutoId = 4 },
            new Extra { Id = 8, Nome = "Grande", PrecoAdicional = 12.50m, ProdutoId = 4 },
            new Extra { Id = 9, Nome = "Média", PrecoAdicional = 8.50m, ProdutoId = 5 },
            new Extra { Id = 10, Nome = "Grande", PrecoAdicional = 12.50m, ProdutoId = 5 },
            new Extra { Id = 11, Nome = "Média", PrecoAdicional = 8.50m, ProdutoId = 6 },
            new Extra { Id = 12, Nome = "Grande", PrecoAdicional = 12.50m, ProdutoId = 6 },

            new Extra { Id = 13, Nome = "Borda Doce", PrecoAdicional = 5.00m, ProdutoId = 7 },
            new Extra { Id = 14, Nome = "Borda Doce", PrecoAdicional = 5.00m, ProdutoId = 8 },
            new Extra { Id = 15, Nome = "Borda Doce", PrecoAdicional = 5.00m, ProdutoId = 9 },
            new Extra { Id = 16, Nome = "Borda Doce", PrecoAdicional = 5.00m, ProdutoId = 10 },
            new Extra { Id = 17, Nome = "Borda Doce", PrecoAdicional = 5.00m, ProdutoId = 11 },
            new Extra { Id = 18, Nome = "Borda Doce", PrecoAdicional = 5.00m, ProdutoId = 12 },

            new Extra { Id = 19, Nome = "Porção Grande", PrecoAdicional = 5.00m, ProdutoId = 13 },
            new Extra { Id = 20, Nome = "Porção Grande", PrecoAdicional = 5.00m, ProdutoId = 14 },
            new Extra { Id = 21, Nome = "Porção Grande", PrecoAdicional = 5.00m, ProdutoId = 15 },
            new Extra { Id = 22, Nome = "Porção Grande", PrecoAdicional = 5.00m, ProdutoId = 16 },
            new Extra { Id = 23, Nome = "Porção Grande", PrecoAdicional = 5.00m, ProdutoId = 17 },
            new Extra { Id = 24, Nome = "Porção Grande", PrecoAdicional = 5.00m, ProdutoId = 18 },

            new Extra { Id = 25, Nome = "Calda Extra", PrecoAdicional = 3.00m, ProdutoId = 19 },
            new Extra { Id = 26, Nome = "Calda Extra", PrecoAdicional = 3.00m, ProdutoId = 20 },
            new Extra { Id = 27, Nome = "Calda Extra", PrecoAdicional = 3.00m, ProdutoId = 21 },
            new Extra { Id = 28, Nome = "Calda Extra", PrecoAdicional = 3.00m, ProdutoId = 22 },
            new Extra { Id = 29, Nome = "Calda Extra", PrecoAdicional = 3.00m, ProdutoId = 23 },
            new Extra { Id = 30, Nome = "Calda Extra", PrecoAdicional = 3.00m, ProdutoId = 24 },

            new Extra { Id = 31, Nome = "Gelo", PrecoAdicional = 1.00m, ProdutoId = 25 },
            new Extra { Id = 32, Nome = "Gelo", PrecoAdicional = 1.00m, ProdutoId = 26 },
            new Extra { Id = 33, Nome = "Gelo", PrecoAdicional = 1.00m, ProdutoId = 27 },
            new Extra { Id = 34, Nome = "Gelo", PrecoAdicional = 1.00m, ProdutoId = 28 },
            new Extra { Id = 35, Nome = "Gelo", PrecoAdicional = 1.00m, ProdutoId = 29 },
            new Extra { Id = 36, Nome = "Gelo", PrecoAdicional = 1.00m, ProdutoId = 30 },

            new Extra { Id = 37, Nome = "Garrafa 600ml", PrecoAdicional = 8.00m, ProdutoId = 31 },
            new Extra { Id = 38, Nome = "Garrafa 600ml", PrecoAdicional = 8.00m, ProdutoId = 32 },
            new Extra { Id = 39, Nome = "Garrafa 750ml", PrecoAdicional = 45.00m, ProdutoId = 33 },
            new Extra { Id = 40, Nome = "Garrafa 750ml", PrecoAdicional = 45.00m, ProdutoId = 34 },
            new Extra { Id = 41, Nome = "Jarra 1L", PrecoAdicional = 25.00m, ProdutoId = 35 },
            new Extra { Id = 42, Nome = "Garrafa 600ml", PrecoAdicional = 8.00m, ProdutoId = 36 }
        );
    }
}
