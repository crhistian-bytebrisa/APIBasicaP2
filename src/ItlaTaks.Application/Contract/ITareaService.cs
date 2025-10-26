using ItlaTaks.Application.DTOs;
using ItlaTaks.Application.DTOs.CreateDTO;

namespace ItlaTaks.Application.Contract
{
    public interface ITareaService
    {
        Task<TareaDTO> AddAsync(TareaCDTO entity);
        Task DeleteAsync(int id);
        Task<List<TareaDTO>> GetAll();
        Task<List<TareaDTO>> GetAllByProfesorIdAsync(int profesorId);
        Task<List<TareaDTO>> GetAllWithDetails();
        Task<TareaDTO> GetById(int id);
        Task<TareaDTO> GetByIdWithDetails(int id);
        Task<TareaDTO> UpdateAsync(TareaDTO entity, int id);
    }
}