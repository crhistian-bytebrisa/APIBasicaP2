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

    public class TareasRepository : BaseRepository<TareaModel>, ITareasRepository
    {
        public TareasRepository(TaskContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<TareaModel>> GetByProfesorIdAsync(int profesorId)
        {
            return await _context.Tareas
                .Where(t => t.ProfesorId == profesorId)
                .ToListAsync();
        }
    }
}
