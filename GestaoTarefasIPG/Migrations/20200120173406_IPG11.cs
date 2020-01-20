using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefasIPG.Migrations
{
    public partial class IPG11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Escola_Departamento_DepartamentoId",
                table: "Escola");

            migrationBuilder.DropIndex(
                name: "IX_Escola_DepartamentoId",
                table: "Escola");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Escola");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Escola",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Escola_DepartamentoId",
                table: "Escola",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Escola_Departamento_DepartamentoId",
                table: "Escola",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
