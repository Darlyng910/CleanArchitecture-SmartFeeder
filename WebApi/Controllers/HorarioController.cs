using Aplication.DTOs;
using Aplication.UseCases;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private readonly IHorario _horario;
        private readonly CrearHorario _crearHorario;
        private readonly IMapper _mapper;

        public HorarioController(
            IHorario horario,
            CrearHorario crearHorario,
            IMapper mapper)
        {
            _horario = horario;
            _crearHorario = crearHorario;
            _mapper = mapper;
        }

        [HttpGet("mascota/{mascotaId}")]
        public async Task<IActionResult> GetByMascota(Guid mascotaId)
        {
            var horarios = await _horario.ObtenerPorMascota(mascotaId);

            if (!horarios.Any())
                return Ok(new List<HorarioResponseDTOs>());

            var response = _mapper.Map<IEnumerable<HorarioResponseDTOs>>(horarios);
            return Ok(response);
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
