using PracticaExamen.BC.Modelos;
using PracticaExamen.BW.Interfaces.BW;
using PracticaExamen.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BW.CU
{
    public class ManageAuthorizationBW : IManageAuthorizationBW
    {
        private readonly IManageAuthorizationDA manageAuthorizationDA;
        public ManageAuthorizationBW(IManageAuthorizationDA manageAuthorizationDA)
        {
            this.manageAuthorizationDA = manageAuthorizationDA;
        }
        public Task<IEnumerable<authorization>> getAuthorizations()
        {
           return manageAuthorizationDA.getAuthorizations();
        }

        public Task<bool> registerAuthorization(authorization authorization)
        {
           return manageAuthorizationDA.registerAuthorization(authorization);
        }

        public Task<bool> updateAuthorization(authorization authorization)
        {
           return manageAuthorizationDA.updateAuthorization(authorization);
        }
    }
}
