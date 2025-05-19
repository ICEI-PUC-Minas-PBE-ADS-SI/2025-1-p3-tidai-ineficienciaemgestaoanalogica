using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitalSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$bb.Uc37MdlDs/HQNZeUILeXskNeEsrH0I1MpuDd1roA92yDri2DL6");

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Nome", "Senha", "Tipo", "Usuario" },
                values: new object[] { 2, "João da Silva", "$2a$11$7HtVWQCS2YtBimkkHM1AF./dnOSu5IHfqHzU5dJTwhX/FJhz9VpSq", "Funcionario", "joao" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Senha",
                value: "$2a$11$u.x7DC0sDAjiy236mqu/5e2GHbJftzTcRCEiOry1JVBtRVECqTere");
        }
    }
}
