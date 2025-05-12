using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class PedidoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Pedidos",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$k2lnzbDMq6xZMx08/GQAm.Nnr3K4K1Tetv1P7eeuKRv2y9/1cQYB2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Pedidos");

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$HZEYj6UXWkvyNCMO8UjfVu5gcpYVb9Gda7OXL2oalBtDiPxJmlnva");
        }
    }
}
