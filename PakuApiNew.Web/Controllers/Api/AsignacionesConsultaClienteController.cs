using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PakuApiNew.Web.Data;
using PakuApiNew.Helpers;
using PakuApiNew.Web.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace PakuApiNew.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesConsultaClienteController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IFilesHelper _fileHelper;

        public AsignacionesConsultaClienteController(DataContext dataContext, IFilesHelper fileHelper)
        {
            _dataContext = dataContext;
            _fileHelper = fileHelper;
        }

        [HttpPost]
        public async Task<IActionResult> GetConsultaCliente(ConsultaClienteRequest consultaClienteRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Data.Entities.FuncionesApp funcionApp = await _dataContext.FuncionesApps
                .FirstOrDefaultAsync(o => o.PROYECTOMODULO == consultaClienteRequest.PROYECTOMODULO);

            if (funcionApp == null)
            {
                return NotFound();
            }
            var token = funcionApp.Token;

            if (consultaClienteRequest.TOKEN!= token)
            {
                return BadRequest();
            }


            var asignaciones = await _dataContext.AsignacionesOTs
                   .Where(o => (
                   o.CLIENTE == consultaClienteRequest.CLIENTE
                   && o.PROYECTOMODULO == consultaClienteRequest.PROYECTOMODULO
                   && o.RECUPIDJOBCARD == consultaClienteRequest.RECUPIDJOBCARD
                   ))
                   .OrderBy(o => o.ReclamoTecnicoID).ToListAsync();

            var response = new List<AsignacionesConsultaCliente>();
            foreach (var asignacion in asignaciones)
            {
                var asignResponse = new AsignacionesConsultaCliente
                {
                    PROYECTOMODULO = asignacion.PROYECTOMODULO,
                    CLIENTE = asignacion.CLIENTE,
                    RECUPIDJOBCARD = asignacion.RECUPIDJOBCARD,
                    IDREGISTRO = asignacion.IDREGISTRO,
                    ESTADOGAOS = asignacion.ESTADOGAOS,
                    CodigoCierre = asignacion.CodigoCierre,
                    DECO1 = asignacion.DECO1,
                    ESTADO3 = asignacion.ESTADO3,
                    MODELO = asignacion.MODELO,
                    Motivos = asignacion.Motivos,
                    FECHACUMPLIDA = asignacion.FECHACUMPLIDA,
                    HsCumplidaTime = asignacion.HsCumplidaTime,
                    Documento = asignacion.Documento,
                    MarcaModeloId = asignacion.MarcaModeloId,
                    Fc_inicio_base=asignacion.Fc_inicio_base,
                    Fc_fin_base = asignacion.Fc_fin_base,
                    FechaEvento1 = asignacion.FechaEvento1,
                    Evento1 = asignacion.Evento1,
                    FechaEvento2 = asignacion.FechaEvento2,
                    Evento2 = asignacion.Evento2,
                };
                response.Add(asignResponse);
            }
                return Ok(response);
        }

        
        [HttpGet("{modulo}")]
        public async Task<IActionResult> GetModulo([FromRoute] string modulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proyectoModulo
                = await _dataContext.FuncionesApps
                .Where(o => (
                   o.PROYECTOMODULO == modulo
                   )).ToListAsync(); 

            if (proyectoModulo == null)
            {
                return NotFound();
            }
            return Ok(proyectoModulo);
        }


    }
}