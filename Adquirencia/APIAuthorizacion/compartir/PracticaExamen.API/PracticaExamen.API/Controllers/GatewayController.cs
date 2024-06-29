using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaExamen.API.DTOs;
using PracticaExamen.API.Utilitarios;
using PracticaExamen.BC.Modelos;
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

        [HttpPost("purchaseRequest")]
        public async Task<PurchaseResponseDTO> purchaseResquestIntent(PurchaseRequestDTO purchaseRequestDTO)
        {
            PurchaseResponse purchaseResponse = await _manageGatewayBW.purchaseResquestIntent(PurchaseRequestDTOMapper.PurchaseRequestDTOtoPurchaseRequest(purchaseRequestDTO));
            PurchaseResponseDTO purchaseResponseDTO = PurchaseResponseDTOMapper.purchaseResponseADTO(purchaseResponse);
            return purchaseResponseDTO;
        }
    }
}
