using ItlaTaks.Application.DTOs;
using ItlaTaks.Application.DTOs.CreateDTO;

namespace ItlaTaks.Application.Contract
{
    public interface IMateriaService
    {
        Task<MateriaDTO> AddAsync(MateriaCDTO entity);
        Task DeleteAsync(int id);
        Task<List<MateriaDTO>> GetAll();
        Task<MateriaDTO> GetById(int id);
        Task<List<MateriaDTO>> GetByNameAsync(string name);
        Task<MateriaDTO> UpdateAsync(MateriaDTO entity, int id);
    }
}