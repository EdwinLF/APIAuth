using PracticaExamen.API.DTOs;
using PracticaExamen.BC.Modelos;
using System.Net;

namespace PracticaExamen.API.Utilitarios
{
    public class AutoriationDTOMapper
    {
        public static async Task<AutorizationDTO> convertirAutorizationADTO(authorization autorization) {
            return new AutorizationDTO()
            {
                Id = autorization.Id,
                PAN = autorization.PAN,
                CVV = autorization.CVV,
                ExpirationDate = autorization.ExpirationDate,
                CardBrand = autorization.CardBrand,
                PurchaseAmount = autorization.PurchaseAmount,
                SequenceNumber = autorization.SequenceNumber,
                AuthorizationCode = autorization.AuthorizationCode,
                ReferenceTracking = autorization.ReferenceTracking,
                state = autorization.state,
                CreatedIt = autorization.CreatedIt,
                UpdatedIt = autorization.UpdatedIt
            };
        }
        public static async Task<authorization> convertirAutorizationADTO(AutorizationDTO autorizationDTO) {
            return new authorization()
            {
                Id = autorizationDTO.Id,
                PAN = autorizationDTO.PAN,
                CVV = autorizationDTO.CVV,
                ExpirationDate = autorizationDTO.ExpirationDate,
                CardBrand = autorizationDTO.CardBrand,
                PurchaseAmount = autorizationDTO.PurchaseAmount,
                SequenceNumber = autorizationDTO.SequenceNumber,
                AuthorizationCode = autorizationDTO.AuthorizationCode,
                ReferenceTracking = autorizationDTO.ReferenceTracking,
                state = autorizationDTO.state,
                CreatedIt = autorizationDTO.CreatedIt,
                UpdatedIt = autorizationDTO.UpdatedIt
            };
        }
        public static async Task<IEnumerable<AutorizationDTO>> convertAutorizationListDTO(IEnumerable<authorization> autorizations) {
            return autorizations.Select(autorization => new AutorizationDTO()
            {
                Id = autorization.Id,
                PAN = autorization.PAN,
                CVV = autorization.CVV,
                ExpirationDate = autorization.ExpirationDate,
                CardBrand = autorization.CardBrand,
                PurchaseAmount = autorization.PurchaseAmount,
                SequenceNumber = autorization.SequenceNumber,
                AuthorizationCode = autorization.AuthorizationCode,
                ReferenceTracking = autorization.ReferenceTracking,
                state = autorization.state,
                CreatedIt = autorization.CreatedIt,
                UpdatedIt = autorization.UpdatedIt
            });
        }
    }
}
