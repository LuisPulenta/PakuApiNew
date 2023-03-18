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
    public class Vista_AcumuladosEquiposSinDevolversController : ControllerBase
    {
        private readonly DataContext _dataContext;
        

        public Vista_AcumuladosEquiposSinDevolversController(DataContext dataContext)
        {
            _dataContext = dataContext;
            
        }

        [HttpGet("GetEquiposSinDevolver/{iduser}")]
        public async Task<IActionResult> GetEquiposSinDevolver(int iduser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            System.Collections.Generic.List<Vista_AcumuladosEquiposSinDevolver> equiposSinDevolver = await _dataContext.Vista_AcumuladosEquiposSinDevolver
                .Where(o => o.UserID == iduser)
           .ToListAsync();

            if (equiposSinDevolver.Count>0)
            {
                return Ok(equiposSinDevolver[0]);
            }
            else
            {
                return Ok();
            }
        }
    }
}