using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumnado.BD.Migrations
{
    public partial class NuevosCambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_Alumnos_InscriptoId",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "InscriptoId",
                table: "Alumnos");

            migrationBuilder.AlterColumn<int>(
                name: "GradoId",
                table: "Inscriptos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoAlumnoMatriculado",
                table: "Inscriptos",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlumnoId",
                table: "Inscriptos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "AlumnoGradoId_UQ",
                table: "Inscriptos",
                columns: new[] { "AlumnoId", "GradoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptos_AlumnoId",
                table: "Inscriptos",
                column: "AlumnoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptos_Alumnos_AlumnoId",
                table: "Inscriptos",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptos_Grados_GradoId",
                table: "Inscriptos",
                column: "GradoId",
                principalTable: "Grados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptos_Alumnos_AlumnoId",
                table: "Inscriptos");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptos_Grados_GradoId",
                table: "Inscriptos");

            migrationBuilder.DropIndex(
                name: "AlumnoGradoId_UQ",
                table: "Inscriptos");

            migrationBuilder.DropIndex(
                name: "IX_Inscriptos_AlumnoId",
                table: "Inscriptos");

            migrationBuilder.DropColumn(
                name: "AlumnoId",
                table: "Inscriptos");

            migrationBuilder.AlterColumn<int>(
                name: "GradoId",
                table: "Inscriptos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoAlumnoMatriculado",
                table: "Inscriptos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

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
                name: "IX_Alumnos_InscriptoId",
                table: "Alumnos",
                column: "InscriptoId");

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
    }
}
