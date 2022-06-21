using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            envio.LATITUD2 = request.LATITUD2;
            envio.LONGITUD2 = request.LONGITUD2;


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

        [HttpGet("GetEnvioByIdEnvio/{codigo}")]
        public async Task<ActionResult<Data.Entities.Envio>> GetEnvioByIdEnvio(int codigo)
        {
            Data.Entities.Envio envio = await _dataContext.p_Envios2
                .FirstOrDefaultAsync(o => o.IDEnvio == codigo);

            if (envio == null)
            {
                return NotFound();
            }
            return envio;
        }
    }
}