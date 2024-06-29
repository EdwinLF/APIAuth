using PracticaExamen.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BW.Interfaces.BW
{
    public interface IManageAuthorizationBW
    {
        public Task<bool> registerAuthorization(authorization authorization);
        public Task<bool> updateAuthorization(authorization authorization);
        public Task<IEnumerable<authorization>> getAuthorizations();
        
    }
}
