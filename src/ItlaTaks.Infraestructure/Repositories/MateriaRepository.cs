using ItlaTaks.Domain.Entities;
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
    public class MateriaRepository : BaseRepository<MateriaModel>, IMateriaRepository
    {
        public MateriaRepository(TaskContext dbContext) : base(dbContext)
        {
        }

        public async Task<MateriaModel> GetByNameAsync(string name)
        {
            return await _context.Materias.FirstOrDefaultAsync(x => x.Nombre == name);
        }
    }
}
