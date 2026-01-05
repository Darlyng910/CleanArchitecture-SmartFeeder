using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMascota
    {
        Task<IEnumerable<Mascota>> ObtenerTodosAsync();
        Task<Mascota?> ObtenerPorIdAsync(Guid id);
        Task CrearAsync(Mascota mascota);
        Task ActualizarAsync(Mascota mascota);
    }
}
