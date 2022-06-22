using PakuApiNew.Web.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fleet_App.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulosController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ModulosController(DataContext dataContext)


        {
            _dataContext = dataContext;
        }
        
        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModulo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modulo = await _dataContext.Modulos.FindAsync(id);

            if (modulo == null)
            {
                return NotFound();
            }
            return Ok(modulo);
        }
    }
}