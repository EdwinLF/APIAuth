using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.SG.Entidades
{
    internal class ISO
    {
        public string MTI { get; set; }
        public string PrimaryBitmap { get; set; }
        public string CardNumber { get; set; }
        public string ProcessingCode { get; set; }
        public string TransactionAmount { get; set; }
        public string TransmissionDateTime { get; set; }
        public string SystemTraceAuditNumber { get; set; }
        public string LocalTransactionTime { get; set; }
        public string ExpirationDate { get; set; }
        public string RetrievalReferenceNumber { get; set; }
        public string AuthorizationIdentifier { get; set; }
        public string MerchantIdentifier { get; set; }
    }
}
