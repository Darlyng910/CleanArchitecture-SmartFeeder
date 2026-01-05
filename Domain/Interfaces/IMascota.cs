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
        Task<IEnumerable<Mascota>> All();
        Task<Mascota?> ObtenerID(Guid id);
        Task Crear(Mascota mascota);
        Task Actualizar(Mascota mascota);
    }
}
