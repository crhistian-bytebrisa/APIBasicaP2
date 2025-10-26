using ItlaTaks.Application.DTOs;
using ItlaTaks.Application.DTOs.CreateDTO;

namespace ItlaTaks.Application.Contract
{
    public interface IProfesorService
    {
        Task<ProfesorDTO> AddAsync(ProfesorCDTO entity);
        Task DeleteAsync(int id);
        Task<List<ProfesorDTO>> GetAll();
        Task<List<ProfesorDTO>> GetAllWithDetails();
        Task<ProfesorDTO> GetById(int id);
        Task<ProfesorDTO> GetByIdWithDetails(int id);
        Task<ProfesorDTO> UpdateAsync(ProfesorDTO entity, int id);
    }
}