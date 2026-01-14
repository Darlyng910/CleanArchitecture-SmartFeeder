using Aplication.DTOs;
using Aplication.UseCases;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly IMascota _mascota;
        private readonly IMapper _mapper;
        private readonly CrearMascota _crearMascota;

        public MascotaController(
            IMascota mascota,
            IMapper mapper,
            CrearMascota crearMascota)
        {
            _mascota = mascota;
            _mapper = mapper;
            _crearMascota = crearMascota;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mascotas = await _mascota.All();
            if (!mascotas.Any())
                return NotFound("No hay mascotas registradas");

            return Ok(_mapper.Map<IEnumerable<MascotaResponseDTOs>>(mascotas));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var mascota = await _mascota.ObtenerID(id);
            if (mascota == null)
                return NotFound(new { mensaje = "Mascota no encontrada" });

            return Ok(_mapper.Map<MascotaResponseDTOs>(mascota));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MascotaDTOs mascotaDTO)
        {
            try
            {
                var mascota = _mapper.Map<Mascota>(mascotaDTO);
                await _crearMascota.EjecutarAsync(mascotaDTO);

                return Ok(new { mensaje = "Mascota creada correctamente" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
