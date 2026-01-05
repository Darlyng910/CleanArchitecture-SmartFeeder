using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases
{
    public class ObtenerMascotas
    {
        private readonly IMascota _mascota;

        public ObtenerMascotas(IMascota mascota)
        {
            _mascota = mascota;
        }

        public async Task<IEnumerable<Mascota>> EjecutarAsync()
        {
            return await _mascota.All();
        }
    }
}
