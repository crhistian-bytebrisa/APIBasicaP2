using ItlaTaks.Application.Contract;
using ItlaTaks.Application.DTOs;
using ItlaTaks.Application.DTOs.CreateDTO;
using ItlaTaks.Infraestructure.Exceptions;
using ItlaTaks.Infraestructure.Interfaces;
using ItlaTaks.Infraestructure.Models;
using Mapster;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Application.Services
{
    public class MateriaService : IMateriaService
    {
        private readonly IMateriaRepository _repository;

        public MateriaService(IMateriaRepository tareasRepository)
        {
            _repository = tareasRepository;
        }

        public async Task<List<MateriaDTO>> GetAll()
        {
            var list = _repository.GetAll().Adapt<List<MateriaDTO>>();
            return list;
        }

        public async Task<MateriaDTO> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            return entity.Adapt<MateriaDTO>();
        }

        public async Task<MateriaDTO> AddAsync(MateriaCDTO entity)
        {
            var materia = entity.Adapt<MateriaModel>();
            var result = await _repository.AddAsync(materia);
            return result.Adapt<MateriaDTO>();
        }

        public async Task<MateriaDTO> UpdateAsync(MateriaDTO entity, int id)
        {
            var materia = entity.Adapt<MateriaModel>();
            materia.Id = id;
            var result = await _repository.UpdateAsync(materia);
            return result.Adapt<MateriaDTO>();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new MateriaException("No se encontro la materia en la base de datos.");
            }

            var ent = entity.Adapt<MateriaModel>();

            await _repository.DeleteAsync(ent);
        }

        public async Task<List<MateriaDTO>> GetByNameAsync(string name)
        {
            var entity = await _repository.GetAllByContainName(name);
            return entity.Adapt<List<MateriaDTO>>();
        }

    }
}
