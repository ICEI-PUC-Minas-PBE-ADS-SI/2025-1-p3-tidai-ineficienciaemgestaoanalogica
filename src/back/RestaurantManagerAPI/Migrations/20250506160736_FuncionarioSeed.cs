using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class FuncionarioSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$DsDqO1aAKF8awi28KQ85i.wyk8wl5O7Ay0MgAOQs2m1Byw50M.2j6");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "admin");
        }
    }
}
