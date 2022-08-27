using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumnado.BD.Migrations
{
    public partial class cu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "NomAlumnoDni_UQ",
                table: "Alumnos",
                columns: new[] { "DNI", "NombreCompletoAlumno" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "NomAlumnoDni_UQ",
                table: "Alumnos");
        }
    }
}
