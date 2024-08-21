using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PakuApiNew.Web.Data;
using PakuApiNew.Web.Data.Entities;
using System;
using System.Threading.Tasks;

namespace PakuApiNew.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinosGeoCodingController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public DestinosGeoCodingController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //-----------------------------------------------------------------------------------
        [HttpGet("GetDestinosGeoCoding/{documento}/{proveedor}")]
        public async Task<ActionResult<bool>> GetDestinosGeoCoding(int documento,int proveedor)
        {
            DestinosGeoCoding destinosGeoCoding = await _dataContext.p_DestinosGeoCoding
                .FirstOrDefaultAsync(o => o.Documento == documento && o.IDProveedor == proveedor);

            if (destinosGeoCoding == null)
            {
                return false;
            }
            return true;
        }

        //-----------------------------------------------------------------------------------
        [HttpPost]
        public async Task<ActionResult<DestinosGeoCoding>> DestinosGeoCoding(DestinosGeoCoding request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.FechaAlta = DateTime.Now;
            _dataContext.p_DestinosGeoCoding.Add(request);
            await _dataContext.SaveChangesAsync();
            return Ok(request);
        }
    }
}