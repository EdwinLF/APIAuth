namespace PracticaExamen.API.DTOs
{
    public class PurchaseResponseDTO
    {
        public string PAN { get; set; }
        public string trakingCode { get; set; }
        public string authorizationCode { get; set; }
        public string referenceCode { get; set; }
        public double amount { get; set; }
        public string responseAuthCode { get; set; }
    }
}
