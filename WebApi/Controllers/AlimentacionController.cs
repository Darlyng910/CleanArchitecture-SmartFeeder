using Aplication.DTOs;
using Aplication.UseCases;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlimentacionController : ControllerBase
    {
        private readonly IAlimentacion _alimentacion;
        private readonly RegistrarAlimentacion _registrarAlimentacion;

        public AlimentacionController(
            IAlimentacion alimentacion,
            RegistrarAlimentacion registrarAlimentacion)
        {
            _alimentacion = alimentacion;
            _registrarAlimentacion = registrarAlimentacion;
        }

        [HttpGet("mascota/{mascotaId}")]
        public async Task<IActionResult> GetHistorial(Guid mascotaId)
        {
            var historial = await _alimentacion.ObtenerPorMascota(mascotaId);
            if (!historial.Any())
                return NotFound("No hay registros de alimentación");

            return Ok(historial);
        }

        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] AlimentacionDTOs alimentacionDTO)
        {
            try
            {
                await _registrarAlimentacion.EjecutarAsync(alimentacionDTO);
                return Ok(new { mensaje = "Alimentación registrada correctamente" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
