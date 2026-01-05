using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IHorario
    {
        Task<IEnumerable<Horario>> ObtenerPorMascota(Guid mascotaId);
        Task Crear(Horario horario);
        Task Eliminar(Guid id);
    }
}
