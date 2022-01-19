using Microsoft.AspNetCore.Mvc;
using PakuApiNew.Web.Data;
using PakuApiNew.Web.Data.Entities;
using System.Threading.Tasks;

namespace PakuApiNew.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguimientosController : ControllerBase
    {
        private readonly DataContext _context;
        public SeguimientosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Seguimiento>> PostSeguimiento(Seguimiento request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.p_Seguimiento.Add(request);
            await _context.SaveChangesAsync();
            return Ok(request);
        }
    }
}