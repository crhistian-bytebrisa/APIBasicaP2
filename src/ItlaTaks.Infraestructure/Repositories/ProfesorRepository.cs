using ItlaTaks.Infraestructure.Context;
using ItlaTaks.Infraestructure.Core;
using ItlaTaks.Infraestructure.Interfaces;
using ItlaTaks.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Infraestructure.Repositories
{
    public class ProfesorRepository : BaseRepository<ProfesorModel>, IProfesorRepository
    {

        public ProfesorRepository(TaskContext taskContext) : base(taskContext)
        {
        }

        public async Task<ProfesorModel> GetByName(string name)
        {
            return await _context.Profesores
           .FirstOrDefaultAsync(p => p.Nombre.Contains(name));
        }

        public async Task<ProfesorModel> GetByMateriaId(int id)
        {
            return await _context.Profesores
                .Include(pm => pm.ProfesorMaterias)
                .ThenInclude(m => m.Materia)
                .FirstOrDefaultAsync(p => p.ProfesorMaterias.Any(pm => pm.MateriaId == id));
        }

    }
}
