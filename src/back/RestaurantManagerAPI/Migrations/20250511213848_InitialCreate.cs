using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Usuario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RelatorioPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataHoraInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataHoraFim = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NomeMesa = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeFuncionario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrecoFinal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatorioPedidos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Foto = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MesaId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    DataHoraInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataHoraFim = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PrecoFinal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ItensRelatorioPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelatorioPedidoId = table.Column<int>(type: "int", nullable: false),
                    NomeProduto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ExtrasSelecionados = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensRelatorioPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensRelatorioPedidos_RelatorioPedidos_RelatorioPedidoId",
                        column: x => x.RelatorioPedidoId,
                        principalTable: "RelatorioPedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Extras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrecoAdicional = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Extras_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ItensPedido",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedido", x => new { x.ProdutoId, x.PedidoId });
                    table.ForeignKey(
                        name: "FK_ItensPedido_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensPedido_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExtrasSelecionados",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ExtraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtrasSelecionados", x => new { x.ProdutoId, x.PedidoId, x.ExtraId });
                    table.ForeignKey(
                        name: "FK_ExtrasSelecionados_Extras_ExtraId",
                        column: x => x.ExtraId,
                        principalTable: "Extras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtrasSelecionados_ItensPedido_ProdutoId_PedidoId",
                        columns: x => new { x.ProdutoId, x.PedidoId },
                        principalTable: "ItensPedido",
                        principalColumns: new[] { "ProdutoId", "PedidoId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Pizzas Salgadas" },
                    { 2, "Pizzas Doces" },
                    { 3, "Entradas e Petiscos" },
                    { 4, "Refrigerantes" },
                    { 5, "Sucos Naturais" },
                    { 6, "Água" },
                    { 7, "Cervejas" },
                    { 8, "Vinhos" },
                    { 9, "Sobremesas" }
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Nome", "Senha", "Tipo", "Usuario" },
                values: new object[] { 1, "Gerente", "$2a$11$Qxg7/LeL.JCSZ4aZDD2mD.7RzYRT20XieewGpmPjcPtigtpzdX8ye", "Gerente", "admin" });

            migrationBuilder.InsertData(
                table: "Mesas",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Mesa 01" },
                    { 2, "Mesa 02" },
                    { 3, "Mesa 03" },
                    { 4, "Mesa 04" },
                    { 5, "Mesa 05" },
                    { 6, "Mesa 06" },
                    { 7, "Mesa 07" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "Descricao", "Foto", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, 1, "Molho de tomate, mussarela, rodelas de calabresa de primeira qualidade e cebola fatiada", "/uploads/produtos/pizza_calabresa.jpg", "Calabresa", 30.00m },
                    { 2, 1, "Molho de tomate, mussarela, rodelas de tomate fresco, manjericão fresco e um toque de parmesão", "./uploads/produtos/pizza-marguerita.jpg", "Marguerita", 32.00m },
                    { 3, 1, "Molho de tomate, mussarela, presunto, ovos cozidos, cebola, azeitonas pretas e orégano", "/uploads/produtos/pizza-portuguesa.jpg", "Portuguesa", 35.00m },
                    { 4, 2, "Delicioso chocolate ao leite derretido", "/uploads/produtos/pizza-chocolate.jpg", "Chocolate Preto", 30.00m },
                    { 5, 2, "Chocolate branco derretido com morangos frescos fatiados", "/uploads/produtos/pizza-choco-morango.jpg", "Chocolate Branco com Morango", 35.00m },
                    { 6, 3, "Pão baguete com pasta de alho caseira, gratinado com queijo (Unidade)", "/uploads/produtos/pao-alho.jpg", "Pão de Alho Tradicional", 8.00m },
                    { 7, 3, "Porção de calabresa fatiada e salteada com cebola. Acompanha pão.", "/uploads/produtos/calabresa-acebolada.jpg", "Calabresa Acebolada", 38.00m },
                    { 8, 4, "Lata 350ml", "/uploads/produtos/coca-cola-lata.jpg", "Coca-Cola", 6.00m },
                    { 9, 4, "Lata 350ml", "/uploads/produtos/guarana-lata.jpg", "Guaraná Antarctica", 6.00m },
                    { 10, 5, "Natural - Copo 400ml", "/uploads/produtos/suco-laranja.jpg", "Suco de Laranja", 9.00m },
                    { 11, 5, "Polpa/Natural - Copo 400ml", "/uploads/produtos/suco-abacaxi.jpg", "Suco de Abacaxi", 9.00m },
                    { 12, 6, "Garrafa 500ml", "/uploads/produtos/agua-sem-gas.jpg", "Água Mineral Sem Gás", 4.00m },
                    { 13, 6, "Garrafa 500ml", "/uploads/produtos/agua-com-gas.jpg", "Água Mineral Com Gás", 4.50m },
                    { 14, 7, "Lata 350ml", "/uploads/produtos/cerveja-skol.jpg", "Skol", 7.00m },
                    { 15, 7, "Lata 350ml", "/uploads/produtos/cerveja-brahma.jpg", "Brahma", 7.00m },
                    { 16, 8, "Taça - Cabernet Sauvignon ou Merlot", "/uploads/produtos/vinho-tinto-taca.jpg", "Vinho Tinto da Casa", 20.00m },
                    { 17, 8, "Taça - Sauvignon Blanc", "/uploads/produtos/vinho-branco-taca.jpg", "Vinho Branco da Casa", 20.00m },
                    { 18, 9, "Mousse de maracujá com açúcar", "/uploads/produtos/mousse-maracuja.jpg", "Mousse de Maracujá", 12.00m },
                    { 19, 9, "300ml - Açaí com granola e banana", "/uploads/produtos/acai-tigela.jpg", "Açaí na Tigela", 22.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Extras_ProdutoId",
                table: "Extras",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtrasSelecionados_ExtraId",
                table: "ExtrasSelecionados",
                column: "ExtraId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_PedidoId",
                table: "ItensPedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensRelatorioPedidos_RelatorioPedidoId",
                table: "ItensRelatorioPedidos",
                column: "RelatorioPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_FuncionarioId",
                table: "Pedidos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_MesaId",
                table: "Pedidos",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtrasSelecionados");

            migrationBuilder.DropTable(
                name: "ItensRelatorioPedidos");

            migrationBuilder.DropTable(
                name: "Extras");

            migrationBuilder.DropTable(
                name: "ItensPedido");

            migrationBuilder.DropTable(
                name: "RelatorioPedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
