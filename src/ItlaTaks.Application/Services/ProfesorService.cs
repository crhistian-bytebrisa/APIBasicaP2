using ItlaTaks.Application.DTOs;
using ItlaTaks.Application.DTOs.CreateDTO;
using ItlaTaks.Infraestructure.Exceptions;
using ItlaTaks.Infraestructure.Interfaces;
using ItlaTaks.Infraestructure.Models;
using ItlaTaks.Infraestructure.Repositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Application.Services
{
    public class ProfesorService
    {
        private readonly IProfesorRepository _repository;

        public ProfesorService(ProfesorRepository profesorRepository)
        {
            _repository = profesorRepository;
        }

        public async Task<List<ProfesorDTO>> GetAll()
        {
            var list = _repository.GetAll().Adapt<List<ProfesorDTO>>();
            return list;
        }
        public async Task<ProfesorDTO> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            return entity.Adapt<ProfesorDTO>();
        }

        public async Task<ProfesorDTO> AddAsync(ProfesorCDTO entity)
        {
            var profe = entity.Adapt<ProfesorModel>();
            var result = await _repository.AddAsync(profe);
            return result.Adapt<ProfesorDTO>();
        }

        public async Task<ProfesorDTO> UpdateAsync(ProfesorDTO entity, int id)
        {
            var profe = entity.Adapt<ProfesorModel>();
            profe.Id = id;
            var result = await _repository.UpdateAsync(profe);
            return result.Adapt<ProfesorDTO>();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new MateriaException("No se encontro al profesor en la base de datos.");
            }

            var ent = entity.Adapt<ProfesorModel>();

            await _repository.DeleteAsync(ent);
        }

        public async Task<List<ProfesorDTO>> GetAllWithDetails()
        {
            var list = await _repository.GetAllWithDetails();
            return list.Adapt<List<ProfesorDTO>>();
        }

        public async Task<ProfesorDTO> GetByIdWithDetails(int id)
        {
            var entity = await _repository.GetByIdWithDetails(id);
            return entity.Adapt<ProfesorDTO>();
        }
    }
}
