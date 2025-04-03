using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCadastroPessoasAPI.Migrations
{
    /// <inheritdoc />
    public partial class NullableHorario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Horario_Exclusividade",
                table: "Horarios");

            migrationBuilder.AlterColumn<int>(
                name: "DiaSemanaCalendarioId",
                table: "Horarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DataEspecificaCalendarioId",
                table: "Horarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DiaSemanaCalendarioId",
                table: "Horarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DataEspecificaCalendarioId",
                table: "Horarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Horario_Exclusividade",
                table: "Horarios",
                sql: "CASE WHEN [DiaSemanaCalendarioId] IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN [DataEspecificaCalendarioId] IS NOT NULL THEN 1 ELSE 0 END = 1");
        }
    }
}
