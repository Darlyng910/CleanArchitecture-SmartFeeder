using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Mascota
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especie { get; set; } = string.Empty;
        public int Edad { get; set; }
        public ICollection<Horario> Horarios { get; set; } = new List<Horario>();
        public ICollection<Alimentacion> Alimentaciones { get; set; } = new List<Alimentacion>();
    }
}
