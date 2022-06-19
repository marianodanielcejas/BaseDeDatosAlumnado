using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnado.BD.Data.Entidades
{
    [Index(nameof(CodigoGrado), Name = "GradoCodigo_UQ", IsUnique = true)]
    public class Grado:EntityBase
    {
        [Required]
        [MaxLength(7, ErrorMessage = "El Grado del alumno no puede superar {1} caracteres")]
        public string CodigoGrado { get; set; }


        [Required]
        [MaxLength(150, ErrorMessage = "La materia del alumno no puede superar {1} caracteres")]
        public string NombreMateria { get; set; }

        public List <Inscripto> Inscriptos { get; set; }

        public List <Alumno> Alumnos { get; set; }
    }
}
