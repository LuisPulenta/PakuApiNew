using PakuApiNew.Web.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PakuApiNew.Web.Models;
using PakuApiNew.Web.Data.Entities;
using System;

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


        [HttpPut("{id}")]
        public async Task<IActionResult> PutModulo(int id, ModuloRequest request)
        {
            if (id != request.IdModulo)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Modulo modulo = await _dataContext.Modulos.FindAsync(request.IdModulo);
            if (modulo == null)
            {
                return BadRequest("El modulo no existe.");
            }

            modulo.NroVersion = request.NroVersion;
            modulo.FechaRelease = System.DateTime.Now;

            try
            {
                _dataContext.Modulos.Update(modulo);
                await _dataContext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}