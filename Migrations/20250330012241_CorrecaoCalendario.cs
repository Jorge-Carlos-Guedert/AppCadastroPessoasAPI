using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCadastroPessoasAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoCalendario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurarCalendarios");

            migrationBuilder.CreateTable(
                name: "Calendario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    PrimeiroDiaSemana = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataEspecificaCalendario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    CalendarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataEspecificaCalendario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataEspecificaCalendario_Calendario_CalendarioId",
                        column: x => x.CalendarioId,
                        principalTable: "Calendario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiaSemanaCalendario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalendarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaSemanaCalendario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaSemanaCalendario_Calendario_CalendarioId",
                        column: x => x.CalendarioId,
                        principalTable: "Calendario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vagas = table.Column<int>(type: "int", nullable: false),
                    DiaSemanaCalendarioId = table.Column<int>(type: "int", nullable: true),
                    DataEspecificaCalendarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horario_DataEspecificaCalendario_DataEspecificaCalendarioId",
                        column: x => x.DataEspecificaCalendarioId,
                        principalTable: "DataEspecificaCalendario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Horario_DiaSemanaCalendario_DiaSemanaCalendarioId",
                        column: x => x.DiaSemanaCalendarioId,
                        principalTable: "DiaSemanaCalendario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataEspecificaCalendario_CalendarioId",
                table: "DataEspecificaCalendario",
                column: "CalendarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaSemanaCalendario_CalendarioId",
                table: "DiaSemanaCalendario",
                column: "CalendarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_DataEspecificaCalendarioId",
                table: "Horario",
                column: "DataEspecificaCalendarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_DiaSemanaCalendarioId",
                table: "Horario",
                column: "DiaSemanaCalendarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "DataEspecificaCalendario");

            migrationBuilder.DropTable(
                name: "DiaSemanaCalendario");

            migrationBuilder.DropTable(
                name: "Calendario");

            migrationBuilder.CreateTable(
                name: "ConfigurarCalendarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    DiaMes = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurarCalendarios", x => x.Id);
                });
        }
    }
}
