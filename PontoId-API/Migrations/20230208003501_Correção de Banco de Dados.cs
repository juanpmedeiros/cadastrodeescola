using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PontoIdAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorreçãodeBancodeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EscolaId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EscolaId",
                table: "Alunos");
        }
    }
}
