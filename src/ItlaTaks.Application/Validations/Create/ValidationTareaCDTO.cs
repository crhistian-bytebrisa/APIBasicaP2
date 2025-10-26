using FluentValidation;
using ItlaTaks.Application.DTOs.CreateDTO;
using ItlaTaks.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Application.Validations.Create
{
    public class ValidationTareaCDTO : AbstractValidator<TareaCDTO>
    {
        private readonly TaskContext _context;
        public ValidationTareaCDTO(TaskContext context)
        {
            _context = context;

            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
                .MaximumLength(100).WithMessage("El campo {PropertyName} no puede poner mas de 100 caracteres.")
                .MinimumLength(10).WithMessage("El campo {PropertyName} no puede poner menos de 10 caracteres.")
                .Must(verificateTitle).WithMessage("Ya existe una Tarea con ese {PropertyName}");

            RuleFor(x => x.Descripcion)
               .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
               .MaximumLength(200).WithMessage("El campo {PropertyName} no puede poner mas de 200 caracteres.")
               .MinimumLength(20).WithMessage("El campo {PropertyName} no puede poner menos de 20 caracteres.");

            RuleFor(x => x.EsGrupal)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.");

            RuleFor(x => x.FechaEntrega)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.");

            RuleFor(x => x.Puntos)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.");

            RuleFor(x => x.MateriaId)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
                .Must(x => x > 0).WithMessage("No puedes dejar el campo {PropertyName} con un 0, debes asignarselo a un Id")
                .Must(verifiacateMateria).WithMessage("El campo {PropertyName} no tiene coincidencias con los registros del sistema.");

            RuleFor(x => x.ProfesorId)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
                .Must(x => x > 0).WithMessage("No puedes dejar el campo {PropertyName} con un 0, debes asignarselo a un Id")
                .Must(verifiacateProfesor).WithMessage("El campo {PropertyName} no tiene coincidencias con los registros del sistema.");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.");
        }

        private bool verificateTitle(string title)
        {
            if (_context.Tareas.Any(x => x.Titulo.ToLower().Trim() == title.ToLower().Trim()))
                return false;

            else
                return true;
        }

        private bool verifiacateProfesor(int id)
        {
            if (_context.Profesores.Any(x => x.Id == id))
                return true;

            else
                return false;
        }

        private bool verifiacateMateria(int id)
        {
            if (_context.Materias.Any(x => x.Id == id))
                return true;

            else
                return false;
        }

    }
}
