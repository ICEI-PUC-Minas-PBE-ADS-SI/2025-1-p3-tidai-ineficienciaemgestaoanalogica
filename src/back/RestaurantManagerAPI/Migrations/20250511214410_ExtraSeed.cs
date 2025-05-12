using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class ExtraSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Extras",
                columns: new[] { "Id", "Nome", "PrecoAdicional", "ProdutoId" },
                values: new object[,]
                {
                    { 1, "Média", 8m, 1 },
                    { 2, "Grande", 16m, 1 },
                    { 3, "Média", 8m, 2 },
                    { 4, "Grande", 16m, 2 },
                    { 5, "Média", 8m, 3 },
                    { 6, "Grande", 16m, 3 },
                    { 7, "Jarra 1l", 18m, 10 },
                    { 8, "Jarra 1l", 18m, 11 }
                });

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$HZEYj6UXWkvyNCMO8UjfVu5gcpYVb9Gda7OXL2oalBtDiPxJmlnva");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Extras",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$Qxg7/LeL.JCSZ4aZDD2mD.7RzYRT20XieewGpmPjcPtigtpzdX8ye");
        }
    }
}
