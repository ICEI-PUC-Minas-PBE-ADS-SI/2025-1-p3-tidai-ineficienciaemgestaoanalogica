using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$E4WRsGpzHJXs6CJO9mIw2ejpSZYGgQ8Iu6E415ItCgUAFyR4F78N6");

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Senha",
                value: "$2a$11$l76OdealWElKQR41yZiiP.z9IXMTo/UkJbLD1JwyQL/zni8S8cYwy");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Foto",
                value: "/uploads/produtos/pizza-calabresa.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Foto",
                value: "/uploads/produtos/pizza-marguerita.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Foto",
                value: "/uploads/produtos/pizza-portuguesa.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Foto",
                value: "/uploads/produtos/pizza-choco-morango.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Foto",
                value: "/uploads/produtos/agua-com-gas.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 6,
                column: "Foto",
                value: "/uploads/produtos/agua-sem-gas.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 7,
                column: "Foto",
                value: "/uploads/produtos/coca-cola-lata.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 8,
                column: "Foto",
                value: "/uploads/produtos/guarana-lata.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 9,
                column: "Foto",
                value: "/uploads/produtos/cerveja-skol.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 10,
                column: "Foto",
                value: "/uploads/produtos/cerveja-brahma.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 11,
                column: "Foto",
                value: "/uploads/produtos/suco-laranja.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 12,
                column: "Foto",
                value: "/uploads/produtos/suco-abacaxi.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 13,
                column: "Foto",
                value: "/uploads/produtos/vinho-tinto-taca.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 14,
                column: "Foto",
                value: "/uploads/produtos/vinho-branco-taca.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 15,
                column: "Foto",
                value: "/uploads/produtos/mousse-maracuja.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 16,
                column: "Foto",
                value: "/uploads/produtos/acai-tigela.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 17,
                column: "Foto",
                value: "/uploads/produtos/pao-alho.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 18,
                column: "Foto",
                value: "/uploads/produtos/calabresa-acebolada.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$x6aSF4S5zrF/BH3Xfz8s8.FIhsk8.CSmOC1XeNW25aBAw6TjVVrr.");

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Senha",
                value: "$2a$11$fFvRupG.mRZbK9YkHsbiSekIx90JyldgEnFKNBSaHzEwxU.KQpxVO");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Foto",
                value: "uploads/produtos/pizza-calabresa.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Foto",
                value: "uploads/produtos/pizza-marguerita.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Foto",
                value: "uploads/produtos/pizza-portuguesa.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Foto",
                value: "uploads/produtos/pizza-choco-morango.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Foto",
                value: "uploads/produtos/agua-com-gas.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 6,
                column: "Foto",
                value: "uploads/produtos/agua-sem-gas.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 7,
                column: "Foto",
                value: "uploads/produtos/coca-cola-lata.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 8,
                column: "Foto",
                value: "uploads/produtos/guarana-lata.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 9,
                column: "Foto",
                value: "uploads/produtos/cerveja-skol.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 10,
                column: "Foto",
                value: "uploads/produtos/cerveja-brahma.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 11,
                column: "Foto",
                value: "uploads/produtos/suco-laranja.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 12,
                column: "Foto",
                value: "uploads/produtos/suco-abacaxi.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 13,
                column: "Foto",
                value: "uploads/produtos/vinho-tinto-taca.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 14,
                column: "Foto",
                value: "uploads/produtos/vinho-branco-taca.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 15,
                column: "Foto",
                value: "uploads/produtos/mousse-maracuja.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 16,
                column: "Foto",
                value: "uploads/produtos/acai-tigela.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 17,
                column: "Foto",
                value: "uploads/produtos/pao-alho.jpg");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 18,
                column: "Foto",
                value: "uploads/produtos/calabresa-acebolada.jpg");
        }
    }
}
