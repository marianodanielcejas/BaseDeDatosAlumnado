using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumnado.BD.Migrations
{
    public partial class cambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CodigoAlumnoMatriculado",
                table: "Inscriptos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradoId",
                table: "Inscriptos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradoId",
                table: "Alumnos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InscriptoId",
                table: "Alumnos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "CodAlumnoMat_UQ",
                table: "Inscriptos",
                column: "CodigoAlumnoMatriculado",
                unique: true,
                filter: "[CodigoAlumnoMatriculado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptos_GradoId",
                table: "Inscriptos",
                column: "GradoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_GradoId",
                table: "Alumnos",
                column: "GradoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_InscriptoId",
                table: "Alumnos",
                column: "InscriptoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Grados_GradoId",
                table: "Alumnos",
                column: "GradoId",
                principalTable: "Grados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Inscriptos_InscriptoId",
                table: "Alumnos",
                column: "InscriptoId",
                principalTable: "Inscriptos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptos_Grados_GradoId",
                table: "Inscriptos",
                column: "GradoId",
                principalTable: "Grados",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Grados_GradoId",
                table: "Alumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Inscriptos_InscriptoId",
                table: "Alumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptos_Grados_GradoId",
                table: "Inscriptos");

            migrationBuilder.DropIndex(
                name: "CodAlumnoMat_UQ",
                table: "Inscriptos");

            migrationBuilder.DropIndex(
                name: "IX_Inscriptos_GradoId",
                table: "Inscriptos");

            migrationBuilder.DropIndex(
                name: "IX_Alumnos_GradoId",
                table: "Alumnos");

            migrationBuilder.DropIndex(
                name: "IX_Alumnos_InscriptoId",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "GradoId",
                table: "Inscriptos");

            migrationBuilder.DropColumn(
                name: "GradoId",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "InscriptoId",
                table: "Alumnos");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoAlumnoMatriculado",
                table: "Inscriptos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
