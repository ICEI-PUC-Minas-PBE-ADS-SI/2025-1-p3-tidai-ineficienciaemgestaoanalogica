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
                    DataHoraAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedido", x => x.Id);
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
                    ItemPedidoId = table.Column<int>(type: "int", nullable: false),
                    ExtraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtrasSelecionados", x => new { x.ItemPedidoId, x.ExtraId });
                    table.ForeignKey(
                        name: "FK_ExtrasSelecionados_Extras_ExtraId",
                        column: x => x.ExtraId,
                        principalTable: "Extras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtrasSelecionados_ItensPedido_ItemPedidoId",
                        column: x => x.ItemPedidoId,
                        principalTable: "ItensPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Pizzas" },
                    { 2, "Pizzas Doces" },
                    { 3, "Acompanhamentos" },
                    { 4, "Sobremesas" },
                    { 5, "Bebidas" },
                    { 6, "Bebidas Alcoólicas" }
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Nome", "Senha", "Tipo", "Usuario" },
                values: new object[,]
                {
                    { 1, "Administrador", "$2a$11$iAbhdMlHc8fs2RHhhibHRuAKGiBnUEd0uu1fcJIOSgdaTxrKHGxO6", "Gerente", "admin" },
                    { 2, "João da Silva", "$2a$11$OILz9Xl2epKsw5XpsRxsPOVDO1y4ZqxmneD6pTXwFn7LVgk3FC0n2", "Funcionario", "joao" }
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
                    { 4, 1, "Pepperoni, mussarela e molho de tomate", "/uploads/produtos/pizza-pepperoni.jpg", "Pizza Pepperoni", 29.90m },
                    { 5, 1, "Frango desfiado, catupiry e milho", "/uploads/produtos/pizza-frango.jpg", "Pizza Frango Catupiry", 30.50m },
                    { 6, 1, "Berinjela, abobrinha, pimentão, cebola e azeitonas", "/uploads/produtos/pizza-vegetariana.jpg", "Pizza Vegetariana", 31.00m },
                    { 7, 2, "Chocolate ao leite, morangos frescos e leite condensado", "/uploads/produtos/pizza-choco-morango.jpg", "Pizza Chocolate com Morango", 32.00m },
                    { 8, 2, "Goiabada e queijo mussarela", "/uploads/produtos/pizza-romeu-julieta.jpg", "Pizza Romeu e Julieta", 28.50m },
                    { 9, 2, "Banana caramelizada, canela e leite condensado", "/uploads/produtos/pizza-banana.jpg", "Pizza Banana Canela", 27.90m },
                    { 10, 2, "Nutella, morangos frescos e chocolate branco", "/uploads/produtos/pizza-nutella.jpg", "Pizza Nutella com Morango", 35.00m },
                    { 11, 2, "Chocolate, granulado e leite condensado", "/uploads/produtos/pizza-brigadeiro.jpg", "Pizza Brigadeiro", 26.50m },
                    { 12, 2, "Doce de leite argentino e coco ralado", "/uploads/produtos/pizza-doce-leite.jpg", "Pizza Doce de Leite", 29.00m },
                    { 13, 3, "Porção com 8 unidades", "/uploads/produtos/pao-alho.jpg", "Pão de Alho", 12.00m },
                    { 14, 3, "Porção para 2 pessoas", "/uploads/produtos/calabresa-acebolada.jpg", "Calabresa Acebolada", 18.00m },
                    { 15, 3, "Porção grande com cheddar e bacon", "/uploads/produtos/batata-frita.jpg", "Batata Frita", 15.00m },
                    { 16, 3, "Porção com 10 unidades", "/uploads/produtos/aneis-cebola.jpg", "Anéis de Cebola", 14.50m },
                    { 17, 3, "6 unidades com tomate e manjericão", "/uploads/produtos/bruschetta.jpg", "Bruschetta", 13.00m },
                    { 18, 3, "10 unidades com molho barbecue", "/uploads/produtos/nuggets.jpg", "Nuggets", 16.00m },
                    { 19, 4, "Porção individual", "/uploads/produtos/mousse-maracuja.jpg", "Mousse de Maracujá", 9.90m },
                    { 20, 4, "300ml com granola e banana", "/uploads/produtos/acai-tigela.jpg", "Açaí na Tigela", 14.50m },
                    { 21, 4, "Brownie quente com sorvete de creme", "/uploads/produtos/brownie.jpg", "Brownie com Sorvete", 18.00m },
                    { 22, 4, "Fatia com calda de morango", "/uploads/produtos/cheesecake.jpg", "Cheesecake de Morango", 16.50m },
                    { 23, 4, "Fatia tradicional", "/uploads/produtos/pudim.jpg", "Pudim de Leite", 8.50m },
                    { 24, 4, "Escolha dois sabores", "/uploads/produtos/sorvete.jpg", "Sorvete 2 Bolas", 12.00m },
                    { 25, 5, "Garrafa de 500ml", "/uploads/produtos/agua-com-gas.jpg", "Água com Gás", 4.50m },
                    { 26, 5, "Garrafa de 500ml", "/uploads/produtos/agua-sem-gas.jpg", "Água sem Gás", 3.50m },
                    { 27, 5, "Lata 350ml", "/uploads/produtos/coca-cola-lata.jpg", "Coca-Cola Lata", 5.00m },
                    { 28, 5, "Lata 350ml", "/uploads/produtos/guarana-lata.jpg", "Guaraná Lata", 4.80m },
                    { 29, 5, "Copo 300ml", "/uploads/produtos/suco-laranja.jpg", "Suco de Laranja", 7.50m },
                    { 30, 5, "Copo 300ml", "/uploads/produtos/suco-abacaxi.jpg", "Suco de Abacaxi", 7.50m },
                    { 31, 6, "Lata 350ml", "/uploads/produtos/cerveja-skol.jpg", "Cerveja Skol", 6.50m },
                    { 32, 6, "Lata 350ml", "/uploads/produtos/cerveja-brahma.jpg", "Cerveja Brahma", 6.50m },
                    { 33, 6, "Taça de 200ml", "/uploads/produtos/vinho-tinto-taca.jpg", "Vinho Tinto Taça", 12.00m },
                    { 34, 6, "Taça de 200ml", "/uploads/produtos/vinho-branco-taca.jpg", "Vinho Branco Taça", 12.00m },
                    { 35, 6, "Tradicional de limão (300ml)", "/uploads/produtos/caipirinha.jpg", "Caipirinha", 15.00m },
                    { 36, 6, "Garrafa 330ml", "/uploads/produtos/heineken.jpg", "Heineken Long Neck", 9.90m }
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
                    { 9, "Média", 8.50m, 5 },
                    { 10, "Grande", 12.50m, 5 },
                    { 11, "Média", 8.50m, 6 },
                    { 12, "Grande", 12.50m, 6 },
                    { 13, "Borda Doce", 5.00m, 7 },
                    { 14, "Borda Doce", 5.00m, 8 },
                    { 15, "Borda Doce", 5.00m, 9 },
                    { 16, "Borda Doce", 5.00m, 10 },
                    { 17, "Borda Doce", 5.00m, 11 },
                    { 18, "Borda Doce", 5.00m, 12 },
                    { 19, "Porção Grande", 5.00m, 13 },
                    { 20, "Porção Grande", 5.00m, 14 },
                    { 21, "Porção Grande", 5.00m, 15 },
                    { 22, "Porção Grande", 5.00m, 16 },
                    { 23, "Porção Grande", 5.00m, 17 },
                    { 24, "Porção Grande", 5.00m, 18 },
                    { 25, "Calda Extra", 3.00m, 19 },
                    { 26, "Calda Extra", 3.00m, 20 },
                    { 27, "Calda Extra", 3.00m, 21 },
                    { 28, "Calda Extra", 3.00m, 22 },
                    { 29, "Calda Extra", 3.00m, 23 },
                    { 30, "Calda Extra", 3.00m, 24 },
                    { 31, "Gelo", 1.00m, 25 },
                    { 32, "Gelo", 1.00m, 26 },
                    { 33, "Gelo", 1.00m, 27 },
                    { 34, "Gelo", 1.00m, 28 },
                    { 35, "Gelo", 1.00m, 29 },
                    { 36, "Gelo", 1.00m, 30 },
                    { 37, "Garrafa 600ml", 8.00m, 31 },
                    { 38, "Garrafa 600ml", 8.00m, 32 },
                    { 39, "Garrafa 750ml", 45.00m, 33 },
                    { 40, "Garrafa 750ml", 45.00m, 34 },
                    { 41, "Jarra 1L", 25.00m, 35 },
                    { 42, "Garrafa 600ml", 8.00m, 36 }
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
                name: "IX_ItensPedido_ProdutoId",
                table: "ItensPedido",
                column: "ProdutoId");

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
