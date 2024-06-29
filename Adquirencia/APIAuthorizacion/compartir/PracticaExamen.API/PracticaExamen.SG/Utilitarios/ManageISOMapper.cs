


using PracticaExamen.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.SG.Utilitarios
{
    public class ManageISOMapper
    {
        private static int systemTraceAuditNumber = 0;
        private static int authorizationIdentifier = 0;
        public static async Task<string> MapPurchaseRequestToISO(PurchaseRequest purchaseRequest)
        {
            var systemTraceAuditNumber = GetNextSystemTraceAuditNumber();
            var authorizationIdentifier = GetNextAuthorizationIdentifier();
            var retrievalReferenceNumber = GenerateRetrievalReferenceNumber();
            var currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var currentTime = DateTime.Now.ToString("HHmmss");

            string MTI = "0200"; // Example MTI for a financial transaction request
            string bitmap = "7020000000808000"; // Example bitmap, you will need to calculate this based on the fields present
            string processingCode = "000000"; // Example processing code
            string monto = "";
            for (int i = 0; i < 12; i++)
            {
                if (i < (12 - purchaseRequest.Amount.Count()))
                {                   
                    monto += "0";
                }  
                else
                {
                    monto += purchaseRequest.Amount;
                    break;
                }
            }
            string transactionAmount = monto; 
            //string transactionAmount = purchaseRequest.Amount.PadLeft(12, '0');
            string transmissionDateTime = DateTime.Now.ToString("yyMMddHHmm");
            string localTransactionTime = currentTime;
            string expirationDate = purchaseRequest.ExpiryDate.Replace("-", "").Substring(2, 4); // Convert MM-YYYY to YYMM
            string merchantIdentifier = purchaseRequest.identifyCommerce.PadLeft(8, '0');

            StringBuilder isoMessage = new StringBuilder();
            isoMessage.Append(MTI);
            isoMessage.Append(bitmap);
            isoMessage.Append(purchaseRequest.PAN.PadLeft(16, '0'));
            isoMessage.Append(processingCode);
            isoMessage.Append(transactionAmount);
            isoMessage.Append(transmissionDateTime);
            isoMessage.Append(systemTraceAuditNumber.ToString("D6"));
            isoMessage.Append(localTransactionTime);
            isoMessage.Append(expirationDate);
            isoMessage.Append(retrievalReferenceNumber);
            isoMessage.Append(authorizationIdentifier.ToString("D6"));
            isoMessage.Append(merchantIdentifier);

            return isoMessage.ToString();
        }
        public static int GetNextSystemTraceAuditNumber()
        {
            systemTraceAuditNumber = (systemTraceAuditNumber + 1) % 1000000;
            return systemTraceAuditNumber;
        }

        public static int GetNextAuthorizationIdentifier()
        {
            authorizationIdentifier = (authorizationIdentifier + 1) % 1000000;
            return authorizationIdentifier;
        }

        public static string GenerateRetrievalReferenceNumber()
        {
            Random random = new Random();
            return random.Next(0, 999999999).ToString("D12");
        }
    }
}