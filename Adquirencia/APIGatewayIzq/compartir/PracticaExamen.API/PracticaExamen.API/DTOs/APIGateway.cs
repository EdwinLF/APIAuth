using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaExamen.API.Utilitarios;
using System.Text;

namespace PracticaExamen.API.DTOs
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIGateway : ControllerBase
    {

        public APIGateway()
        {
        }
        [HttpPost("auth")]
        public IActionResult Get(string message)
        {
            try
            {
                var isoDTO = IsoDTOMapper.DecodeIso(message);
                return Ok(isoDTO);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest($"Invalid ISO message: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error decoding ISO message: {ex.Message}");
            }
        }
    }
}
