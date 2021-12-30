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
    public class RutasController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public RutasController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("GetRutas/{IdFletero}")]
        public async Task<IActionResult> GetRutas(int IdFletero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            System.Collections.Generic.List<Ruta> rutas = await _dataContext.p_Rutas
            .Where(o => (o.IdFletero == IdFletero) && (o.Estado == 0))
           .OrderBy(o => o.FechaAlta)
           .ToListAsync();

            if (rutas == null)
            {
                return BadRequest("No hay Rutas para este Fletero.");
            }

            return Ok(rutas);
        }
    }
}
