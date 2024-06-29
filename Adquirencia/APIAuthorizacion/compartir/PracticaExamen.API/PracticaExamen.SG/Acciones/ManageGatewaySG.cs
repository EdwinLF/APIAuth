using PracticaExamen.BC.Constantes;
using PracticaExamen.BC.Modelos;
using PracticaExamen.BW.Interfaces.SG;
using PracticaExamen.SG.Entidades;
using PracticaExamen.SG.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        public async Task<PurchaseResponse> purchaseResquestIntent(PurchaseRequest purchaseRequest)
        {
            string isoMessage = await ManageISOMapper.MapPurchaseRequestToISO(purchaseRequest);
            string jsonRequest = JsonSerializer.Serialize(new ISOCode() { ISO = isoMessage });
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(URLGatewayConstante.URL, content);
            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
            PurchaseResponse purchaseResponse = new PurchaseResponse()
            {
                PAN = message,
                trakingCode = "12243",
                authorizationCode = "00023423",
                referenceCode = "8738211",
                amount = 1000,
                responseAuthCode = "Authdos",

            };
            return purchaseResponse;
        }
    }
}
