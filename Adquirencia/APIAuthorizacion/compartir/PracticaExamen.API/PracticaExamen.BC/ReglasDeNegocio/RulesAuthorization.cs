using PracticaExamen.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PracticaExamen.BC.ReglasDeNegocio
{
    public class RulesAuthorization
    {
        public static (bool, string) AuthorizationValid(authorization authorization) {
            if (authorization.PAN is null)
                return (false, "La autorización no es válida, el PAN es nulo");
            if (authorization.PAN.Equals(string.Empty))
                return (false, "La autorización no es válida, el PAN está vacío");
            if (!LuhnCheck(authorization.PAN))
                return (false, "La autorización no es válida, el PAN no pasa el algoritmo de Luhn");

            if (authorization.ExpirationDate is null)
                return (false, "La autorización no es válida, la fecha de expiración es nula");
            if (!Regex.IsMatch(authorization.ExpirationDate, @"^(0[1-9]|1[0-2])-(\d{4})$"))
                return (false, "La autorización no es válida, la fecha de expiración no tiene el formato MM-YYYY");

            if (authorization.CVV is null)
                return (false, "La autorización no es válida, el CVV es nulo");
            if (!Regex.IsMatch(authorization.CVV, @"^\d{3}$"))
                return (false, "La autorización no es válida, el CVV debe tener 3 dígitos");

            if (authorization.CardBrand is null)
                return (false, "La autorización no es válida, la marca de la tarjeta es nula");
            if (!new[] { "VISA", "Mastercard", "American Express" }.Contains(authorization.CardBrand))
                return (false, "La autorización no es válida, la marca de la tarjeta debe ser VISA, Mastercard o American Express");

            if (authorization.SequenceNumber < 1 || authorization.SequenceNumber > 999999)
                return (false, "La autorización no es válida, el número de secuencia debe estar entre 1 y 999999");

            if (authorization.AuthorizationCode < 1 || authorization.AuthorizationCode > 999999)
                return (false, "La autorización no es válida, el código de autorización debe estar entre 1 y 999999");

            if (authorization.ReferenceTracking < 1 || authorization.ReferenceTracking > 999999999999)
                return (false, "La autorización no es válida, el seguimiento de referencia debe tener hasta 12 dígitos");

            if (authorization.state is null)
                return (false, "La autorización no es válida, el estado es nulo");
            if (!new[] { "Aprobado", "Declinado", "Liquidado" }.Contains(authorization.state))
                return (false, "La autorización no es válida, el estado debe ser Aprobado, Declinado o Liquidado");

            if (authorization.CreatedIt == DateTime.MinValue)
                return (false, "La autorización no es válida, la fecha de creación es la mínima");

            if (authorization.UpdatedIt == DateTime.MinValue)
                return (false, "La autorización no es válida, la fecha de actualización es la mínima");

            return (true, string.Empty);
        }
        public static bool LuhnCheck(string pan)
        {
            int sum = 0;
            bool alternate = false;
            for (int i = pan.Length - 1; i >= 0; i--)
            {
                char[] nx = pan.ToArray();
                int n = int.Parse(nx[i].ToString());
                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                    {
                        n -= 9;
                    }
                }
                sum += n;
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }

        public static (bool, string) AuthorizationCodeValid(authorization authorization)
        {
            if (authorization.AuthorizationCode.Equals(0))
                return (false, "El código de autorización no es válido, es 0");
            return (true, string.Empty);
        }
    }
}
