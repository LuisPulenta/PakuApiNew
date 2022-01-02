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
    public class EnviosController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public EnviosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("GetEnvios/{IdRuta}")]
        public async Task<IActionResult> GetEnvios(int IdRuta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            System.Collections.Generic.List<Envio> envios = await _dataContext.p_Envios
            .Where(o => (o.NroRuta == IdRuta))
           .OrderBy(o => o.ID)
           .ToListAsync();

            if (envios == null)
            {
                return BadRequest("No hay Envíos para esta Ruta.");
            }

            return Ok(envios);
        }
    }
}