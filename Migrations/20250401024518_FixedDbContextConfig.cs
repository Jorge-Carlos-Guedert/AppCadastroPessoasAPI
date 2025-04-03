using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCadastroPessoasAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixedDbContextConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatasEspecificas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.CheckConstraint("CK_Horario_Exclusividade", "CASE WHEN [DiaSemanaCalendarioId] IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN [DataEspecificaCalendarioId] IS NOT NULL THEN 1 ELSE 0 END = 1");
                    table.ForeignKey(
                        name: "FK_Horarios_DatasEspecificas_DataEspecificaCalendarioId",
                        column: x => x.DataEspecificaCalendarioId,
                        principalTable: "DatasEspecificas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Horarios_DiasSemana_DiaSemanaCalendarioId",
                        column: x => x.DiaSemanaCalendarioId,
                        principalTable: "DiasSemana",
                        principalColumn: "Id");
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
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "DatasEspecificas");

            migrationBuilder.DropTable(
                name: "DiasSemana");

            migrationBuilder.DropTable(
                name: "Calendario");
        }
    }
}
