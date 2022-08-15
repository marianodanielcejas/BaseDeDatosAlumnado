using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumnado.BD.Migrations
{
    public partial class cambiosbd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "AlumnoDniNombre_UQ",
                table: "Alumnos");

            migrationBuilder.AlterColumn<string>(
                name: "NotaAlum",
                table: "Notas",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2);

            migrationBuilder.CreateIndex(
                name: "AlumnoDni_UQ",
                table: "Alumnos",
                column: "DNI",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "AlumnoDni_UQ",
                table: "Alumnos");

            migrationBuilder.AlterColumn<int>(
                name: "NotaAlum",
                table: "Notas",
                type: "int",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.CreateIndex(
                name: "AlumnoDniNombre_UQ",
                table: "Alumnos",
                columns: new[] { "DNI", "NombreCompletoAlumno" },
                unique: true);
        }
    }
}
