using PracticaExamen.BC.Constantes;
using PracticaExamen.BC.Modelos;
using PracticaExamen.BW.Interfaces.SG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PracticaExamen.SG.Acciones
{
    public class ManageGatewaySG : IManageGatewaySG
    {
        private readonly HttpClient httpClient;
        public ManageGatewaySG(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async  Task<string> getAuth(string data)
        {
            HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response= await httpClient.PostAsync(URLAuthorizationConstant.URL, content);
            if(!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error en {URLAuthorizationConstant.URL} al obtener el mensaje");
            return response.ToString(); 
        }

        public async Task<PurchaseResponse> purchaseResquestIntent(PurchaseRequest purchaseRequest)
        {
            string jsonRequest = JsonSerializer.Serialize(purchaseRequest);
            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(URLAuthorizationConstant.URL, content);
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Error en {URLAuthorizationConstant.URL} al obtener el mensaje");

            string jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonResponse);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            PurchaseResponse purchaseResponse = JsonSerializer.Deserialize<PurchaseResponse>(jsonResponse, options);

            Console.WriteLine(purchaseResponse.PAN);
            return purchaseResponse;
        }
    }
}
