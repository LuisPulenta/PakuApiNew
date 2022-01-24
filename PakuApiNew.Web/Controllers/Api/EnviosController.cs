using Microsoft.AspNetCore.Mvc;
using PakuApiNew.Helpers;
using PakuApiNew.Web.Data;
using PakuApiNew.Web.Data.Entities;
using PakuApiNew.Web.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PakuApiNew.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IFilesHelper _filesHelper;

        public EnviosController(DataContext dataContext, IFilesHelper filesHelper)
        {
            _dataContext = dataContext;
            _filesHelper = filesHelper;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvio(int id, EnvioRequest request)
        {
            if (id != request.IDEnvio)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Envio envio = await _dataContext.p_Envios2.FindAsync(request.IDEnvio);
            if (envio == null)
            {
                return BadRequest("El envío no existe.");
            }

            var imageUrl1 = envio.UrlDNI;
            if (request.UrlDNI != null && request.ImageArray.Length > 0)
            {
                var stream = new MemoryStream(request.ImageArray);
                var guid = Guid.NewGuid().ToString();
                var file = $"{guid}.jpg";
                var folder = "wwwroot\\images\\DNI";
                var fullPath = $"~/images/DNI/{file}";
                var response = _filesHelper.UploadPhoto(stream, folder, file);

                if (response)
                {
                    imageUrl1 = fullPath;
                }
            }

            envio.ESTADO = request.ESTADO;
            envio.FechaEntregaCliente = request.FechaEntregaCliente;
            envio.FechaUltimaActualizacion = request.FechaUltimaActualizacion;
            envio.UltimoIdMotivo = request.UltimoIdMotivo;
            envio.UltimaNotaFletero = request.UltimaNotaFletero;
            envio.UrlDNI = imageUrl1;

            try
            {
                _dataContext.p_Envios2.Update(envio);
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