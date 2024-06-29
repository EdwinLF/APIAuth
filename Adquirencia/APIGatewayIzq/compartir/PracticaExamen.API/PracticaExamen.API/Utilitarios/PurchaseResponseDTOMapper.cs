using PracticaExamen.API.DTOs;
using PracticaExamen.BC.Modelos;

namespace PracticaExamen.API.Utilitarios
{
    public class PurchaseResponseDTOMapper
    {
        public static PurchaseResponseDTO purchaseResponseADTO(PurchaseResponse purchaseResponse)
        {
            return new PurchaseResponseDTO
            {
                PAN = purchaseResponse.PAN,
                trakingCode = purchaseResponse.trakingCode,
                authorizationCode = purchaseResponse.authorizationCode,
                referenceCode = purchaseResponse.referenceCode,
                amount = purchaseResponse.amount,
                responseAuthCode = purchaseResponse.responseAuthCode
            };
        }
        public static PurchaseResponse DTOaPurchaseResponse(PurchaseResponseDTO purchaseResponseDTO)
        {
            return new PurchaseResponse
            {
                PAN = purchaseResponseDTO.PAN,
                trakingCode = purchaseResponseDTO.trakingCode,
                authorizationCode = purchaseResponseDTO.authorizationCode,
                referenceCode = purchaseResponseDTO.referenceCode,
                amount = purchaseResponseDTO.amount,
                responseAuthCode = purchaseResponseDTO.responseAuthCode
            };
        }
    }
}
