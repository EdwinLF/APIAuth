using PracticaExamen.BC.Constantes;
using PracticaExamen.BW.Interfaces.SG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.SG.Acciones
{
    public class GestionarPersonajeSG: IGestionarPersonajeSG
    {
        private readonly HttpClient httpClient;
        public GestionarPersonajeSG(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> obtengaTodosLosPersonajes()
        {
              HttpResponseMessage respueta = await httpClient.GetAsync(URLPersonajeConstante.URL);
            if (!respueta.IsSuccessStatusCode)
             throw new HttpRequestException($"Error en {URLPersonajeConstante.URL} al obtner el mensaje"); 

             return await respueta.Content.ReadAsStringAsync();

           
        }
    }
}
