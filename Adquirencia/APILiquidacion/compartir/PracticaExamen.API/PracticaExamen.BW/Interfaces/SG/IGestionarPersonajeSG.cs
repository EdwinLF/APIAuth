using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BW.Interfaces.SG
{
    public interface IGestionarPersonajeSG
    {
        Task<string> obtengaTodosLosPersonajes();
    }
}
