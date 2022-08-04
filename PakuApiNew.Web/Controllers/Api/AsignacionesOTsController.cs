using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using PakuApiNew.Web.Data;
using PakuApiNew.Helpers;
using PakuApiNew.Web.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PakuApiNew.Web.Data.Entities;

namespace PakuApiNew.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesOTsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IFilesHelper _fileHelper;

        public AsignacionesOTsController(DataContext dataContext, IFilesHelper fileHelper)
        {
            _dataContext = dataContext;
            _fileHelper = fileHelper;
        }

        // PUT: api/AsignacionesOTs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignacionesOT([FromRoute] int id, [FromBody] AsignacionesOTRequest asignacionesOT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asignacionesOT.IDREGISTRO)
            {
                return BadRequest();
            }

            var oldasignacionesOT = await _dataContext.AsignacionesOTs.FindAsync(asignacionesOT.IDREGISTRO);
            if (oldasignacionesOT == null)
            {
                return BadRequest("El registro no existe.");
            }


            var imageUrlDNI = oldasignacionesOT.UrlDni;
            if (asignacionesOT.ImageArrayDni != null && asignacionesOT.ImageArrayDni.Length > 0)
            {
                var stream = new MemoryStream(asignacionesOT.ImageArrayDni);
                var guid = Guid.NewGuid().ToString();
                var file = $"{guid}.jpg";
                var folder = "wwwroot\\images\\DNI";                 //Alt126 -->  ~
                var fullPath = $"{folder}/{file}";
                var response = _fileHelper.UploadPhoto(stream, folder, file);

                if (response)
                {
                    imageUrlDNI = fullPath;
                }
            }

            var imageUrlFirma = oldasignacionesOT.UrlDni;
            if (asignacionesOT.ImageArrayFirma != null && asignacionesOT.ImageArrayFirma.Length > 0)
            {
                var stream = new MemoryStream(asignacionesOT.ImageArrayFirma);
                var guid = Guid.NewGuid().ToString();
                var file = $"{guid}.png";
                var folder = "wwwroot\\images\\Firmas";                 //Alt126 -->  ~
                var fullPath = $"{folder}/{file}";
                var response = _fileHelper.UploadPhoto(stream, folder, file);

                if (response)
                {
                    imageUrlFirma = fullPath;
                }
            }

            oldasignacionesOT.CodigoCierre = asignacionesOT.CodigoCierre;
            oldasignacionesOT.DECO1 = asignacionesOT.DECO1;
            oldasignacionesOT.MarcaModeloId = asignacionesOT.MarcaModeloId;
            oldasignacionesOT.CMODEM1 = asignacionesOT.CMODEM1;
            oldasignacionesOT.ESTADO2 = asignacionesOT.ESTADO2;
            oldasignacionesOT.ESTADO3 = asignacionesOT.ESTADO3;
            oldasignacionesOT.ESTADOGAOS = asignacionesOT.ESTADOGAOS;
            oldasignacionesOT.Evento1 = asignacionesOT.Evento1;
            oldasignacionesOT.Evento2 = asignacionesOT.Evento2;
            oldasignacionesOT.Evento3 = asignacionesOT.Evento3;
            oldasignacionesOT.Evento4 = asignacionesOT.Evento4;
            oldasignacionesOT.FechaCita = asignacionesOT.FechaCita;
            oldasignacionesOT.FECHACUMPLIDA = asignacionesOT.FECHACUMPLIDA;
            oldasignacionesOT.FechaEvento1 = asignacionesOT.FechaEvento1;
            oldasignacionesOT.FechaEvento2 = asignacionesOT.FechaEvento2;
            oldasignacionesOT.FechaEvento3 = asignacionesOT.FechaEvento3;
            oldasignacionesOT.FechaEvento4 = asignacionesOT.FechaEvento4;
            oldasignacionesOT.HsCumplidaTime = asignacionesOT.HsCumplidaTime;
            oldasignacionesOT.MedioCita = asignacionesOT.MedioCita;
            oldasignacionesOT.NroSeriesExtras = asignacionesOT.NroSeriesExtras;
            oldasignacionesOT.Observacion = asignacionesOT.Observacion;
            oldasignacionesOT.UrlDni = imageUrlDNI;
            oldasignacionesOT.UrlFirma = imageUrlFirma;
            oldasignacionesOT.SMARTCARD = asignacionesOT.SMARTCARD;
            oldasignacionesOT.elegir = asignacionesOT.elegir;


            _dataContext.AsignacionesOTs.Update(oldasignacionesOT);
            await _dataContext.SaveChangesAsync();
            return Ok(asignacionesOT);
        }

        [HttpPost]
        [Route("GetAutonumericos")]
        public async Task<IActionResult> GetAutonumericos(AsignRequest asignRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var asignaciones = await _dataContext.AsignacionesOTs2

                   .Where(o => (o.ReclamoTecnicoID == asignRequest.ReclamoTecnicoID
                   && o.CLIENTE == asignRequest.CLIENTE
                   && o.UserID == asignRequest.UserID
                   && o.CierraEnAPP==0
                   && o.NoMostrarAPP==0
                   && o.ESTADOGAOS != "EJB"
                   ))
                   
                   .OrderBy(o => o.ReclamoTecnicoID).ToListAsync();


            var response = new List<AsignacionesOT>();
            foreach (var control in asignaciones)
            {
                var asignResponse = new AsignacionesOT
                {
                    Autonumerico = control.Autonumerico,
                    CMODEM1 = control.CMODEM1,
                    CodigoCierre = control.CodigoCierre,
                    DECO1 = control.DECO1,
                    ESTADO = control.ESTADO,
                    ESTADO2 = control.ESTADO2,
                    ESTADO3 = control.ESTADO3,
                    ESTADOGAOS = control.ESTADOGAOS,
                    FECHACUMPLIDA = control.FECHACUMPLIDA,
                    HsCumplida = control.HsCumplida,
                    HsCumplidaTime = control.HsCumplidaTime,
                    IDREGISTRO = control.IDREGISTRO,
                    Observacion = control.Observacion,
                    PROYECTOMODULO = control.PROYECTOMODULO,
                    ReclamoTecnicoID = control.ReclamoTecnicoID,
                    RECUPIDJOBCARD = control.RECUPIDJOBCARD,
                    IDSuscripcion = control.IDSuscripcion,
                    MarcaModeloId = control.MarcaModeloId,
                    MODELO = control.MODELO,
                    Motivos = control.Motivos,
                    ZONA = control.ZONA,
                    TelefAlternativo1 = control.TelefAlternativo1,
                    TelefAlternativo2 = control.TelefAlternativo2,
                    TelefAlternativo3 = control.TelefAlternativo3,
                    TelefAlternativo4 = control.TelefAlternativo4,
                    BAJASISTEMA = control.BAJASISTEMA,
                    ArchivoOutGenerado = control.ArchivoOutGenerado,
                    CAUSANTEC = control.CAUSANTEC,
                    ENTRECALLE1 = control.ENTRECALLE1,
                    EmailCliente = control.EmailCliente,
                    ENTRECALLE2 = control.ENTRECALLE2,
                    FechaAsignada = control.FechaAsignada,
                    FECHACAPTURA = control.FECHACAPTURA,
                    Cancelado = control.Cancelado,
                    FECHACARGA = control.FECHACARGA,
                    FECHAENT = control.FECHAENT,
                    HsAsignada = control.HsAsignada,
                    IDCABECERACERTIF = control.IDCABECERACERTIF,
                    IDR = control.IDR,
                    IdTipoTrabajoRel= control.IdTipoTrabajoRel,
                    LOCALIDAD = control.LOCALIDAD,
                    PROVINCIA = control.PROVINCIA,
                    RUTA = control.RUTA,
                    SMARTCARD = control.SMARTCARD,
                    SUBAGENTEMERCADO = control.SUBAGENTEMERCADO,
                    TARIFA = control.TARIFA,
                    TECASIG = control.TECASIG,
                    TerminalAsigna = control.TerminalAsigna,
                    CLIENTE = control.CLIENTE,
                    ClienteTipoId = control.ClienteTipoId,
                    VisitaTecnica = control.VisitaTecnica,
                    CP = control.CP,
                    Documento = control.Documento,
                    DOMICILIO = control.DOMICILIO,
                    EsCR = control.EsCR,
                    Enviado = control.Enviado,
                    Evento1 = control.Evento1,
                    Evento2 = control.Evento2,
                    Evento3 = control.Evento3,
                    Evento4 = control.Evento4,
                    FechaEnvio = control.FechaEnvio,
                    FechaEvento1 = control.FechaEvento1,
                    FechaEvento2 = control.FechaEvento2,
                    FechaEvento3 = control.FechaEvento3,
                    FechaEvento4 = control.FechaEvento4,
                    FechaCumplidaTecnico = control.FechaCumplidaTecnico,
                    FechaCita = control.FechaCita,
                    FechaInicio = control.FechaInicio,
                    GRXX = control.GRXX,
                    GRYY = control.GRYY,
                    PDFGenerado = control.PDFGenerado,
                    HsCaptura = control.HsCaptura,
                    ItemsID = control.ItemsID,
                    LinkFoto = control.LinkFoto,
                    MedioCita = control.MedioCita,
                    NOMBRE = control.NOMBRE,
                    Novedades = control.Novedades,
                    NroSeriesExtras = control.NroSeriesExtras,
                    ObservacionCaptura = control.ObservacionCaptura,
                    Partido = control.Partido,
                    PasaDefinitiva = control.PasaDefinitiva,
                    Recupero = control.Recupero,
                    SectorOperativo = control.SectorOperativo,
                    SUBCON = control.SUBCON,
                    TELEFONO = control.TELEFONO,
                    UrlDni = control.UrlDni,
                    UrlDni2 = control.UrlDni2,
                    UrlFirma = control.UrlFirma,
                    UrlFirma2 = control.UrlFirma2,
                    UserID = control.UserID,
                    ZTECNICO = control.ZTECNICO,

             };
                response.Add(asignResponse);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("GetControlesEquivalencia/{ProyectoModulo}")]
        public async Task<IActionResult> GetControlesEquivalencia(string ProyectoModulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var controles = await _dataContext.ControlesEquivalencias

           .Where(o => (o.ProyectoModulo == ProyectoModulo)
                        )
           .OrderBy(o => o.DESCRIPCION)
        .ToListAsync();


            if (controles == null)
            {
                return BadRequest("No hay Controles para éste Proyecto.");
            }

            return Ok(controles);
        }

        [HttpPost]
        [Route("GetGrafico01Asignados")]
        public async Task<IActionResult> GetGrafico01Asignados(Grafico01Request grafico01Request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var orders = await _dataContext.AsignacionesOTs
           .Where(o => (o.UserID == grafico01Request.UserID)
           && (o.PROYECTOMODULO == grafico01Request.Proyecto)
           && (o.FechaAsignada.Value.Month == grafico01Request.Mes)
           && (o.FechaAsignada.Value.Year == grafico01Request.Anio)
           )
           .OrderBy(o => o.PROYECTOMODULO)
           .GroupBy(r => new
           {
               r.PROYECTOMODULO,
           })
           .Select(g => new
           {
               Asignados = g.Count(),
           }).ToListAsync();


            if (orders == null)
            {
                return BadRequest("No hay Ordenes de Trabajo para este Usuario.");
            }

            return Ok(orders);
        }

        [HttpPost]
        [Route("GetGrafico01Ejecutados")]
        public async Task<IActionResult> GetGrafico01Ejecutados(Grafico01Request grafico01Request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var orders = await _dataContext.AsignacionesOTs
           .Where(o => (o.UserID == grafico01Request.UserID)
           && (o.PROYECTOMODULO == grafico01Request.Proyecto)
            && (o.ESTADOGAOS == "EJB")
           && (o.HsCumplidaTime.Value.Month == grafico01Request.Mes)
           && (o.HsCumplidaTime.Value.Year == grafico01Request.Anio)
           )
           .OrderBy(o => o.PROYECTOMODULO)
           .GroupBy(r => new
           {
               r.PROYECTOMODULO,
           })
           .Select(g => new
           {
               Ejecutados = g.Count(),
           }).ToListAsync();


            if (orders == null)
            {
                return BadRequest("No hay Ordenes de Trabajo para este Usuario.");
            }

            return Ok(orders);
        }
    }
}
