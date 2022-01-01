using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PakuApiNew.Web.Data;
using PakuApiNew.Web.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PakuApiNew.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParadasController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ParadasController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("GetParadas/{IdRuta}")]
        public async Task<IActionResult> GetParadas(int IdRuta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            System.Collections.Generic.List<Parada> paradas = await _dataContext.p_Paradas
            .Where(o => (o.IdRuta == IdRuta))
           .OrderBy(o => o.Secuencia)
           .ToListAsync();

            if (paradas == null)
            {
                return BadRequest("No hay Paradas para esta Ruta.");
            }

            return Ok(paradas);
        }
    }
}
