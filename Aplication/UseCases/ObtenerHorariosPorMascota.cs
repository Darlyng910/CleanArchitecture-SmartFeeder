using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases
{
    public class ObtenerHorariosPorMascota
    {
        private readonly IHorario _horario;

        public ObtenerHorariosPorMascota(IHorario horario)
        {
            _horario = horario;
        }

        public async Task<IEnumerable<Horario>> EjecutarAsync(Guid mascotaId)
        {
            return await _horario.ObtenerPorMascota(mascotaId);
        }
    }
}
