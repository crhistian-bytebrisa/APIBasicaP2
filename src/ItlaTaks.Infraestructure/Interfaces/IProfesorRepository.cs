using ItlaTaks.Infraestructure.Interfaces;
using ItlaTaks.Infraestructure.Models;

namespace ItlaTaks.Infraestructure.Repositories
{
    public interface IProfesorRepository : IBaseRepository<ProfesorModel>
    {
        Task<List<ProfesorModel>> GetAllByContainName(string name);
        Task<List<ProfesorModel>> GetAllByMateriaId(int id);
        Task<List<ProfesorModel>> GetAllWithDetails();
        Task<ProfesorModel> GetByIdWithDetails(int id);
    }
}