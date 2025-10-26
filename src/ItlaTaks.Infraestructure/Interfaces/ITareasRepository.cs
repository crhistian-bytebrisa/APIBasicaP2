using ItlaTaks.Infraestructure.Interfaces;
using ItlaTaks.Infraestructure.Models;

namespace ItlaTaks.Infraestructure.Repositories
{
    public interface ITareasRepository : IBaseRepository<TareaModel>
    {
        Task<List<TareaModel>> GetAllByProfesorIdAsync(int profesorId);
        Task<List<TareaModel>> GetAllWithDetails();
        Task<TareaModel> GetByIdWithDetails(int id);
    }
}