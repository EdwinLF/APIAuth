using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaExamen.API.DTOs;
using PracticaExamen.API.Utilitarios;
using PracticaExamen.BC.Modelos;
using PracticaExamen.BW.CU;
using PracticaExamen.BW.Interfaces.BW;
using PracticaExamen.BW.Interfaces.DA;
using PracticaExamen.DA.Entidades;
namespace PracticaExamen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IGestionarUsuarioBW gestionarUsuarioBW;
        private readonly IGestionarLogBW gestionarLoBW;

        public UsuarioController(IGestionarUsuarioBW gestionarUsuarioBW, IGestionarLogBW gestionarLogBW)
        {
            this.gestionarUsuarioBW = gestionarUsuarioBW;
            this.gestionarLoBW = gestionarLogBW;
        }
        [HttpGet]
        [Route("traerDatosUsuario/{cardUser,password}")]
        public async Task<UsuarioDTO> obtenerDataUsuario(string cardUser, string password) {
            return await UsuarioDTOMapper.convertirUsuarioADTO(await gestionarUsuarioBW.obtengaDatosUsuario(cardUser, password));
        
        }
        [HttpPost]
        [Route("registrarUsuario")]
        public async Task<ActionResult<bool>> RegistrarUsuaio(UsuarioDTO usuarioDTO) { 
            Usuario usuario = await UsuarioDTOMapper.convertirDTOAUsuario(usuarioDTO);
            var respuesta = await gestionarUsuarioBW.registreUsuario(usuario);
            if (respuesta) {
                Log log = await LogDTOMapper.convertirDTOALog(new LogDTO { typeLog = "Registrar Usuario", tableLog = "Usuario", dateLog = DateTime.Now, descriptionLog = "Datos ingresados: " + usuarioDTO.Name + " cedula: " + usuarioDTO.CardUser });
                await gestionarLoBW.registreLog(log);
            }
            return Ok(respuesta);
        }
        [HttpDelete]
        [Route("elinmarUsuario")]
        public async Task<IActionResult> EliminarUsuario(Usuario usuario)
        {
            var respuesta = gestionarUsuarioBW.elimineUsuario(usuario);
            if(!await respuesta)
                return BadRequest(respuesta);


            Log log = await LogDTOMapper.convertirDTOALog(new LogDTO { typeLog = "Eliminar Usuario", tableLog = "Usuario", dateLog = DateTime.Now, descriptionLog = "Datos ingresados: " + usuario.Name + " cedula: " + usuario.CardUser });
            await gestionarLoBW.registreLog(log);
            return Ok(respuesta);
        }
        [HttpPut]
        [Route("actualizeUsuario")]
        public async Task<IActionResult> EditarUsuario(UsuarioDTO usuarioDTO) { 
            Usuario usuario = await UsuarioDTOMapper.convertirDTOAUsuario(usuarioDTO);
            var respuesta = gestionarUsuarioBW.actualiceUsuario(usuario);
            if (!await respuesta)
                return BadRequest(respuesta);


            Log log = await LogDTOMapper.convertirDTOALog(new LogDTO { typeLog = "Actualizar Usuario", tableLog = "Usuario", dateLog = DateTime.Now, descriptionLog = "Datos actulizados: " + usuarioDTO.Name + " cedula: " + usuarioDTO.CardUser });
            await gestionarLoBW.registreLog(log);
            return Ok(respuesta);
        }
    }
}
