using PracticaExamen.API.DTOs;
using PracticaExamen.BC.Modelos;

namespace PracticaExamen.API.Utilitarios
{
    public class ISODTOMapper
    {
        public static ISOData DTOISO(ISODataDTO iSODataDTO)
        {
            return new ISOData
            {
                ISO = iSODataDTO.ISO
            };
        }
        public static ISODataDTO ISODTO(ISOData iSOData)
        {
            return new ISODataDTO
            {
                ISO = iSOData.ISO
            };
        }
    }
}
