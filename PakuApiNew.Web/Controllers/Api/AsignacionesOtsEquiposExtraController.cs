
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PakuApiNew.Web.Data;
using PakuApiNew.Web.Data.Entities;
using PakuApiNew.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fleet_App.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesOtsEquiposExtraController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public AsignacionesOtsEquiposExtraController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsignacionesOtsEquiposExtra([FromBody] AsignacionesOtsEquiposExtra request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dataContext.AsignacionesOtsEquiposExtras.Add(request);
            await _dataContext.SaveChangesAsync();

            var newAsignacionesOtsEquiposExtra = await _dataContext
                .AsignacionesOtsEquiposExtras
                .Where(a => 
                    a.NROCLIENTE == request.NROCLIENTE 
                    && a.NROSERIEEXTRA == request.NROSERIEEXTRA)
                .ToListAsync();

            var response = new List<AsignacionesOtsEquiposExtraRequest>(newAsignacionesOtsEquiposExtra.Select(o => new AsignacionesOtsEquiposExtraRequest
            {
                CODDECO1=o.CODDECO1,
                FECHACARGA=o.FECHACARGA,
                IDASIGNACIONEXTRA = o.IDASIGNACIONEXTRA,
                IDGAOS=o.IDGAOS,
                IDTECNICO = o.IDTECNICO,
                NROCLIENTE=o.NROCLIENTE,
                NROSERIEEXTRA = o.NROSERIEEXTRA,
                ProyectoModulo = o.ProyectoModulo
            }).ToList());
            return Ok(response);
        }

        [HttpPost]
        [Route("GetEquiposExtra/{cliente}/{userId}/{proyectoModulo}")]
        public async Task<IActionResult> GetEquiposExtra(string cliente, int userId, string proyectoModulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            System.Collections.Generic.List<AsignacionesOtsEquiposExtra> equiposExtra = await _dataContext.AsignacionesOtsEquiposExtras
           .Where(o => (o.NROCLIENTE == cliente && o.IDTECNICO == userId && o.ProyectoModulo == proyectoModulo))
           .ToListAsync();
            return Ok(equiposExtra);
        }
    }
}