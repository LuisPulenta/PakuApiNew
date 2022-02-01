using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using PakuApiNew.Web.Data;
using PakuApiNew.Helpers;
using PakuApiNew.Web.Models;

namespace PakuApiNew.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesOTsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly FilesHelper _fileHelper;

        public AsignacionesOTsController(DataContext dataContext, FilesHelper fileHelper)
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

            oldasignacionesOT.ESTADOGAOS = asignacionesOT.ESTADOGAOS;
            oldasignacionesOT.UrlDni = imageUrlDNI;
            oldasignacionesOT.UrlFirma = imageUrlFirma;
            oldasignacionesOT.CodigoCierre = asignacionesOT.CodigoCierre;
            oldasignacionesOT.FECHACUMPLIDA = asignacionesOT.FECHACUMPLIDA;
            oldasignacionesOT.HsCumplidaTime = asignacionesOT.HsCumplidaTime;
            oldasignacionesOT.DECO1 = asignacionesOT.DECO1;
            oldasignacionesOT.ESTADO2 = asignacionesOT.ESTADO2;
            oldasignacionesOT.ESTADO3 = asignacionesOT.ESTADO3;
            oldasignacionesOT.Observacion = asignacionesOT.Observacion;
            oldasignacionesOT.FechaCita = asignacionesOT.FechaCita;
            oldasignacionesOT.MedioCita = asignacionesOT.MedioCita;
            oldasignacionesOT.NroSeriesExtras = asignacionesOT.NroSeriesExtras;
            oldasignacionesOT.Evento1 = asignacionesOT.Evento1;
            oldasignacionesOT.FechaEvento1 = asignacionesOT.FechaEvento1;
            oldasignacionesOT.Evento2 = asignacionesOT.Evento2;
            oldasignacionesOT.FechaEvento2 = asignacionesOT.FechaEvento2;
            oldasignacionesOT.Evento3 = asignacionesOT.Evento3;
            oldasignacionesOT.FechaEvento3 = asignacionesOT.FechaEvento3;
            oldasignacionesOT.Evento4 = asignacionesOT.Evento4;
            oldasignacionesOT.FechaEvento4 = asignacionesOT.FechaEvento4;

            _dataContext.AsignacionesOTs.Update(oldasignacionesOT);
            await _dataContext.SaveChangesAsync();
            return Ok(asignacionesOT);
        }


    }
}
