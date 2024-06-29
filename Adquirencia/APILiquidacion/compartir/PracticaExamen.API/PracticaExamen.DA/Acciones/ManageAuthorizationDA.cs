using MongoDB.Driver;
using PracticaExamen.BC.Modelos;
using PracticaExamen.BW.Interfaces.DA;
using PracticaExamen.DA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.DA.Acciones
{
    public class ManageAuthorizationDA : IManageAuthorizationDA
    {
        private readonly IMongoCollection<AuthorizationDA> autorizaciones;

        public ManageAuthorizationDA(IMongoDatabase database)
        {
            autorizaciones = database.GetCollection<AuthorizationDA
                >("authorizations");
        }

        public async Task<IEnumerable<authorization>> getAuthorizations()
        {
            var autorizaciones = await this.autorizaciones.FindAsync(autorizacion => true);
            return autorizaciones.ToList().Select(autorizacion => new authorization
             {
                 Id = autorizacion.Id,
                 PAN = autorizacion.PAN,
                 ExpirationDate = autorizacion.ExpirationDate,
                 CVV = autorizacion.CVV,
                 CardBrand = autorizacion.CardBrand,
                 PurchaseAmount = autorizacion.PurchaseAmount,
                 SequenceNumber = autorizacion.SequenceNumber,
                 AuthorizationCode = autorizacion.AuthorizationCode,
                 ReferenceTracking = autorizacion.ReferenceTracking,
                 state = autorizacion.state,
                 CreatedIt = autorizacion.CreatedIt,
                 UpdatedIt = autorizacion.UpdatedIt
             });
           
        }

        public async Task<bool> registerAuthorization(authorization authorization)
        {
            var authorizationDA = new AuthorizationDA
            {
                Id = authorization.Id,
                PAN = authorization.PAN,
                ExpirationDate = authorization.ExpirationDate,
                CVV = authorization.CVV,
                CardBrand = authorization.CardBrand,
                PurchaseAmount = authorization.PurchaseAmount,
                SequenceNumber = authorization.SequenceNumber,
                AuthorizationCode = authorization.AuthorizationCode,
                ReferenceTracking = authorization.ReferenceTracking,
                state = authorization.state,
                CreatedIt = authorization.CreatedIt,
                UpdatedIt = authorization.UpdatedIt
            };
            try
            {
                await autorizaciones.InsertOneAsync(authorizationDA);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> updateAuthorization(authorization authorization)
        {
            var authorizationDA = new AuthorizationDA
            {
                Id = authorization.Id,
                PAN = authorization.PAN,
                ExpirationDate = authorization.ExpirationDate,
                CVV = authorization.CVV,
                CardBrand = authorization.CardBrand,
                PurchaseAmount = authorization.PurchaseAmount,
                SequenceNumber = authorization.SequenceNumber,
                AuthorizationCode = authorization.AuthorizationCode,
                ReferenceTracking = authorization.ReferenceTracking,
                state = authorization.state,
                CreatedIt = authorization.CreatedIt,
                UpdatedIt = authorization.UpdatedIt
            };
            try { 
                await autorizaciones.ReplaceOneAsync(autorizacion => autorizacion.Id == authorization.Id, authorizationDA);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
