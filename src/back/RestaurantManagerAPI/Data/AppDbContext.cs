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

        modelBuilder.Entity<ItemPedido>().HasKey(ip => new {ip.ProdutoId, ip.PedidoId});
        modelBuilder.Entity<ExtraSelecionado>().HasKey(es => new {es.ProdutoId, es.PedidoId, es.ExtraId});
        modelBuilder.Entity<ExtraSelecionado>().HasOne(es => es.ItemPedido).WithMany(ip => ip.ExtrasSelecionados).HasForeignKey(es => new { es.ProdutoId, es.PedidoId });

        modelBuilder.Entity<Funcionario>().HasData(
            new Funcionario { Id = 1, Nome = "Administrador", Usuario = "admin", Senha = BCrypt.Net.BCrypt.HashPassword("admin"), Tipo = "Gerente" },
            new Funcionario { Id = 2, Nome = "João da Silva", Usuario = "joao", Senha = BCrypt.Net.BCrypt.HashPassword("senha123"), Tipo = "Funcionario"}
        );
    }
}