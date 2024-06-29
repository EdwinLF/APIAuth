using PracticaExamen.API.DTOs;
using PracticaExamen.BC.Modelos;

namespace PracticaExamen.API.Utilitarios
{
    public class PurchaseRequestDTOMapper
    {
        public static PurchaseRequestDTO DTOtoPurchaseRequest(PurchaseRequest purchaseRequest)
        {
            return new PurchaseRequestDTO
            {
                PAN = purchaseRequest.PAN,
                ExpiryDate = purchaseRequest.ExpiryDate,
                CVV = purchaseRequest.CVV,
                Amount = purchaseRequest.Amount,
                identifyCommerce = purchaseRequest.identifyCommerce,
                identifyTerminal = purchaseRequest.identifyTerminal
            };
        }
        public static PurchaseRequest PurchaseRequestDTOtoPurchaseRequest(PurchaseRequestDTO purchaseRequestDTO)
        {
            return new PurchaseRequest
            {
                PAN = purchaseRequestDTO.PAN,
                ExpiryDate = purchaseRequestDTO.ExpiryDate,
                CVV = purchaseRequestDTO.CVV,
                Amount = purchaseRequestDTO.Amount,
                identifyCommerce = purchaseRequestDTO.identifyCommerce,
                identifyTerminal = purchaseRequestDTO.identifyTerminal
            };
        }
    }
}
