using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class AlimentacionResponseDTOs
    {
        public string Mascota { get; set; } = string.Empty;
        public int CantidadGramos { get; set; }
        public DateTime FechaHora { get; set; }
    }
}

