using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class HorarioResponseDTOs
    {
        public Guid Id { get; set; }
        public Guid MascotaId { get; set; }
        public TimeOnly Hora { get; set; }
        public int CantidadGramos { get; set; }
    }
}