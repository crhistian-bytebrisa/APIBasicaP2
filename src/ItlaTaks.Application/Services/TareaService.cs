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
    public class TareaService
    {
        private readonly ITareasRepository _repository;

        public TareaService(ITareasRepository tareasRepository)
        {
            _repository = tareasRepository;
        }

        public async Task<List<TareaDTO>> GetAll()
        {
            var list = _repository.GetAll().Adapt<List<TareaDTO>>();
            return list;
        }
        public async Task<TareaDTO> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            return entity.Adapt<TareaDTO>();
        }

        public async Task<TareaDTO> AddAsync(TareaCDTO entity)
        {
            var tarea = entity.Adapt<TareaModel>();
            var result = await _repository.AddAsync(tarea);
            return result.Adapt<TareaDTO>();
        }

        public async Task<TareaDTO> UpdateAsync(TareaDTO entity, int id)
        {
            var tarea = entity.Adapt<TareaModel>();
            tarea.Id = id;
            var result = await _repository.UpdateAsync(tarea);
            return result.Adapt<TareaDTO>();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new MateriaException("No se encontro la tarea en la base de datos.");
            }

            var ent = entity.Adapt<TareaModel>();

            await _repository.DeleteAsync(ent);
        }

        public async Task<List<TareaDTO>> GetAllWithDetails()
        {
            var entities = await _repository.GetAllWithDetails();
            return entities.Adapt<List<TareaDTO>>();
        }

        public async Task<TareaDTO> GetByIdWithDetails(int id)
        {
            var entity = await _repository.GetByIdWithDetails(id);
            return entity.Adapt<TareaDTO>();
        }
        public async Task<List<TareaDTO>> GetAllByProfesorIdAsync(int profesorId)
        {
            var entities = await _repository.GetAllByProfesorIdAsync(profesorId);
            return entities.Adapt<List<TareaDTO>>();
        }
    }
}
