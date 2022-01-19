using Microsoft.AspNetCore.Mvc;
using PakuApiNew.Web.Data;
using PakuApiNew.Web.Data.Entities;
using System;
using System.Threading.Tasks;

namespace PakuApiNew.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public EnviosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvio(int id, Envio request)
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
            envio.ESTADO = request.ESTADO;
            envio.FechaEntregaCliente = request.FechaEntregaCliente;
            envio.FechaUltimaActualizacion = request.FechaUltimaActualizacion;
            envio.UltimoIdMotivo = request.UltimoIdMotivo;
            envio.UltimaNotaFletero = request.UltimaNotaFletero;

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