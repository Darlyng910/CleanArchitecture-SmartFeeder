using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class MascotaRepository : IMascota
    {
        private readonly AppDbContext _appDbContext;

        public MascotaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Mascota>> All()
        {
            return await _appDbContext.Mascotas.ToListAsync();
        }

        public async Task<Mascota?> ObtenerID(Guid id)
        {
            return await _appDbContext.Mascotas.FindAsync(id);
        }

        public async Task Crear(Mascota mascota)
        {
            _appDbContext.Mascotas.Add(mascota);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Actualizar(Mascota mascota)
        {
            _appDbContext.Mascotas.Update(mascota);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
