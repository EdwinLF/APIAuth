using PracticaExamen.BC.Modelos;
using PracticaExamen.BW.Interfaces.BW;
using PracticaExamen.BW.Interfaces.SG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BW.CU
{
    public class ManageGatewayBW : IManageGatewayBW
    {
        private readonly IManageGatewaySG _manageGatewaySG;
        public ManageGatewayBW(IManageGatewaySG manageGatewaySG)
        {
            _manageGatewaySG = manageGatewaySG;
        }
        public async Task<PurchaseResponse> purchaseResquestIntent(PurchaseRequest purchaseRequest)
        {
            return await _manageGatewaySG.purchaseResquestIntent(purchaseRequest);
        }
    }
}
