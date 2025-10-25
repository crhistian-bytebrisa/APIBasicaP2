using ItlaTaks.Infraestructure.Context;
using ItlaTaks.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Infraestructure.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly TaskContext _context;
        public BaseRepository(TaskContext task)
        {
            _context = task;
        }

        public Task<T> GetById(int id)
        {
            var entity = _context.Set<T>().Find(id);
            return Task.FromResult(entity);
        }

        public Task<List<T>> GetAll()
        {
            var entities = _context.Set<T>().ToList();
            return Task.FromResult(entities);
        }

        public Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
