using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCadastroPessoasAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "DataEspecificaCalendario");

            migrationBuilder.DropTable(
                name: "DiaSemanaCalendario");

            migrationBuilder.CreateTable(
                name: "DatasEspecificas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    CalendarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatasEspecificas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatasEspecificas_Calendario_CalendarioId",
                        column: x => x.CalendarioId,
                        principalTable: "Calendario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiasSemana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalendarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasSemana", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiasSemana_Calendario_CalendarioId",
                        column: x => x.CalendarioId,
                        principalTable: "Calendario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vagas = table.Column<int>(type: "int", nullable: false),
                    DiaSemanaCalendarioId = table.Column<int>(type: "int", nullable: false),
                    DataEspecificaCalendarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horarios_DatasEspecificas_DataEspecificaCalendarioId",
                        column: x => x.DataEspecificaCalendarioId,
                        principalTable: "DatasEspecificas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Horarios_DiasSemana_DiaSemanaCalendarioId",
                        column: x => x.DiaSemanaCalendarioId,
                        principalTable: "DiasSemana",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatasEspecificas_CalendarioId",
                table: "DatasEspecificas",
                column: "CalendarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DiasSemana_CalendarioId",
                table: "DiasSemana",
                column: "CalendarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_DataEspecificaCalendarioId",
                table: "Horarios",
                column: "DataEspecificaCalendarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_DiaSemanaCalendarioId",
                table: "Horarios",
                column: "DiaSemanaCalendarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "DatasEspecificas");

            migrationBuilder.DropTable(
                name: "DiasSemana");

            migrationBuilder.CreateTable(
                name: "DataEspecificaCalendario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarioId = table.Column<int>(type: "int", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false)
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
                    CalendarioId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    DataEspecificaCalendarioId = table.Column<int>(type: "int", nullable: true),
                    DiaSemanaCalendarioId = table.Column<int>(type: "int", nullable: true),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vagas = table.Column<int>(type: "int", nullable: false)
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
    }
}
