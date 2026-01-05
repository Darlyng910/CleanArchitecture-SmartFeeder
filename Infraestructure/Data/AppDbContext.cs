using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Alimentacion> Alimentaciones { get; set; }
    }
}
