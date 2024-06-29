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
    public class ManageGateway: IManageGatewayBW
    {
        private readonly IManageGatewaySG _manageGatewaySG;
        public ManageGateway(IManageGatewaySG manageGatewaySG)
        {
            _manageGatewaySG = manageGatewaySG;
        }

        public async  Task<string> AuthISO(ISOData iSOData)
        {
           return await _manageGatewaySG.AuthISO(iSOData);
        }
    }
}
