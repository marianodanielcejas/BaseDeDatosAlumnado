using Alumnado.BD.Data;
using Alumnado.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDatosAlumnado.Server.Controllers
{
    [ApiController] //Etiqueta para decir que este sera un controller.
    [Route("api/Alumnos")] //ruta para acceder a los recursos de este controller.
    public class AlumnosController : ControllerBase
    {
        private readonly dbContext context;//propiedad readonly context.

        public AlumnosController(dbContext context)//El context representa la base de datos por eso se lo paso como argumento a alumnoscontroller.
        {
            this.context = context;
        }

        [HttpGet]

        public async Task <ActionResult<List<Alumno>>>Get()
        {
            return await context.Alumnos.ToListAsync();
        }

        [HttpGet("{id:int}")] // por direccion quiero que me llegue un id.

        public async Task<ActionResult<Alumno>> GetAlumno(int id)
        {
            var alumno = await context.Alumnos.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (alumno == null)
            {
                return NotFound($"El alumno que ingreso con id {id} no esta matriculado en el establecimiento");
            }
            return alumno;
        }

        [HttpPost]

        public async Task<ActionResult<Alumno>> Post(Alumno alumno)
        {
            try
            {
                context.Alumnos.Add(alumno);
                await context.SaveChangesAsync();
                return alumno;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, [FromBody] Alumno alumno)
        {
            if( id != alumno.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var alum = context.Alumnos.Where (a => a.Id == id).FirstOrDefault();
            if(alum == null)
            {
                return NotFound("No existe el alumno a modificar");
            }
            alum.DNI = alumno.DNI;
            alum.NombreCompletoAlumno = alumno.NombreCompletoAlumno;
            alum.FechaCreacion = alumno.FechaCreacion;

            try
            {
                context.Alumnos.Update(alum);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Los datos no han sido actualizados");
            }
           
            
        }

        [HttpDelete("{id:int}")]

        public ActionResult Delete(int id)
        {
            var alum = context.Alumnos.Where(a => a.Id == id).FirstOrDefault();

            if(alum == null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {
                context.Alumnos.Remove(alum);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest($"Los datos no pudieron eliminarse por :{e.Message}");
            }
            
        }
    }
}
