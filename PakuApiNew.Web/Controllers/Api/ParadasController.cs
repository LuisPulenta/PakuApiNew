﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            Parada parada = await _dataContext.p_Paradas2.FindAsync(request.IDParada);
            if (parada == null)
            {
                return BadRequest("La parada no existe.");
            }
            parada.Estado=request.Estado;
            parada.Fecha = request.Fecha;
            parada.Hora = request.Hora;
            parada.IdMotivo = request.IdMotivo;
            parada.NotaChofer = request.NotaChofer;

            try
            {
                _dataContext.p_Paradas2.Update(parada);
                await _dataContext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

 
        [HttpGet("GetParadaByIDParada/{codigo}")]
        public async Task<ActionResult<Data.Entities.Parada>> GetParadaByIDParada(int codigo)
        {
            Data.Entities.Parada parada = await _dataContext.p_Paradas2
                .FirstOrDefaultAsync(o => o.IDParada == codigo);

            if (parada == null)
            {
                return NotFound();
            }
            return parada;
        }

    }
}