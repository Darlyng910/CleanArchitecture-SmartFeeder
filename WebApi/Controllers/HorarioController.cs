using Aplication.DTOs;
using Aplication.UseCases;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private readonly IHorario _horario;
        private readonly CrearHorario _crearHorario;

        public HorarioController(
            IHorario horario,
            CrearHorario crearHorario)
        {
            _horario = horario;
            _crearHorario = crearHorario;
        }

        [HttpGet("mascota/{mascotaId}")]
        public async Task<IActionResult> GetByMascota(Guid mascotaId)
        {
            var horarios = await _horario.ObtenerPorMascota(mascotaId);
            if (!horarios.Any())
                return NotFound("No hay horarios registrados");

            return Ok(horarios);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HorarioDTOs horarioDTO)
        {
            try
            {
                await _crearHorario.EjecutarAsync(horarioDTO);
                return Ok(new { mensaje = "Horario creado correctamente" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _horario.Eliminar(id);
            return Ok(new { mensaje = "Horario eliminado correctamente" });
        }
    }
}
