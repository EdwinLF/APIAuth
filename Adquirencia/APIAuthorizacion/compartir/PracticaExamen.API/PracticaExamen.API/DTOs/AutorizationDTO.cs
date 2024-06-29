using MongoDB.Bson;

namespace PracticaExamen.API.DTOs
{
    public class AutorizationDTO
    {
        public ObjectId Id { get; set; }
        public string PAN { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public string CardBrand { get; set; }
        public double PurchaseAmount { get; set; }
        public int SequenceNumber { get; set; }
        public int AuthorizationCode { get; set; }
        public int ReferenceTracking { get; set; }
        public string state { get; set; }
        public DateTime CreatedIt { get; set; }
        public DateTime UpdatedIt { get; set; }
    }
}
