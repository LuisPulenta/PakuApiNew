using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PakuApiNew.Web.Data;
using PakuApiNew.Web.Data.Entities;
using PakuApiNew.Web.Models;
using System;
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
           .Where(o => (o.CODIGO == "PQ" || o.CODIGO == "TR") && (o.HabilitadoWeb == 1))
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
                .Include(p => p.Paradas)
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

            var tipos = await _dataContext.AsignacionesOTs2

           .Where(o => (o.UserID == UserID) && (o.ESTADOGAOS != "EJB") && (o.CierraEnAPP == 0) && (o.NoMostrarAPP == 0))
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
        [Route("GetZonas/{UserID}/{ProyectoModulo}")]
        public async Task<IActionResult> GetZonas(int UserID, string ProyectoModulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var zonas = await _dataContext.AsignacionesOTs2

           .Where(o => (o.UserID == UserID) && (o.ESTADOGAOS != "EJB") && (o.CierraEnAPP == 0) && (o.NoMostrarAPP == 0) && (o.PROYECTOMODULO == ProyectoModulo))
           .OrderBy(o => o.ZONA)
           .GroupBy(r => new
           {
               r.ZONA,
           })
           .Select(g => new
           {
               ZONA = g.Key.ZONA,
           }).ToListAsync();


            if (zonas == null)
            {
                return BadRequest("No hay Zonas para este ProyectoModulo.");
            }

            return Ok(zonas);
        }


        [HttpPost]
        [Route("GetCarteras/{UserID}/{ProyectoModulo}")]
        public async Task<IActionResult> GetCarteras(int UserID, string ProyectoModulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var zonas = await _dataContext.AsignacionesOTs2

           .Where(o => (o.UserID == UserID) && (o.ESTADOGAOS != "EJB") && (o.CierraEnAPP == 0) && (o.NoMostrarAPP == 0) && (o.PROYECTOMODULO == ProyectoModulo))
           .OrderBy(o => o.ZONA)
           .GroupBy(r => new
           {
               r.Motivos,
           })
           .Select(g => new
           {
               Motivos = g.Key.Motivos,
           }).ToListAsync();


            if (zonas == null)
            {
                return BadRequest("No hay Carteras para este ProyectoModulo.");
            }

            return Ok(zonas);
        }

        [HttpPost]
        [Route("GetAsignaciones/{UserID}/{ProyectoModulo}")]
        public async Task<IActionResult> GetAsignaciones(int UserID, string ProyectoModulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (ProyectoModulo=="Cable")
            {
                var orders = await _dataContext.AsignacionesOTs2

           .Where(o => (o.UserID == UserID)
                        && (o.PROYECTOMODULO == ProyectoModulo)
                        && (o.CierraEnAPP == 0) && (o.NoMostrarAPP == 0)
                        && (o.BAJASISTEMA == 0)
                        && (o.ESTADOGAOS != "EJB")
                        )
           .OrderBy(o => o.RECUPIDJOBCARD)
           .GroupBy(r => new
           {
               r.RECUPIDJOBCARD,
               r.CLIENTE,
               r.Documento,
               r.NOMBRE,
               r.DOMICILIO,
               r.CP,
               r.ENTRECALLE1,
               r.ENTRECALLE2,
               r.Partido,
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
               r.DESCRIPCION,
               r.CierraEnAPP,
               r.NoMostrarAPP,
               r.Novedades,
               r.PROVINCIA,
               r.ReclamoTecnicoID,
               r.Motivos,
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
               r.TelefAlternativo4,
               //r.ObservacionCaptura,
               r.ZONA,
               //r.ModificadoApp
           })
           .Select(g => new
           {
               RECUPIDJOBCARD = g.Key.RECUPIDJOBCARD,
               CLIENTE = g.Key.CLIENTE,
               Documento = g.Key.Documento,
               NOMBRE = g.Key.NOMBRE,
               DOMICILIO = g.Key.DOMICILIO,
               CP = g.Key.CP,
               ENTRECALLE1 = g.Key.ENTRECALLE1,
               ENTRECALLE2 = g.Key.ENTRECALLE2,
               Partido = g.Key.Partido,
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
               DESCRIPCION = g.Key.DESCRIPCION,
               CierraEnAPP = g.Key.CierraEnAPP,
               NoMostrarAPP = g.Key.NoMostrarAPP,
               Novedades = g.Key.Novedades,
               PROVINCIA = g.Key.PROVINCIA,
               ReclamoTecnicoID = g.Key.ReclamoTecnicoID,
               Motivos = g.Key.Motivos,
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
               //ObservacionCaptura=g.Key.ObservacionCaptura,
               ZONA = g.Key.ZONA,
               //ModificadoApp = g.Key.ModificadoApp,


               CantAsign = g.Count(),
           })
        .ToListAsync();


                if (orders == null)
                {
                    return BadRequest("No hay Asignaciones para este Usuario.");
                }

                return Ok(orders);
            }
            if (ProyectoModulo == "TLC")
            {
                var orders = await _dataContext.AsignacionesOTs2

           .Where(o => (o.UserID == UserID)
                        && (o.PROYECTOMODULO == ProyectoModulo)
                        && (o.CierraEnAPP == 0) && (o.NoMostrarAPP == 0)
                        && (o.BAJASISTEMA == 0)
                        && (o.ESTADOGAOS != "EJB")
                        )
           .OrderBy(o => o.RECUPIDJOBCARD)
           .GroupBy(r => new
           {
               //r.RECUPIDJOBCARD,
               r.CLIENTE,
               r.Documento,
               r.NOMBRE,
               r.DOMICILIO,
               r.CP,
               r.ENTRECALLE1,
               r.ENTRECALLE2,
               r.Partido,
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
               r.DESCRIPCION,
               r.CierraEnAPP,
               r.NoMostrarAPP,
               r.Novedades,
               r.PROVINCIA,
               //r.ReclamoTecnicoID,
               r.Motivos,
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
               r.TelefAlternativo4,
               //r.ObservacionCaptura,
               r.ZONA,
               //r.ModificadoApp
           })
           .Select(g => new
           {
               //RECUPIDJOBCARD = g.Key.RECUPIDJOBCARD,
               CLIENTE = g.Key.CLIENTE,
               Documento = g.Key.Documento,
               NOMBRE = g.Key.NOMBRE,
               DOMICILIO = g.Key.DOMICILIO,
               CP = g.Key.CP,
               ENTRECALLE1 = g.Key.ENTRECALLE1,
               ENTRECALLE2 = g.Key.ENTRECALLE2,
               Partido = g.Key.Partido,
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
               DESCRIPCION = g.Key.DESCRIPCION,
               CierraEnAPP = g.Key.CierraEnAPP,
               NoMostrarAPP = g.Key.NoMostrarAPP,
               Novedades = g.Key.Novedades,
               PROVINCIA = g.Key.PROVINCIA,
               //ReclamoTecnicoID = g.Key.ReclamoTecnicoID,
               Motivos = g.Key.Motivos,
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
               //ObservacionCaptura=g.Key.ObservacionCaptura,
               ZONA = g.Key.ZONA,
               //ModificadoApp = g.Key.ModificadoApp,


               CantAsign = g.Count(),
           })
        .ToListAsync();


                if (orders == null)
                {
                    return BadRequest("No hay Asignaciones para este Usuario.");
                }

                return Ok(orders);
            }

            else
            {
                var orders = await _dataContext.AsignacionesOTs2

          .Where(o => (o.UserID == UserID)
                       && (o.PROYECTOMODULO == ProyectoModulo)
                       && (o.CierraEnAPP == 0) && (o.NoMostrarAPP == 0)
                       && (o.BAJASISTEMA == 0)
                       && (o.ESTADOGAOS != "EJB")
                       )
          .OrderBy(o => o.RECUPIDJOBCARD)
          .GroupBy(r => new
          {
              //r.RECUPIDJOBCARD,
              r.CLIENTE,
              r.Documento,
              r.NOMBRE,
              r.DOMICILIO,
              r.CP,
              r.ENTRECALLE1,
              r.ENTRECALLE2,
              r.Partido,
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
              r.DESCRIPCION,
              r.CierraEnAPP,
              r.NoMostrarAPP,
              r.Novedades,
              r.PROVINCIA,
              r.ReclamoTecnicoID,
              r.Motivos,
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
              r.TelefAlternativo4,
              //r.ObservacionCaptura,
              r.ZONA,
              //r.ModificadoApp
          })
          .Select(g => new
          {
              //RECUPIDJOBCARD = g.Key.RECUPIDJOBCARD,
              CLIENTE = g.Key.CLIENTE,
              Documento = g.Key.Documento,
              NOMBRE = g.Key.NOMBRE,
              DOMICILIO = g.Key.DOMICILIO,
              CP = g.Key.CP,
              ENTRECALLE1 = g.Key.ENTRECALLE1,
              ENTRECALLE2 = g.Key.ENTRECALLE2,
              Partido = g.Key.Partido,
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
              DESCRIPCION = g.Key.DESCRIPCION,
              CierraEnAPP = g.Key.CierraEnAPP,
              NoMostrarAPP = g.Key.NoMostrarAPP,
              Novedades = g.Key.Novedades,
              PROVINCIA = g.Key.PROVINCIA,
              ReclamoTecnicoID = g.Key.ReclamoTecnicoID,
              Motivos = g.Key.Motivos,
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
              //ObservacionCaptura=g.Key.ObservacionCaptura,
              ZONA = g.Key.ZONA,
              //modificadoapp = g.Key.ModificadoApp,


              CantAsign = g.Count(),
          })
       .ToListAsync();


                if (orders == null)
                {
                    return BadRequest("No hay Asignaciones para este Usuario.");
                }

                return Ok(orders);

            }

            
        }

        [HttpPost]
        [Route("GetAsignacionesTodas/{UserID}")]
        public async Task<IActionResult> GetAsignacionesTodas(int UserID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var orders = await _dataContext.AsignacionesOTs2

           .Where(o => (o.UserID == UserID)
                        && (o.CierraEnAPP == 0) && (o.NoMostrarAPP == 0)
                        && (o.BAJASISTEMA == 0)
                        )
           .OrderBy(o => o.RECUPIDJOBCARD)
           .GroupBy(r => new
           {
               r.RECUPIDJOBCARD,
               r.CLIENTE,
               r.Documento,
               r.NOMBRE,
               r.DOMICILIO,
               r.CP,
               r.ENTRECALLE1,
               r.ENTRECALLE2,
               r.Partido,
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
               r.DESCRIPCION,
               r.CierraEnAPP,
               r.NoMostrarAPP,
               r.Novedades,
               r.PROVINCIA,
               r.ReclamoTecnicoID,
               r.Motivos,
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
               r.TelefAlternativo4,
               //r.ObservacionCaptura,
               r.ZONA,
               //r.ModificadoApp,
           })
           .Select(g => new
           {
               RECUPIDJOBCARD = g.Key.RECUPIDJOBCARD,
               CLIENTE = g.Key.CLIENTE,
               Documento = g.Key.Documento,
               NOMBRE = g.Key.NOMBRE,
               DOMICILIO = g.Key.DOMICILIO,
               CP = g.Key.CP,
               ENTRECALLE1 = g.Key.ENTRECALLE1,
               ENTRECALLE2 = g.Key.ENTRECALLE2,
               Partido = g.Key.Partido,
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
               DESCRIPCION = g.Key.DESCRIPCION,
               CierraEnAPP = g.Key.CierraEnAPP,
               NoMostrarAPP = g.Key.NoMostrarAPP,
               Novedades = g.Key.Novedades,
               PROVINCIA = g.Key.PROVINCIA,
               ReclamoTecnicoID = g.Key.ReclamoTecnicoID,
               Motivos = g.Key.Motivos,
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
               //ObservacionCaptura=g.Key.ObservacionCaptura,
               ZONA = g.Key.ZONA,
               //ModificadoApp = g.Key.ModificadoApp,


               CantAsign = g.Count(),
           })
        .ToListAsync();


            if (orders == null)
            {
                return BadRequest("No hay Asignaciones para este Usuario.");
            }

            return Ok(orders);
        }

        [HttpPost]
        [Route("GetCodigosCierre/{ProyectoModulo}")]
        public async Task<IActionResult> GetCodigosCierre(string ProyectoModulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var codigoscierre = await _dataContext.CodigosCierre

           .Where(o => (o.PROYECTOMODULO == ProyectoModulo) && (o.NoMostrarAPP == 0))
           .OrderBy(o => o.CodigoCierre)
           .ToListAsync();


            if (codigoscierre == null)
            {
                return BadRequest("No hay Códigos de Cierre para este ProyectoModulo.");
            }

            return Ok(codigoscierre);
        }

        [HttpPost]
        [Route("GetFuncionesApps/{ProyectoModulo}")]
        public async Task<IActionResult> GetFuncionesApps(string ProyectoModulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var funcionesApp = await _dataContext.FuncionesApps

           .Where(o => (o.PROYECTOMODULO == ProyectoModulo))
           .ToListAsync();


            if (funcionesApp == null)
            {
                return BadRequest("No hay FuncionesApps para este ProyectoModulo.");
            }

            return Ok(funcionesApp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario([FromRoute] int id, [FromBody] ChangePasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.IDUser)
            {
                return BadRequest();
            }

            var oldUsuario = await _dataContext.SubContratistasUsrWebs.FindAsync(request.IDUser);
            if (oldUsuario == null)
            {
                return BadRequest("El Usuario no existe.");
            }

            oldUsuario.USRCONTRASENA = request.NewPassword;

            _dataContext.SubContratistasUsrWebs.Update(oldUsuario);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("getAsignacionesEjb/{UserID}")]
        public async Task<IActionResult> getAsignacionesEjb(int UserID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            String _year = DateTime.Today.Year.ToString();
            String _month = DateTime.Today.Month.ToString();
            String _day = DateTime.Today.Day.ToString();
            if (_month.Length==1)
            {
                _month = "0" + _month;
            }
            if (_day.Length == 1)
            {
                _day = "0" + _day;
            }
            String hoy = _year + "-" + _month + "-" + _day;


            var orders = await _dataContext.AsignacionesOTs2

           .Where(o => (o.UserID == UserID)
                        && (o.FECHACUMPLIDA.ToString().Substring(0,10) == hoy)
                        && (o.ESTADOGAOS == "EJB")
                        )
           .OrderBy(o => o.RECUPIDJOBCARD)
           .GroupBy(r => new
           {
               r.CLIENTE,
               r.FECHACUMPLIDA,
               r.HsCumplida,
               r.Documento,
               r.NOMBRE,
               r.DOMICILIO,
               r.CP,
               r.ENTRECALLE1,
               r.ENTRECALLE2,
               r.Partido,
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
               r.DESCRIPCION,
               r.CierraEnAPP,
               r.NoMostrarAPP,
               r.Novedades,
               r.PROVINCIA,
               r.ReclamoTecnicoID,
               r.Motivos,
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
               r.TelefAlternativo4,
               //r.ObservacionCaptura,
               r.ZONA,
               //r.ModificadoApp
           })
           .Select(g => new
           {
               CLIENTE = g.Key.CLIENTE,
               FECHACUMPLIDA=g.Key.FECHACUMPLIDA,
               HsCumplida = g.Key.HsCumplida,
               Documento = g.Key.Documento,
               NOMBRE = g.Key.NOMBRE,
               DOMICILIO = g.Key.DOMICILIO,
               CP = g.Key.CP,
               ENTRECALLE1 = g.Key.ENTRECALLE1,
               ENTRECALLE2 = g.Key.ENTRECALLE2,
               Partido = g.Key.Partido,
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
               DESCRIPCION = g.Key.DESCRIPCION,
               CierraEnAPP = g.Key.CierraEnAPP,
               NoMostrarAPP = g.Key.NoMostrarAPP,
               Novedades = g.Key.Novedades,
               PROVINCIA = g.Key.PROVINCIA,
               ReclamoTecnicoID = g.Key.ReclamoTecnicoID,
               Motivos = g.Key.Motivos,
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
               //ObservacionCaptura=g.Key.ObservacionCaptura,
               ZONA = g.Key.ZONA,
               //ModificadoApp = g.Key.ModificadoApp,


               CantAsign = g.Count(),
           })
           .OrderByDescending(o => (o.FECHACUMPLIDA))
        .ToListAsync();


                if (orders == null)
                {
                    return BadRequest("No hay Asignaciones para este Usuario.");
                }

                return Ok(orders);
        }
    }
}