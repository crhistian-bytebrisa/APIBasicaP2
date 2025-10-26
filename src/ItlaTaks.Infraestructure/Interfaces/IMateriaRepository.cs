using ItlaTaks.Infraestructure.Models;

namespace ItlaTaks.Infraestructure.Interfaces
{
    public interface IMateriaRepository : IBaseRepository<MateriaModel>
    {
        Task<List<MateriaModel>> GetAllByContainName(string name);
    }
}