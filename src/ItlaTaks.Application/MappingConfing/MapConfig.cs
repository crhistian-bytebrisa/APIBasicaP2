using ItlaTaks.Application.DTOs;
using ItlaTaks.Application.DTOs.CreateDTO;
using ItlaTaks.Infraestructure.Models;
using Mapster;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Application.MappingConfing
{
    public class MapConfig
    {
        public void RegisterMappins()
        {
            //Encargados de convertir a la lista de enteros en ProfesorMateriaModel
            TypeAdapterConfig<ProfesorCDTO, ProfesorModel>.NewConfig()
                .Map(
                    dest => dest.ProfesorMaterias,
                    src => src.MateriaIds != null ? 
                        src.MateriaIds.Select(id => new ProfesorMateriaModel { MateriaId = id }).ToList() 
                        : new List<ProfesorMateriaModel>()
                );

            TypeAdapterConfig<ProfesorDTO, ProfesorModel>.NewConfig()
                .Map(
                    dest => dest.ProfesorMaterias,
                    src => src.MateriasId != null && src.Id != 0 ?
                        src.MateriasId.Select((id) => new ProfesorMateriaModel { MateriaId = id, IdProfesor = src.Id}).ToList()
                        : new List<ProfesorMateriaModel>()
                        );

            //Encargado de separar los datos de ProfesorMaterias en su Id (MateriaId) y su MateriaDTO (Materia pero convertida a DTO).
            TypeAdapterConfig<ProfesorModel, ProfesorDTO>.NewConfig()
                .Map(
                    dest => dest.Materias,
                    src => src.ProfesorMaterias != null ?
                        src.ProfesorMaterias.Select(PM => PM.Materia.Adapt<MateriaDTO>()).ToList()
                        : new List<MateriaDTO>()
                )
                .Map(
                    dest => dest.MateriasId,
                    src => src.ProfesorMaterias != null ?
                        src.ProfesorMaterias.Select(PM => PM.MateriaId).ToList()
                        : new List<int>()
                );

            //Encargado de convertir los datos adicionales de TareaModel en sus respectivos DTO (Materia y Profesor en este caso).
            TypeAdapterConfig<TareaModel, TareaDTO>.NewConfig()
               .Map(
                   dest => dest.Profesor,
                   src => src.Profesor != null ? src.Profesor.Adapt<ProfesorDTO>() : null
               )
               .Map(
                   dest => dest.Materia,
                   src => src.Materia != null ? src.Materia.Adapt<MateriaDTO>() : null
               );

        }
    }
}
