using Alumnado.BD.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnado.BD.Data
{
    public class pepe : DbContext
    {
        public DbSet <Alumno> Alumnos { get; set; }

        public DbSet<Grado> Grados { get; set; }

        public DbSet<Inscripto> Inscriptos { get; set; }


        public pepe(DbContextOptions options) : base(options)
        {
        }
    }
}
