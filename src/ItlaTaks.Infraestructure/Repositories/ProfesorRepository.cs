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

        

        public async Task<List<ProfesorModel>> GetAllByContainName(string name)
        {
            return await _context.Profesores
                .Select(x => x)
                .Where(p => p.Nombre.Contains(name))
                .ToListAsync();
        }

        public async Task<List<ProfesorModel>> GetAllByMateriaId(int id)
        {
            return await _context.Profesores
                .Include(pm => pm.ProfesorMaterias)
                .ThenInclude(m => m.Materia)
                .Select(x => x)
                .Where(p => p.ProfesorMaterias.Any(pm => pm.MateriaId == id))
                .ToListAsync();
        }

        public async Task<List<ProfesorModel>> GetAllWithDetails()
        {
            var entities = await _context.Profesores
                .Include(pm => pm.ProfesorMaterias)
                .ThenInclude(m => m.Materia)
                .ToListAsync();

            return entities;
        }

        public async Task<ProfesorModel> GetByIdWithDetails(int id)
        {
            var entity = await _context.Profesores
                .Include(pm => pm.ProfesorMaterias)
                .ThenInclude(m => m.Materia)
                .Select(x => x)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return entity;
        }

        public override async Task<ProfesorModel> UpdateAsync(ProfesorModel entity)
        {
            var CurrentProfesorMateria = _context.ProfesorMaterias
                .Select(x => x)
                .Where(x => x.IdProfesor == entity.Id)
                .ToList();

            var Deleted = CurrentProfesorMateria
                .Select(x => x)
                .Where(pm => !entity.ProfesorMaterias.Any(e=> e.MateriaId == pm.MateriaId))
                .ToList();

            var Added = entity.ProfesorMaterias
                .Where(e => !CurrentProfesorMateria.Any(pm => pm.MateriaId == e.MateriaId))
                .Select(e => new ProfesorMateriaModel
                {
                    IdProfesor = entity.Id,
                    MateriaId = e.MateriaId
                })
                .ToList();

            _context.RemoveRange(Deleted);
            _context.AddRange(Added);

            _context.Profesores.Update(entity);

            _context.SaveChanges();
            return entity;
        }


    }
}
