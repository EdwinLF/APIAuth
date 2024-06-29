namespace PracticaExamen.API.DTOs
{
    public class PurchaseRequestDTO
    {
        public string PAN { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public string Amount { get; set; }
        public string identifyCommerce { get; set; }
        public string identifyTerminal { get; set; }
    }
}
