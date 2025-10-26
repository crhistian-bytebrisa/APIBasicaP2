using FluentValidation;
using ItlaTaks.Application.DTOs.CreateDTO;
using ItlaTaks.Infraestructure.Context;
using ItlaTaks.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Application.Validations.Create
{
    public class ValidationProfesorCDTO : AbstractValidator<ProfesorCDTO>
    {
        private readonly TaskContext _context;
        public ValidationProfesorCDTO(TaskContext context)
        {
            _context = context;

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
                .MaximumLength(100).WithMessage("El campo {PropertyName} no puede poner mas de 100 caracteres.")
                .MinimumLength(3).WithMessage("El campo {PropertyName} no puede poner menos de 3 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
                .MaximumLength(150).WithMessage("El campo {PropertyName} no puede poner mas de 150 caracteres.")
                .MinimumLength(5).WithMessage("El campo {PropertyName} no puede poner menos de 5 caracteres.");

            RuleFor(x => x.MateriaIds)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")                          
                .Must(verificateMaterias).WithMessage("Algunas de las {PropertyName} no tienen coincidencias con los registros del sistema.");


        }

        private bool verificateMaterias(List<int> ids)
        {
            return ids.All(id => _context.Materias.Any(x=> x.Id == id));
        }

    }
}
