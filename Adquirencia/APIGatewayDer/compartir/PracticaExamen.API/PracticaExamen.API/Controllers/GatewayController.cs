using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaExamen.API.DTOs;
using PracticaExamen.API.Utilitarios;
using PracticaExamen.BW.Interfaces.BW;

namespace PracticaExamen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IManageGatewayBW _manageGatewayBW;

        public GatewayController(IManageGatewayBW manageGatewayBW)
        {
            _manageGatewayBW = manageGatewayBW;
        }
        [HttpPost("iso")]
        public async Task<string> iso(ISODataDTO iso)
        {
            return await _manageGatewayBW.AuthISO(ISODTOMapper.DTOISO(iso));
        }
        
    }
}
