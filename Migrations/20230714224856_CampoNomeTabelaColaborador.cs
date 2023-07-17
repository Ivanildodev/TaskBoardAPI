using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardAPI.Migrations
{
    /// <inheritdoc />
    public partial class CampoNomeTabelaColaborador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Colaborador",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Colaborador");
        }
    }
}
