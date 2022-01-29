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

        [HttpPost]
        [Route("GetAsignaciones/{UserID}/{ProyectoModulo}")]
        public async Task<IActionResult> GetAsignaciones(int UserID, string ProyectoModulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var orders = await _dataContext.AsignacionesOTs

           .Where(o => (o.UserID == UserID)
                        && (o.PROYECTOMODULO == ProyectoModulo)
                        && (o.ESTADOGAOS == "PEN" || o.ESTADOGAOS == "INC" && o.CodigoCierre != 44 && o.CodigoCierre <= 50 && o.CodigoCierre > 40)
                        )
           .OrderBy(o => o.RECUPIDJOBCARD)
           .GroupBy(r => new
           {
               r.RECUPIDJOBCARD,
               r.CLIENTE,
               r.NOMBRE,
               r.DOMICILIO,
               r.CP,
               r.ENTRECALLE1,
               r.ENTRECALLE2,
               r.LOCALIDAD,
               r.TELEFONO,
               r.GRXX,
               r.GRYY,
               r.ESTADOGAOS,
               r.PROYECTOMODULO,
               r.UserID,
               r.CAUSANTEC,
               r.SUBCON,
               r.FechaAsignada,
               r.CodigoCierre,
               r.Novedades,
               r.PROVINCIA,
               r.ReclamoTecnicoID,
               r.FechaCita,
               r.MedioCita,
               r.NroSeriesExtras,
               r.Evento1,
               r.FechaEvento1,
               r.Evento2,
               r.FechaEvento2,
               r.Evento3,
               r.FechaEvento3,
               r.Evento4,
               r.FechaEvento4,
               r.Observacion,
               r.TelefAlternativo1,
               r.TelefAlternativo2,
               r.TelefAlternativo3,
               r.TelefAlternativo4
           })
           .Select(g => new
           {
               RECUPIDJOBCARD = g.Key.RECUPIDJOBCARD,
               CLIENTE = g.Key.CLIENTE,
               NOMBRE = g.Key.NOMBRE,
               DOMICILIO = g.Key.DOMICILIO,
               CP = g.Key.CP,
               ENTRECALLE1 = g.Key.ENTRECALLE1,
               ENTRECALLE2 = g.Key.ENTRECALLE2,
               LOCALIDAD = g.Key.LOCALIDAD,
               TELEFONO = g.Key.TELEFONO,
               GRXX = g.Key.GRXX,
               GRYY = g.Key.GRYY,
               ESTADOGAOS = g.Key.ESTADOGAOS,
               PROYECTOMODULO = g.Key.PROYECTOMODULO,
               UserID = g.Key.UserID,
               CAUSANTEC = g.Key.CAUSANTEC,
               SUBCON = g.Key.SUBCON,
               FechaAsignada = g.Key.FechaAsignada,
               CodigoCierre = g.Key.CodigoCierre,
               Novedades = g.Key.Novedades,
               PROVINCIA = g.Key.PROVINCIA,
               ReclamoTecnicoID = g.Key.ReclamoTecnicoID,
               FechaCita = g.Key.FechaCita,
               MedioCita = g.Key.MedioCita,
               NroSeriesExtras = g.Key.NroSeriesExtras,
               Evento1 = g.Key.Evento1,
               FechaEvento1 = g.Key.FechaEvento1,
               Evento2 = g.Key.Evento2,
               FechaEvento2 = g.Key.FechaEvento2,
               Evento3 = g.Key.Evento3,
               FechaEvento3 = g.Key.FechaEvento3,
               Evento4 = g.Key.Evento4,
               FechaEvento4 = g.Key.FechaEvento4,
               Observacion = g.Key.Observacion,
               TelefAlternativo1 = g.Key.TelefAlternativo1,
               TelefAlternativo2 = g.Key.TelefAlternativo2,
               TelefAlternativo3 = g.Key.TelefAlternativo3,
               TelefAlternativo4 = g.Key.TelefAlternativo4,

               CantAsign = g.Count(),
           }).ToListAsync();


            if (orders == null)
            {
                return BadRequest("No hay Asignaciones para este Usuario.");
            }

            return Ok(orders);
        }
    }
}