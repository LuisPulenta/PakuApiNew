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
    }
}