﻿// <auto-generated />
using System;
using Alumnado.BD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Alumnado.BD.Migrations
{
    [DbContext(typeof(dbContext))]
    partial class dbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Alumnado.BD.Data.Entidades.Alumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<string>("NombreCompletoAlumno")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("MateriaId");

                    b.HasIndex(new[] { "DNI", "NombreCompletoAlumno" }, "AlumnoDniNombre_UQ")
                        .IsUnique();

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("Alumnado.BD.Data.Entidades.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodMateria")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreMateria")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CodMateria" }, "CodigoMateria_UQ")
                        .IsUnique();

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("Alumnado.BD.Data.Entidades.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("NotaAlum")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("Alumnado.BD.Data.Entidades.Alumno", b =>
                {
                    b.HasOne("Alumnado.BD.Data.Entidades.Materia", "Materia")
                        .WithMany("Alumnos")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("Alumnado.BD.Data.Entidades.Nota", b =>
                {
                    b.HasOne("Alumnado.BD.Data.Entidades.Alumno", "Alumno")
                        .WithMany("Notas")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");
                });

            modelBuilder.Entity("Alumnado.BD.Data.Entidades.Alumno", b =>
                {
                    b.Navigation("Notas");
                });

            modelBuilder.Entity("Alumnado.BD.Data.Entidades.Materia", b =>
                {
                    b.Navigation("Alumnos");
                });
#pragma warning restore 612, 618
        }
    }
}
