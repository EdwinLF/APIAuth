using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PracticaExamen.BC.Modelos
{
    public class authorization
    {
        public ObjectId Id { get; set; }
        public string PAN { get; set; }
        public string ExpirationDate{ get; set; }
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
