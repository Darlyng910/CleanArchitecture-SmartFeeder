using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases
{
    public class EliminarHorario
    {
        private readonly IHorario _horario;

        public EliminarHorario(IHorario horario)
        {
            _horario = horario;
        }

        public async Task EjecutarAsync(Guid id)
        {
            await _horario.Eliminar(id);
        }
    }
}
