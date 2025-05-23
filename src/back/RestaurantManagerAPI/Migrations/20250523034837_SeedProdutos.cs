using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "Pizzas Doces");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "Acompanhamentos");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nome",
                value: "Sobremesas");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 5, "Bebidas" },
                    { 6, "Bebidas Alcoólicas" }
                });

            migrationBuilder.UpdateData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Nome", "PrecoAdicional", "ProdutoId" },
                values: new object[] { "Média", 8.50m, 5 });

            migrationBuilder.UpdateData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Nome", "PrecoAdicional", "ProdutoId" },
                values: new object[] { "Grande", 12.50m, 5 });

            migrationBuilder.UpdateData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Nome", "PrecoAdicional", "ProdutoId" },
                values: new object[] { "Média", 8.50m, 6 });

            migrationBuilder.UpdateData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Nome", "PrecoAdicional", "ProdutoId" },
                values: new object[] { "Grande", 12.50m, 6 });

            migrationBuilder.InsertData(
                table: "Extras",
                columns: new[] { "Id", "Nome", "PrecoAdicional", "ProdutoId" },
                values: new object[,]
                {
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
                    { 24, "Porção Grande", 5.00m, 18 }
                });

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$gpi14./Bidhwo88XRFrRz.Aj8aLWDGb.fFWJDt68Fr0CxqvgLhpoa");

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Senha",
                value: "$2a$11$a0wT6qawrH63G9ULXxxSZ.gIVZoJA4UAKpSPeo4f8GnupxyABcnPe");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Pepperoni, mussarela e molho de tomate", "/uploads/produtos/pizza-pepperoni.jpg", "Pizza Pepperoni", 29.90m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoriaId", "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { 1, "Frango desfiado, catupiry e milho", "/uploads/produtos/pizza-frango.jpg", "Pizza Frango Catupiry", 30.50m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoriaId", "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { 1, "Berinjela, abobrinha, pimentão, cebola e azeitonas", "/uploads/produtos/pizza-vegetariana.jpg", "Pizza Vegetariana", 31.00m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Chocolate ao leite, morangos frescos e leite condensado", "/uploads/produtos/pizza-choco-morango.jpg", "Pizza Chocolate com Morango", 32.00m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Goiabada e queijo mussarela", "/uploads/produtos/pizza-romeu-julieta.jpg", "Pizza Romeu e Julieta", 28.50m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Banana caramelizada, canela e leite condensado", "/uploads/produtos/pizza-banana.jpg", "Pizza Banana Canela", 27.90m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Nutella, morangos frescos e chocolate branco", "/uploads/produtos/pizza-nutella.jpg", "Pizza Nutella com Morango", 35.00m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Chocolate, granulado e leite condensado", "/uploads/produtos/pizza-brigadeiro.jpg", "Pizza Brigadeiro", 26.50m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Doce de leite argentino e coco ralado", "/uploads/produtos/pizza-doce-leite.jpg", "Pizza Doce de Leite", 29.00m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoriaId", "Descricao", "Foto", "Nome" },
                values: new object[] { 3, "Porção com 8 unidades", "/uploads/produtos/pao-alho.jpg", "Pão de Alho" });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CategoriaId", "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { 3, "Porção para 2 pessoas", "/uploads/produtos/calabresa-acebolada.jpg", "Calabresa Acebolada", 18.00m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Porção grande com cheddar e bacon", "/uploads/produtos/batata-frita.jpg", "Batata Frita", 15.00m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Descricao", "Foto", "Nome" },
                values: new object[] { "Porção com 10 unidades", "/uploads/produtos/aneis-cebola.jpg", "Anéis de Cebola" });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CategoriaId", "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { 3, "6 unidades com tomate e manjericão", "/uploads/produtos/bruschetta.jpg", "Bruschetta", 13.00m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CategoriaId", "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { 3, "10 unidades com molho barbecue", "/uploads/produtos/nuggets.jpg", "Nuggets", 16.00m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "Descricao", "Foto", "Nome", "Preco" },
                values: new object[,]
                {
                    { 19, 4, "Porção individual", "/uploads/produtos/mousse-maracuja.jpg", "Mousse de Maracujá", 9.90m },
                    { 20, 4, "300ml com granola e banana", "/uploads/produtos/acai-tigela.jpg", "Açaí na Tigela", 14.50m },
                    { 21, 4, "Brownie quente com sorvete de creme", "/uploads/produtos/brownie.jpg", "Brownie com Sorvete", 18.00m },
                    { 22, 4, "Fatia com calda de morango", "/uploads/produtos/cheesecake.jpg", "Cheesecake de Morango", 16.50m },
                    { 23, 4, "Fatia tradicional", "/uploads/produtos/pudim.jpg", "Pudim de Leite", 8.50m },
                    { 24, 4, "Escolha dois sabores", "/uploads/produtos/sorvete.jpg", "Sorvete 2 Bolas", 12.00m }
                });

            migrationBuilder.InsertData(
                table: "Extras",
                columns: new[] { "Id", "Nome", "PrecoAdicional", "ProdutoId" },
                values: new object[,]
                {
                    { 25, "Calda Extra", 3.00m, 19 },
                    { 26, "Calda Extra", 3.00m, 20 },
                    { 27, "Calda Extra", 3.00m, 21 },
                    { 28, "Calda Extra", 3.00m, 22 },
                    { 29, "Calda Extra", 3.00m, 23 },
                    { 30, "Calda Extra", 3.00m, 24 }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "Descricao", "Foto", "Nome", "Preco" },
                values: new object[,]
                {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "Bebidas");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "Sobremesas");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nome",
                value: "Acompanhamentos");

            migrationBuilder.UpdateData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Nome", "PrecoAdicional", "ProdutoId" },
                values: new object[] { "Gelo", 1.00m, 13 });

            migrationBuilder.UpdateData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Nome", "PrecoAdicional", "ProdutoId" },
                values: new object[] { "Gelo", 1.00m, 14 });

            migrationBuilder.UpdateData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Nome", "PrecoAdicional", "ProdutoId" },
                values: new object[] { "Molho Extra", 2.50m, 17 });

            migrationBuilder.UpdateData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Nome", "PrecoAdicional", "ProdutoId" },
                values: new object[] { "Molho Extra", 2.50m, 18 });

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$jUYbELcP2CnolUSJWqId3uSWuXh2XlB9wQN0V2xdmFr33EBz6LIOu");

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Senha",
                value: "$2a$11$UIulyqCEJlS1NDgO4oqemOZbekDHiZVBVVliKWFIQztPRzcKMdJCK");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Chocolate ao leite, morangos frescos e leite condensado", "/uploads/produtos/pizza-choco-morango.jpg", "Pizza Chocolate com Morango", 32.00m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoriaId", "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { 2, "Garrafa de 500ml", "/uploads/produtos/agua-com-gas.jpg", "Água com Gás", 4.50m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoriaId", "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { 2, "Garrafa de 500ml", "/uploads/produtos/agua-sem-gas.jpg", "Água sem Gás", 3.50m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Lata 350ml", "/uploads/produtos/coca-cola-lata.jpg", "Coca-Cola Lata", 5.00m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Lata 350ml", "/uploads/produtos/guarana-lata.jpg", "Guaraná Lata", 4.80m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Lata 350ml", "/uploads/produtos/cerveja-skol.jpg", "Cerveja Skol", 6.50m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Lata 350ml", "/uploads/produtos/cerveja-brahma.jpg", "Cerveja Brahma", 6.50m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Copo 300ml", "/uploads/produtos/suco-laranja.jpg", "Suco de Laranja", 7.50m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Copo 300ml", "/uploads/produtos/suco-abacaxi.jpg", "Suco de Abacaxi", 7.50m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoriaId", "Descricao", "Foto", "Nome" },
                values: new object[] { 2, "Taça de 200ml", "/uploads/produtos/vinho-tinto-taca.jpg", "Vinho Tinto Taça" });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CategoriaId", "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { 2, "Taça de 200ml", "/uploads/produtos/vinho-branco-taca.jpg", "Vinho Branco Taça", 12.00m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { "Porção individual", "/uploads/produtos/mousse-maracuja.jpg", "Mousse de Maracujá", 9.90m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Descricao", "Foto", "Nome" },
                values: new object[] { "300ml com granola e banana", "/uploads/produtos/acai-tigela.jpg", "Açaí na Tigela" });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CategoriaId", "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { 4, "Porção com 8 unidades", "/uploads/produtos/pao-alho.jpg", "Pão de Alho", 12.00m });

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CategoriaId", "Descricao", "Foto", "Nome", "Preco" },
                values: new object[] { 4, "Porção para 2 pessoas", "/uploads/produtos/calabresa-acebolada.jpg", "Calabresa Acebolada", 18.00m });
        }
    }
}
