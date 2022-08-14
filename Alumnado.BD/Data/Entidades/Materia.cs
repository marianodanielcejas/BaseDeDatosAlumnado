using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnado.BD.Data.Entidades
{
    [Index(nameof(CodMateria), Name = "CodigoMateria_UQ", IsUnique = true)]
    public class Materia:EntityBase
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(3, ErrorMessage = "El Codigo de la materia no puede superar {1} caracteres")]
        public string CodMateria { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(15, ErrorMessage = "El Nombre de la materia no puede superar {1} caracteres")]
        public string NombreMateria { get; set; }

        public List<Alumno> Alumnos { get; set; }
    }
}
