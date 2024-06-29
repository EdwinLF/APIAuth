using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.DA.Entidades
{
    public class AuthorizationDA
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("PAN")]
        public string PAN { get; set; }
        [BsonElement("FechaVencimiento")]
        public string ExpirationDate { get; set; }
        [BsonElement("CVV")]
        public string CVV { get; set; }
        [BsonElement("MarcaTarjeta")]
        public string CardBrand { get; set; }
        [BsonElement("MontoCompra")]
        public double PurchaseAmount { get; set; }
        [BsonElement("NumeroSecuenciaSistema ")]
        public int SequenceNumber { get; set; }
        [BsonElement("IdentificadorAutorizacion")]
        public int AuthorizationCode { get; set; }
        [BsonElement("NumeroReferenciaSeguimiento")]
        public int ReferenceTracking { get; set; }
        [BsonElement("Estado")]
        public string state { get; set; }
        [BsonElement("FechaCreacion")]
        public DateTime CreatedIt { get; set; }
        [BsonElement("FechaActualizacion")]
        public DateTime UpdatedIt { get; set; }
    }
}
