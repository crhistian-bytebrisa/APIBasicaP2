using FluentValidation.Results;
using ItlaTaks.Application.DTOs;
using ItlaTaks.Application.DTOs.CreateDTO;
using ItlaTaks.Application.MappingConfing;
using ItlaTaks.Application.Services;
using ItlaTaks.Application.Validations;
using ItlaTaks.Application.Validations.Create;
using ItlaTaks.Infraestructure.Context;
using ItlaTaks.Infraestructure.Models;
using ItlaTaks.Infraestructure.Repositories;
using System.Text.Json;

namespace Pruebas
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var map = new MapConfig();
            map.RegisterMappins();

            var tareas = new TareaService(new TareasRepository(new TaskContext()));
            var materias = new MateriaService(new MateriaRepository(new TaskContext()));
            var profes = new ProfesorService(new ProfesorRepository(new TaskContext()));

            

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            var prof = new ProfesorCDTO()
            {
                Nombre = "Federico",
                Apellido = "fernandes",
                MateriaIds = new List<int>() { 1, 2 }
            };

            await materias.AddAsync(new MateriaCDTO() { Nombre = "Programacion", Creditos = 4 });
            await profes.AddAsync(prof);

            var profesores = await profes.GetAllWithDetails();

            var profedto = new ProfesorDTO()
            {
                Id = 2,
                Nombre = "Jhan",
                Apellido = "Juanetes",
                MateriasId = new List<int>() { 1}
            };

            await profes.UpdateAsync(profedto,2);
        }
    }
}
