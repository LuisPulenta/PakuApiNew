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

        [HttpGet("GetEnvioByID/{ID}")]
        public async Task<ActionResult<Data.Entities.Envio>> GetEnvioByID(int ID)
        {
            Data.Entities.Envio envio = await _dataContext.p_Envios
                .FirstOrDefaultAsync(o => (o.ID == ID));
            if (envio == null)
            {
                return NotFound();
            }
            return envio;
        }
    }
}