using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnado.BD.Data.Entidades
{
    [Index(nameof(DNI),(nameof(NombreCompletoAlumno)), Name = "NomAlumnoDni_UQ", IsUnique = true)]
    public class Alumno: EntityBase
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(8, ErrorMessage = "El DNI del alumno no puede superar {1} caracteres")]
        public string DNI { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(150, ErrorMessage = "El Nombre del alumno no puede superar {1} caracteres")]
        public string NombreCompletoAlumno { get; set; }

        public List<Nota> Notas { get; set; }

        public int? MateriaId { get; set; }

        public Materia Materia { get; set; }

    }
}
