using FluentValidation;
using ItlaTaks.Application.DTOs.CreateDTO;
using ItlaTaks.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Application.Validations.Create
{
    public class ValidationMateriaCDTO : AbstractValidator<MateriaCDTO>
    {
        private readonly TaskContext _context;

        public ValidationMateriaCDTO(TaskContext context)
        {
            _context = context;

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
                .MaximumLength(60).WithMessage("El campo {PropertyName} no puede poner mas de 60 caracteres.")
                .MinimumLength(10).WithMessage("El campo {PropertyName} no puede poner menos de 10 caracteres.")
                .Must(verificateNombre).WithMessage("Ya existe una Materia con ese {PropertyName}.");


            RuleFor(x => x.Creditos)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
                .Must(x => x > 0).WithMessage("El campo {PropertyName} debe ser mayor que 0.");

        }

        private bool verificateNombre(string nombre)
        {
            if (_context.Materias.Any(x => x.Nombre.ToLower().Trim() == nombre.ToLower().Trim()))
                return false;
            else
                return true;
        }
    }
}
