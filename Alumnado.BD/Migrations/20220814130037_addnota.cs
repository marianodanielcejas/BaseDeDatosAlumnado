using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumnado.BD.Migrations
{
    public partial class addnota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Alumnos_AlumnoId",
                table: "Notas");

            migrationBuilder.AlterColumn<int>(
                name: "AlumnoId",
                table: "Notas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Alumnos_AlumnoId",
                table: "Notas",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Alumnos_AlumnoId",
                table: "Notas");

            migrationBuilder.AlterColumn<int>(
                name: "AlumnoId",
                table: "Notas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Alumnos_AlumnoId",
                table: "Notas",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id");
        }
    }
}
