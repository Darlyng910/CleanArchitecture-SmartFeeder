using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases
{
    public class ActualizarMascota
    {
        private readonly IMascota _mascota;

        public ActualizarMascota(IMascota mascota)
        {
            _mascota = mascota;
        }

        public async Task EjecutarAsync(Mascota mascota)
        {
            await _mascota.Actualizar(mascota);
        }
    }
}
