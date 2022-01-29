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
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UsuariosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            System.Collections.Generic.List<Usuario> usuarios = await _dataContext.SubContratistasUsrWebs
           .Where (o=> (o.CODIGO=="PQ" || o.CODIGO == "TR") && (o.HabilitadoWeb==1)) 
           .ToListAsync();
            return Ok(usuarios);
        }

        [HttpPost]
        [Route("GetRutas/{IDUser}")]
        public async Task<IActionResult> GetRutas(int IDUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var rutas = await _dataContext.p_Rutas2
                .Include (p => p.Paradas)
                .Include(e => e.Envios)
           .Where(o => (o.IDUser == IDUser) && (o.Estado == 0))

           .OrderBy(o => o.IDRuta)
           .ToListAsync();


            if (rutas == null)
            {
                return BadRequest("No hay Rutas.");
            }
            return Ok(rutas);
        }

        [HttpPost]
        [Route("GetTiposAsignaciones/{UserID}")]
        public async Task<IActionResult> GetTiposAsignaciones(int UserID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var tipos = await _dataContext.AsignacionesOTs
                
           .Where(o => (o.UserID == UserID) && (o.ESTADOGAOS != "EJB"))
           .OrderBy(o => o.PROYECTOMODULO)
           .GroupBy(r => new
           {
               r.PROYECTOMODULO,
           })
           .Select(g => new
           {
               PROYECTOMODULO = g.Key.PROYECTOMODULO,
           }).ToListAsync();


            if (tipos == null)
            {
                return BadRequest("No hay Asignaciones para este Usuario.");
            }

            return Ok(tipos);
        }
    }
}