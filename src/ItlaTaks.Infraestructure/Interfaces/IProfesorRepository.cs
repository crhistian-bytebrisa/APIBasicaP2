using ItlaTaks.Infraestructure.Models;

namespace ItlaTaks.Infraestructure.Interfaces
{
    public interface IProfesorRepository : IBaseRepository<ProfesorModel>
    {
        Task<ProfesorModel> GetByMateriaId(int id);
        Task<ProfesorModel> GetByName(string name);
    }
}