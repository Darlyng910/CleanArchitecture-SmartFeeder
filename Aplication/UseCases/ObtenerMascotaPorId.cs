using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases
{
    public class ObtenerMascotaPorId
    {
        private readonly IMascota _mascota;

        public ObtenerMascotaPorId(IMascota mascota)
        {
            _mascota = mascota;
        }

        public async Task<Mascota?> EjecutarAsync(Guid id)
        {
            return await _mascota.ObtenerID(id);
        }
    }
}
