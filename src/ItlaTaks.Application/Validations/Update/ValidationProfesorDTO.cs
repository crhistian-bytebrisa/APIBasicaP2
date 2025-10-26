using FluentValidation;
using ItlaTaks.Application.DTOs;
using ItlaTaks.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Application.Validations.Update
{
    public class ValidationProfesorDTO : AbstractValidator<ProfesorDTO>
    {
        private readonly TaskContext _context;
        public ValidationProfesorDTO(TaskContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
               .Must(x => _context.Materias.Any(m => m.Id == x))
               .WithMessage("El {PropertyName} no tiene coincidencias con los registros del sistema.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
                .MaximumLength(100).WithMessage("El campo {PropertyName} no puede poner mas de 100 caracteres.")
                .MinimumLength(3).WithMessage("El campo {PropertyName} no puede poner menos de 3 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
                .MaximumLength(150).WithMessage("El campo {PropertyName} no puede poner mas de 150 caracteres.")
                .MinimumLength(5).WithMessage("El campo {PropertyName} no puede poner menos de 5 caracteres.");

            RuleFor(x => x.MateriasId)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
                .Must(verificateMaterias).WithMessage("Algunas de las {PropertyName} no tienen coincidencias con los registros del sistema.");

        }

        private bool verificateMaterias(List<int> ids)
        {
            return ids.All(id => _context.Materias.Any(x => x.Id == id));
        }
    }
}
