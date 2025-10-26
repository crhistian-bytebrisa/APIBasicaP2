using ItlaTaks.Infraestructure.Models;

namespace ItlaTaks.Infraestructure.Interfaces
{
    public interface ITareasRepository : IBaseRepository<TareaModel>
    {
        Task<List<TareaModel>> GetByProfesorIdAsync(int profesorId);
    }
}