using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaExamen.BW.Interfaces.BW;

namespace PracticaExamen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajeController : ControllerBase
    {
        private readonly IGestionarPersonajeBW gestionarPersonajeBW;
        public PersonajeController(IGestionarPersonajeBW gestionarPersonajeBW)
        {
            this.gestionarPersonajeBW = gestionarPersonajeBW;
        }
        [HttpGet]
        public Task<string> ObtenerTodosLosPersonajes() { 
            return gestionarPersonajeBW.obtengaTodosLosPersonajes();
        }
    }
}
