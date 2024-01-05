using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PakuApiNew.Web.Data;
using PakuApiNew.Web.Models;
using System;
using System.Threading.Tasks;

namespace GenericApp.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _dataContext;
        

        public AccountController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }



        [HttpPost]
        [Route("GetUserByLogin")]
        public async Task<IActionResult> GetUserByLogin(UsuarioRequest userRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var user = await _dataContext.Usuarios.FirstOrDefaultAsync(o => o.Login.ToLower() == userRequest.Email.ToLower());

            if (user == null)
            {
                return BadRequest("El Usuario no existe.");
            }

            var response = new UsuarioAppResponse
            {
                IDUsuario = user.IDUsuario,
                CodigoCausante = user.CodigoCausante,
                Login = user.Login,
                Contrasena = user.Contrasena,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                AutorWOM = user.AutorWOM,
                Estado = user.Estado,
                HabilitaAPP = user.HabilitaAPP,
                HabilitaFotos = user.HabilitaFotos,
                HabilitaReclamos = user.HabilitaReclamos,
                HabilitaSSHH = user.HabilitaSSHH,
                HabilitaRRHH = user.HabilitaRRHH,
                Modulo = user.Modulo,
                HabilitaMedidores = user.HabilitaMedidores,
                HabilitaFlotas = user.HabilitaFlotas,
                ReHabilitaUsuarios = user.ReHabilitaUsuarios,
                CODIGOGRUPO = user.CODIGOGRUPO,
                FechaCaduca = user.FechaCaduca,
                IntentosInvDiario = user.IntentosInvDiario,
                OpeAutorizo = user.OpeAutorizo,
                HabilitaNuevoSuministro = user.HabilitaNuevoSuministro,
                HabilitaVeredas = user.HabilitaVeredas,
                HabilitaJuicios = user.HabilitaJuicios,
                HabilitaPresentismo = user.HabilitaPresentismo,
                HabilitaSeguimientoUsuarios = user.HabilitaSeguimientoUsuarios,
                HabilitaVerObrasCerradas=user.HabilitaVerObrasCerradas,
                HabilitaElementosCalle=user.HabilitaElementosCalle,
                CONCEPTOMOVA = user.CONCEPTOMOVA,
                LimitarGrupo = user.LimitarGrupo,
                RUBRO = user.RUBRO,
            };
            return Ok(response);
        }


        [HttpPut("{login}")]
        [Route("ReactivaUsuario")]
        public async Task<IActionResult> ReactivaUsuario([FromRoute] string login, [FromBody] UsuarioAutorizaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (login != request.Login)
            {
                return BadRequest();
            }

            var oldUsuario = await _dataContext.Usuarios.FirstOrDefaultAsync(x => x.Contrasena == request.Login);

            if (oldUsuario == null)
            {
                return BadRequest("El Usuario no existe.");
            }

            oldUsuario.Estado = 1;
            oldUsuario.FechaCaduca = request.FechaCaduca;
            oldUsuario.IntentosInvDiario = 0;
            oldUsuario.OpeAutorizo = request.IdUsuarioAutoriza;

            _dataContext.Usuarios.Update(oldUsuario);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }        
    }
}