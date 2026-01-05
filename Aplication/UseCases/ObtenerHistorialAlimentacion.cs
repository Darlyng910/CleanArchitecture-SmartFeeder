using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases
{
    public class ObtenerHistorialAlimentacion
    {
        private readonly IAlimentacion _alimentacion;

        public ObtenerHistorialAlimentacion(IAlimentacion alimentacion)
        {
            _alimentacion = alimentacion;
        }

        public async Task<IEnumerable<Alimentacion>> EjecutarAsync(Guid mascotaId)
        {
            return await _alimentacion.ObtenerPorMascota(mascotaId);
        }
    }
}
