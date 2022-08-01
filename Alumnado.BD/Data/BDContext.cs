using Alumnado.BD.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnado.BD.Data
{
    public class dbContext : DbContext
    {
        public DbSet <Alumno> Alumnos { get; set; }

        public dbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
