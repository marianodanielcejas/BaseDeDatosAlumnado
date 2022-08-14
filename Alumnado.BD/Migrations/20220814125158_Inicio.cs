﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumnado.BD.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodMateria = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NombreMateria = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    NombreCompletoAlumno = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alumnos_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotaAlum = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    AlumnoId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "AlumnoDniNombre_UQ",
                table: "Alumnos",
                columns: new[] { "DNI", "NombreCompletoAlumno" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_MateriaId",
                table: "Alumnos",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "CodigoMateria_UQ",
                table: "Materia",
                column: "CodMateria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_AlumnoId",
                table: "Notas",
                column: "AlumnoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Materia");
        }
    }
}
