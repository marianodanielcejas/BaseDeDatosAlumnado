using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumnado.BD.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    NombreCompletoAlumno = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NotasAlumno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Grado = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NombreMateriaCursada = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    InformeAlumno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "AlumnoDniGrado_UQ",
                table: "Alumnos",
                columns: new[] { "DNI", "Grado" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos");
        }
    }
}
