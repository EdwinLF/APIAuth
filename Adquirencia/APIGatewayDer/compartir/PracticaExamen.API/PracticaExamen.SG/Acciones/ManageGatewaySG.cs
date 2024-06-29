using PracticaExamen.BC.Constantes;
using PracticaExamen.BC.Modelos;
using PracticaExamen.BW.Interfaces.SG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.SG.Acciones
{
    public class ManageGatewaySG : IManageGatewaySG
    {
        private readonly HttpClient httpClient;
        public ManageGatewaySG(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> AuthISO(ISOData iSOData)
        {
            var content = new StringContent(iSOData.ISO, Encoding.UTF8, "application/octet-stream");
            var response = await httpClient.PostAsync(URLAuthorizationConstant.URL, content);
            Console.WriteLine(iSOData.ISO);
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
    }
}
