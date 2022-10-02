using Alumnado.BD.Data;
using Alumnado.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDatosAlumnado.Server.Controllers
{
    [ApiController] //Etiqueta para decir que este sera un controller.
    [Route("api/Materias")] //ruta para acceder a los recursos de este controller.
    public class MateriasController:ControllerBase
    {
        private readonly dbContext context;

        public MateriasController(dbContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Materia>>> Get()
        {
            //return await context.Materias.Include(a => a.Alumnos).ToListAsync();
            return await context.Materias.ToListAsync();
        }

        [HttpGet("{id:int}")] // por direccion quiero que me llegue un id.

        public async Task<ActionResult<Materia>> GetMateria(int id)
        {
            var materia = await context.Materias.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (materia == null)
            {
                return NotFound($"La materia con id {id} no existe");
            }
            return materia;
        }

        [HttpPost]

        public async Task<ActionResult<Materia>> Post(Materia materia)
        {
            try
            {
                context.Materias.Add(materia);
                await context.SaveChangesAsync();
                return materia;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, [FromBody] Materia materia)
        {
            if (id != materia.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var mat = context.Materias.Where(a => a.Id == id).FirstOrDefault();
            if (mat == null)
            {
                return NotFound("No existe la materia a modificar");
            }
            mat.CodMateria = materia.CodMateria;
            mat.NombreMateria = materia.NombreMateria;
            mat.FechaCreacion = materia.FechaCreacion;

            try
            {
                context.Materias.Update(mat);
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
            var mat = context.Materias.Where(a => a.Id == id).FirstOrDefault();

            if (mat == null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {
                context.Materias.Remove(mat);
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
