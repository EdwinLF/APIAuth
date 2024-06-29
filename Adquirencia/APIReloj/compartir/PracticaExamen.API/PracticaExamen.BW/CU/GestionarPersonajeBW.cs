using PracticaExamen.BW.Interfaces.BW;
using PracticaExamen.BW.Interfaces.SG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BW.CU
{
   public class GestionarPersonajeBW:IGestionarPersonajeBW
    {
        private readonly IGestionarPersonajeSG gestionarPersonajeSG;
        public GestionarPersonajeBW(IGestionarPersonajeSG gestionarPersonajeSG)
        {
            this.gestionarPersonajeSG = gestionarPersonajeSG;
        }

        public Task<string> obtengaTodosLosPersonajes()
        {
            return gestionarPersonajeSG.obtengaTodosLosPersonajes();
        }
    }
}
