using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PakuApiNew.Web.Data;
using PakuApiNew.Helpers;
using PakuApiNew.Web.Models;

namespace PakuApiNew.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesMarcaController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IFilesHelper _fileHelper;

        public AsignacionesMarcaController(DataContext dataContext, IFilesHelper fileHelper)
        {
            _dataContext = dataContext;
            _fileHelper = fileHelper;
        }
        
        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutMarcado([FromRoute] int id, [FromBody] MarcadoRequest asignacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asignacion.IDREGISTRO)
            {
                return BadRequest();
            }

            var oldasignacionesOT = await _dataContext.AsignacionesOTs.FindAsync(asignacion.IDREGISTRO);
            if (oldasignacionesOT == null)
            {
                return BadRequest("El registro no existe.");
            }

            oldasignacionesOT.Marcado = asignacion.Marcado;

            _dataContext.AsignacionesOTs.Update(oldasignacionesOT);
            await _dataContext.SaveChangesAsync();
            return Ok(asignacion);
        }        
    }
}