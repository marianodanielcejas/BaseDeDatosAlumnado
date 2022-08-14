using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnado.BD.Data.Entidades
{
    public class Nota:EntityBase
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(2, ErrorMessage = "La nota del alumno no puede superar {1} caracteres")]
        public int NotaAlum { get; set; }

        public int AlumnoId { get; set; }

        public Alumno Alumno { get; set; }
    }
}
