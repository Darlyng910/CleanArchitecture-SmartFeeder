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
    public class AlimentacionRepository : IAlimentacion
    {
        private readonly AppDbContext _appDbContext;

        public AlimentacionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Alimentacion>> ObtenerPorMascota(Guid mascotaId)
        {
            return await _appDbContext.Alimentaciones
                .Where(a => a.MascotaId == mascotaId)
                .OrderByDescending(a => a.FechaHora)
                .ToListAsync();
        }

        public async Task<IEnumerable<Alimentacion>> ObtenerTodo()
        {
            return await _appDbContext.Alimentaciones
                .Include(a => a.Mascota) 
                .OrderByDescending(a => a.FechaHora)
                .ToListAsync();
        }

        public async Task Registrar(Alimentacion alimentacion)
        {
            _appDbContext.Alimentaciones.Add(alimentacion);
            await _appDbContext.SaveChangesAsync();
        }


    }
}
