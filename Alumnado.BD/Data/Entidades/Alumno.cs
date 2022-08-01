using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnado.BD.Data.Entidades
{
    [Index(nameof(DNI),nameof(Grado), Name = "AlumnoDniGrado_UQ", IsUnique = true)]
    public class Alumno: EntityBase
    {
        [Required]
        [MaxLength(8, ErrorMessage = "El DNI del alumno no puede superar {1} caracteres")]
        public string DNI { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "El Nombre del alumno no puede superar {1} caracteres")]
        public string NombreCompletoAlumno { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage = "La Nota del alumno no puede superar {1} caracteres")]
        public string NotasAlumno { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(30, ErrorMessage = "El grado del alumno no puede superar {1} caracteres")]
        public string Grado { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "La materia del alumno no puede superar {1} caracteres")]
        public string NombreMateriaCursada { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(100, ErrorMessage = "El grado del alumno no puede superar {1} caracteres")]
        public string InformeAlumno { get; set; }
    }
}
