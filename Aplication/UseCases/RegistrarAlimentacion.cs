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
    public class RegistrarAlimentacion
    {
        private readonly IAlimentacion _alimentacion;
        private readonly IMascota _mascota;

        public RegistrarAlimentacion(IAlimentacion alimentacion, IMascota mascota)
        {
            _alimentacion = alimentacion;
            _mascota = mascota;
        }

        public async Task EjecutarAsync(AlimentacionDTOs dto)
        {
            var mascota = await _mascota.ObtenerID(dto.MascotaId);
            if (mascota == null)
                throw new ArgumentException("La mascota no existe");

            var alimentacion = new Alimentacion
            {
                Id = Guid.NewGuid(),
                MascotaId = dto.MascotaId,
                CantidadGramos = dto.CantidadGramos,
                FechaHora = DateTime.Now
            };

            await _alimentacion.Registrar(alimentacion);
        }
    }
}
