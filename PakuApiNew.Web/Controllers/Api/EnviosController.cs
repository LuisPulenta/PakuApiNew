using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PakuApiNew.Web.Data;
using PakuApiNew.Web.Data.Entities;
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

        [HttpGet("{ID}")]
        public async Task<ActionResult<Envio>> GetEnvio(int ID)
        {
            Envio envio = await _dataContext.p_Envios
           .FirstOrDefaultAsync(x => x.ID == ID);
            if (envio == null)
            {
                return BadRequest("El IdEnvio no corresponde a ningún envío.");
            }
            return Ok(envio);
        }
    }
}