using ItlaTaks.Infraestructure.Models;

namespace ItlaTaks.Infraestructure.Interfaces
{
    public interface IMateriaRepository : IBaseRepository<MateriaModel>
    {
        Task<MateriaModel> GetByNameAsync(string name);
    }
}