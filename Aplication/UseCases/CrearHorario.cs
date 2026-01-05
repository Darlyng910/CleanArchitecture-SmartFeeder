using Aplication.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases
{
    public class CrearHorario
    {
        private readonly IHorario _horario;
        private readonly IMascota _mascota;

        public CrearHorario(IHorario horario, IMascota mascota)
        {
            _horario = horario;
            _mascota = mascota;
        }

        public async Task EjecutarAsync(HorarioDTOs dto)
        {
            var mascota = await _mascota.ObtenerID(dto.MascotaId);
            if (mascota == null)
                throw new ArgumentException("La mascota no existe");

            var horario = new Horario
            {
                Id = Guid.NewGuid(),
                MascotaId = dto.MascotaId,
                Hora = dto.Hora,
                CantidadGramos = dto.CantidadGramos
            };

            await _horario.Crear(horario);
        }
    }
}
