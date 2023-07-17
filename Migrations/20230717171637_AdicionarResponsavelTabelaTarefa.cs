using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarResponsavelTabelaTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResponsavelId",
                table: "Tarefa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ResponsavelId",
                table: "Tarefa",
                column: "ResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Colaborador_ResponsavelId",
                table: "Tarefa",
                column: "ResponsavelId",
                principalTable: "Colaborador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Colaborador_ResponsavelId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_ResponsavelId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "ResponsavelId",
                table: "Tarefa");
        }
    }
}
