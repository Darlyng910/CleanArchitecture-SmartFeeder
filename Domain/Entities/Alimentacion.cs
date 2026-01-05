using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Alimentacion
    {
        public Guid Id { get; set; }
        public DateTime FechaHora { get; set; }
        public int CantidadGramos { get; set; }
        public Guid MascotaId { get; set; }
    }
}
