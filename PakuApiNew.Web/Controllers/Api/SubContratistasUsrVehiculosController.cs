using PakuApiNew.Web.Data;
using PakuApiNew.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace PakuApiNew.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubContratistasUsrVehiculosController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SubContratistasUsrVehiculosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostWebSubContratistasUsrVehiculo([FromBody] SubContratistasUsrVehiculo request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dataContext.SubContratistasUsrVehiculos.Add(request);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }

              
        [HttpPut("{id}")]
        [Route("PutSubContratistasUsrVehiculo")]
        public async Task<IActionResult> PutSubContratistasUsrVehiculo(SubContratistasUsrVehiculo subContratistasUsrVehiculo)
        {
            SubContratistasUsrVehiculo oldSubContratistasUsrVehiculo = await _dataContext.SubContratistasUsrVehiculos
                .FirstOrDefaultAsync(t => t.ID == subContratistasUsrVehiculo.ID);

            if (oldSubContratistasUsrVehiculo == null)
            {
                return BadRequest("SubContratistasUsrVehiculo no existe.");
            }
            _dataContext.SubContratistasUsrVehiculos.Update(subContratistasUsrVehiculo);
            await _dataContext.SaveChangesAsync();
            return Ok(true);
        }

        [HttpGet("GetSubContratistasUsrVehiculo/{iduser}")]
        public async Task<IActionResult> GetSubContratistasUsrVehiculo(int iduser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            System.Collections.Generic.List<SubContratistasUsrVehiculo> subContratistasUsrVehiculos = await _dataContext.SubContratistasUsrVehiculos
                .Where(o => o.IdUser == iduser)
           .ToListAsync();

            if (subContratistasUsrVehiculos.Count>0)
            {
                return Ok(subContratistasUsrVehiculos[0]);
            }
            else
            {
                return Ok("No hay datos");
            }
        }
    }
}