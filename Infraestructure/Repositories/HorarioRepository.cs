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
    public class HorarioRepository : IHorario
    {
        private readonly AppDbContext _appDbContext;

        public HorarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Horario>> ObtenerPorMascota(Guid mascotaId)
        {
            return await _appDbContext.Horarios
                .Where(h => h.MascotaId == mascotaId)
                .ToListAsync();
        }

        public async Task Crear(Horario horario)
        {
            _appDbContext.Horarios.Add(horario);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Eliminar(Guid id)
        {
            var horario = await _appDbContext.Horarios.FindAsync(id);
            if (horario != null)
            {
                _appDbContext.Horarios.Remove(horario);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
