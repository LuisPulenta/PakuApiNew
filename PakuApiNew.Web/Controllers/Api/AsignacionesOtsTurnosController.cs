using PakuApiNew.Web.Data;
using PakuApiNew.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace PakuApiNew.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesOtsTurnosController : ControllerBase
    {
        private readonly DataContext _dataContext;
        

        public AsignacionesOtsTurnosController(DataContext dataContext)
        {
            _dataContext = dataContext;
            
        }

        [HttpGet("GetTurnos/{iduser}")]
        public async Task<IActionResult> GetTurnos(int iduser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            System.Collections.Generic.List<AsignacionesOtsTurno> turnos = await _dataContext.AsignacionesOtsTurnos
                .Where(o => o.IdUser == iduser && o.Concluido!="SI")
           .ToListAsync();

            if (turnos.Count>0)
            {
                return Ok(turnos[0]);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostTurno([FromBody] AsignacionesOtsTurno request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dataContext.AsignacionesOtsTurnos.Add(request);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        [Route("PutTurno")]
        public async Task<IActionResult> PutTurno([FromRoute] int id, [FromBody] AsignacionesOtsTurno request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.IDTurno)
            {
                return BadRequest();
            }

            AsignacionesOtsTurno oldTurno = await _dataContext.AsignacionesOtsTurnos
                .FirstOrDefaultAsync(t => t.IDTurno == request.IDTurno);

            if (oldTurno == null)
            {
                return BadRequest("Turno no existe.");
            }

            oldTurno.Concluido = request.Concluido;

            _dataContext.AsignacionesOtsTurnos.Update(oldTurno);
            await _dataContext.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurno(int id)
        {
            AsignacionesOtsTurno turno = await _dataContext.AsignacionesOtsTurnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }

            _dataContext.AsignacionesOtsTurnos.Remove(turno);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }
    }
}