using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BC.Modelos
{
    public class PurchaseRequest
    {
        public string PAN { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public string Amount { get; set; }
        public string identifyCommerce { get; set; }
        public string identifyTerminal { get; set; }
    }
}
