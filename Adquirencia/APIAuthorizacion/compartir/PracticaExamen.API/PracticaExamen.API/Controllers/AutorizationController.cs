using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaExamen.BC.Modelos;
using PracticaExamen.BW.Interfaces.BW;

namespace PracticaExamen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizationController : ControllerBase
    {
        private readonly IManageAuthorizationBW _manageAuthorizationBW;

        public AutorizationController(IManageAuthorizationBW manageAuthorizationBW)
        {
            _manageAuthorizationBW = manageAuthorizationBW;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var autorizations = await _manageAuthorizationBW.getAuthorizations();
            return Ok(autorizations);
        }
        [HttpPost]
        public async Task<IActionResult> Post(authorization authorization)
        {
            var result = await _manageAuthorizationBW.registerAuthorization(authorization);
            if (result)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
