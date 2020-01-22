using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefasIPG.Migrations
{
    public partial class Departa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Escola_EscolaId",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_EscolaId",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "EscolaId",
                table: "Departamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EscolaId",
                table: "Departamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_EscolaId",
                table: "Departamento",
                column: "EscolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_Escola_EscolaId",
                table: "Departamento",
                column: "EscolaId",
                principalTable: "Escola",
                principalColumn: "EscolaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
