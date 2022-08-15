using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumnado.BD.Migrations
{
    public partial class cambiop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "AlumnoDni_UQ",
                table: "Alumnos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "AlumnoDni_UQ",
                table: "Alumnos",
                column: "DNI",
                unique: true);
        }
    }
}
