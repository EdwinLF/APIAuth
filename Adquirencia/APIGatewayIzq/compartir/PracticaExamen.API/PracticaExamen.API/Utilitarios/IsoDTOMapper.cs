using PracticaExamen.API.DTOs;

namespace PracticaExamen.API.Utilitarios
{
    public class IsoDTOMapper
    {
        public static async Task<IsoDTO> DecodeIso(string isoMessage)
        {
            if (isoMessage.Length < 106) // La longitud mínima necesaria para evitar errores de índice
            {
                throw new ArgumentOutOfRangeException(nameof(isoMessage), "The provided ISO message is too short.");
            }
            return new IsoDTO()
            {
                MTI = isoMessage.Substring(0, 4),
                PrimaryBitmap = isoMessage.Substring(4, 16),
                CardNumber = isoMessage.Substring(20, 16),
                ProcessingCode = isoMessage.Substring(36, 6),
                TransactionAmount = isoMessage.Substring(42, 12),
                TransmissionDateTime = isoMessage.Substring(54, 10),
                SystemTraceAuditNumber = isoMessage.Substring(64, 6),
                LocalTransactionTime = isoMessage.Substring(70, 6),
                ExpirationDate = isoMessage.Substring(76, 4),
                RetrievalReferenceNumber = isoMessage.Substring(80, 12),
                AuthorizationIdentifier = isoMessage.Substring(92, 6),
                MerchantIdentifier = isoMessage.Substring(98, 8)
            };
        }
        public static async Task<string> EncodeIso(IsoDTO isoDTO)
        {
            return isoDTO.MTI + isoDTO.PrimaryBitmap + isoDTO.CardNumber + isoDTO.ProcessingCode + isoDTO.TransactionAmount + isoDTO.TransmissionDateTime + isoDTO.SystemTraceAuditNumber + isoDTO.LocalTransactionTime + isoDTO.ExpirationDate + isoDTO.RetrievalReferenceNumber + isoDTO.AuthorizationIdentifier + isoDTO.MerchantIdentifier;
        }
    }
}
