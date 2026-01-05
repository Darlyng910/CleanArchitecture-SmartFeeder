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
    public class CrearMascota
    {
        private readonly IMascota _mascota;

        public CrearMascota(IMascota mascota)
        {
            _mascota = mascota;
        }

        public async Task EjecutarAsync(MascotaDTOs dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                throw new ArgumentException("Nombre inválido");

            var mascota = new Mascota
            {
                Id = Guid.NewGuid(),
                Nombre = dto.Nombre,
                Especie = dto.Especie,
                Edad = dto.Edad
            };

            await _mascota.Crear(mascota);
        }
    }
}
