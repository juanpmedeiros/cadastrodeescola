using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PontoIdAPI.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escola",
                columns: table => new
                {
                    EscolaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEscola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BairroEscola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CidadeEscola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoEscola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CepEscola = table.Column<int>(type: "int", nullable: false),
                    ComplementoEscola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefoneEscola = table.Column<int>(type: "int", nullable: false),
                    LogoEscola = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escola", x => x.EscolaId);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurmaNumero = table.Column<int>(type: "int", nullable: false),
                    PeriodoAula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EscolaId = table.Column<int>(type: "int", nullable: false),
                    QuantidadeAlunos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.TurmaId);
                    table.ForeignKey(
                        name: "FK_Turma_Escola_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escola",
                        principalColumn: "EscolaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAluno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdadeAluno = table.Column<int>(type: "int", nullable: false),
                    EnderecoAluno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsavelAluno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefoneAluno = table.Column<int>(type: "int", nullable: false),
                    Maioridade = table.Column<bool>(type: "bit", nullable: false),
                    FotoAluno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.AlunoId);
                    table.ForeignKey(
                        name: "FK_Alunos_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turma",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_EscolaId",
                table: "Turma",
                column: "EscolaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Escola");
        }
    }
}
