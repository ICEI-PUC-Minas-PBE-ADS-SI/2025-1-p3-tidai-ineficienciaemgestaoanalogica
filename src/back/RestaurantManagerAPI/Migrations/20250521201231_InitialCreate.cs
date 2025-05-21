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
                    PrecoFinal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                    { 1, "Pizzas" },
                    { 2, "Bebidas" },
                    { 3, "Sobremesas" },
                    { 4, "Acompanhamentos" }
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Nome", "Senha", "Tipo", "Usuario" },
                values: new object[,]
                {
                    { 1, "Administrador", "$2a$11$jUYbELcP2CnolUSJWqId3uSWuXh2XlB9wQN0V2xdmFr33EBz6LIOu", "Gerente", "admin" },
                    { 2, "João da Silva", "$2a$11$UIulyqCEJlS1NDgO4oqemOZbekDHiZVBVVliKWFIQztPRzcKMdJCK", "Funcionario", "joao" }
                });

            migrationBuilder.InsertData(
                table: "Mesas",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Mesa 01" },
                    { 2, "Mesa 02" },
                    { 3, "Mesa 03" },
                    { 4, "Mesa 04" },
                    { 5, "Mesa 05" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "Descricao", "Foto", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, 1, "Calabresa, molho de tomate, mussarela e cebola", "/uploads/produtos/pizza-calabresa.jpg", "Pizza de Calabresa", 23.40m },
                    { 2, 1, "Mussarela, tomate, manjericão e molho de tomate", "/uploads/produtos/pizza-marguerita.jpg", "Pizza Marguerita", 25.90m },
                    { 3, 1, "Presunto, mussarela, ovo, cebola, azeitona e molho de tomate", "/uploads/produtos/pizza-portuguesa.jpg", "Pizza Portuguesa", 28.50m },
                    { 4, 1, "Chocolate ao leite, morangos frescos e leite condensado", "/uploads/produtos/pizza-choco-morango.jpg", "Pizza Chocolate com Morango", 32.00m },
                    { 5, 2, "Garrafa de 500ml", "/uploads/produtos/agua-com-gas.jpg", "Água com Gás", 4.50m },
                    { 6, 2, "Garrafa de 500ml", "/uploads/produtos/agua-sem-gas.jpg", "Água sem Gás", 3.50m },
                    { 7, 2, "Lata 350ml", "/uploads/produtos/coca-cola-lata.jpg", "Coca-Cola Lata", 5.00m },
                    { 8, 2, "Lata 350ml", "/uploads/produtos/guarana-lata.jpg", "Guaraná Lata", 4.80m },
                    { 9, 2, "Lata 350ml", "/uploads/produtos/cerveja-skol.jpg", "Cerveja Skol", 6.50m },
                    { 10, 2, "Lata 350ml", "/uploads/produtos/cerveja-brahma.jpg", "Cerveja Brahma", 6.50m },
                    { 11, 2, "Copo 300ml", "/uploads/produtos/suco-laranja.jpg", "Suco de Laranja", 7.50m },
                    { 12, 2, "Copo 300ml", "/uploads/produtos/suco-abacaxi.jpg", "Suco de Abacaxi", 7.50m },
                    { 13, 2, "Taça de 200ml", "/uploads/produtos/vinho-tinto-taca.jpg", "Vinho Tinto Taça", 12.00m },
                    { 14, 2, "Taça de 200ml", "/uploads/produtos/vinho-branco-taca.jpg", "Vinho Branco Taça", 12.00m },
                    { 15, 3, "Porção individual", "/uploads/produtos/mousse-maracuja.jpg", "Mousse de Maracujá", 9.90m },
                    { 16, 3, "300ml com granola e banana", "/uploads/produtos/acai-tigela.jpg", "Açaí na Tigela", 14.50m },
                    { 17, 4, "Porção com 8 unidades", "/uploads/produtos/pao-alho.jpg", "Pão de Alho", 12.00m },
                    { 18, 4, "Porção para 2 pessoas", "/uploads/produtos/calabresa-acebolada.jpg", "Calabresa Acebolada", 18.00m }
                });

            migrationBuilder.InsertData(
                table: "Extras",
                columns: new[] { "Id", "Nome", "PrecoAdicional", "ProdutoId" },
                values: new object[,]
                {
                    { 1, "Média", 8.50m, 1 },
                    { 2, "Grande", 12.50m, 1 },
                    { 3, "Média", 8.50m, 2 },
                    { 4, "Grande", 12.50m, 2 },
                    { 5, "Média", 8.50m, 3 },
                    { 6, "Grande", 12.50m, 3 },
                    { 7, "Média", 8.50m, 4 },
                    { 8, "Grande", 12.50m, 4 },
                    { 9, "Gelo", 1.00m, 13 },
                    { 10, "Gelo", 1.00m, 14 },
                    { 11, "Molho Extra", 2.50m, 17 },
                    { 12, "Molho Extra", 2.50m, 18 }
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
