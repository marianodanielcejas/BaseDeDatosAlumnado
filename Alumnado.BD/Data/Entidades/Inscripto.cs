using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnado.BD.Data.Entidades
{
    [Index(nameof(AlumnoId),(nameof(GradoId)), Name = "AlumnoGradoId_UQ", IsUnique = true)]
    public class Inscripto:EntityBase
    {
        [Required(ErrorMessage = "El Código del alumno matriculado es obligatorio")]
        [MaxLength(5, ErrorMessage = "El Código del alumno matriculado no puede superar {1} caracteres")]
        public string CodigoAlumnoMatriculado { get; set; }

        [Required(ErrorMessage = "El alumno es obligatorio")]
        public  int AlumnoId { get; set; }

        public Alumno Alumno { get; set; }

        [Required(ErrorMessage = "El Grado es obligatorio")]

        public int GradoId { get; set; }

        public Grado Grado { get; set; }
    }
}
