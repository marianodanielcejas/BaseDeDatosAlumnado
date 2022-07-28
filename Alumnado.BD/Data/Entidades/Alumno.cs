using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnado.BD.Data.Entidades
{
    [Index(nameof(DNI), Name = "AlumnoDNI_UQ", IsUnique = true)]
    public class Alumno: EntityBase
    {
        [Required]
        [MaxLength(8, ErrorMessage = "El DNI del alumno no puede superar {1} caracteres")]
        public string DNI { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "El Nombre del alumno no puede superar {1} caracteres")]
        public string NombreAlumno { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage = "La Nota del alumno no puede superar {1} caracteres")]
        public string NotaAlumno { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdGrado { get; set; }

        public Grado Grado { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdInscripto { get; set; }

        public Inscripto Inscripto { get; set; }

        public string InformeAlumno { get; set; }
    }
}
