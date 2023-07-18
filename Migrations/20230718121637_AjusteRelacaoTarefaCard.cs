using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacaoTarefaCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tarefa_CardId",
                table: "Tarefa");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_CardId",
                table: "Tarefa",
                column: "CardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tarefa_CardId",
                table: "Tarefa");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_CardId",
                table: "Tarefa",
                column: "CardId",
                unique: true);
        }
    }
}
