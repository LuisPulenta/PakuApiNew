using Microsoft.AspNetCore.Mvc;
using PakuApiNew.Web.Data;
using PakuApiNew.Web.Data.Entities;
using System;
using System.Threading.Tasks;

namespace PakuApiNew.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParadasController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ParadasController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutParada(int id, Parada request)
        {
            if (id != request.IDParada)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Parada parada = await _dataContext.p_Paradas.FindAsync(request.IDParada);
            if (parada == null)
            {
                return BadRequest("La parada no existe.");
            }
            parada.Estado=request.Estado;
            parada.Fecha = request.Fecha;
            parada.Hora = request.Hora;
            parada.NotaChofer = request.NotaChofer;

            try
            {
                _dataContext.p_Paradas.Update(parada);
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