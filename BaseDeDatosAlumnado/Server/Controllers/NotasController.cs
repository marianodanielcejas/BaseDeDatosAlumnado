using Alumnado.BD.Data;
using Alumnado.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDatosAlumnado.Server.Controllers
{
    [ApiController] //Etiqueta para decir que este sera un controller.
    [Route("api/Notas")] //ruta para acceder a los recursos de este controller.
    public class NotasController:ControllerBase
    {
        private readonly dbContext context;

        public NotasController(dbContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Nota>>> Get()
        {
            //return await context.Notas.Include(a => a.Alumno).ToListAsync();
            return await context.Notas.ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult<Nota>> Post(Nota nota)
        {
            try
            {
                context.Notas.Add(nota);
                await context.SaveChangesAsync();
                return nota;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, [FromBody] Nota nota)
        {
            if (id != nota.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var not = context.Notas.Where(a => a.Id == id).FirstOrDefault();
            if (not == null)
            {
                return NotFound("No existe la Nota a modificar");
            }

            not.NotaAlum = nota.NotaAlum;
            

            try
            {
                context.Notas.Update(not);
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
            var not = context.Notas.Where(a => a.Id == id).FirstOrDefault();

            if (not == null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {
                context.Notas.Remove(not);
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
