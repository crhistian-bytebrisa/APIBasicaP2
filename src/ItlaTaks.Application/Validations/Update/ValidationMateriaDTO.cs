using FluentValidation;
using ItlaTaks.Application.DTOs;
using ItlaTaks.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Application.Validations.Update
{
    public class ValidationMateriaDTO : AbstractValidator<MateriaDTO>
    {
        private readonly TaskContext _context;
        private int Id;
        public ValidationMateriaDTO(TaskContext context)
        {
            _context = context;
            
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
                .Must(x => _context.Materias.Any(m => m.Id == x))
                .WithMessage("El {PropertyName} no tiene coincidencias con los registros del sistema.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
                .MaximumLength(60).WithMessage("El campo {PropertyName} no puede poner mas de 60 caracteres.")
                .MinimumLength(10).WithMessage("El campo {PropertyName} no puede poner menos de 10 caracteres.")
                .Must((dto,nombre) => verificateNombre(nombre,dto.Id)).WithMessage("Ya existe una Materia con ese {PropertyName}.");


            RuleFor(x => x.Creditos)
                .NotEmpty().WithMessage("No puedes dejar el campo {PropertyName} en blanco.")
                .Must(x => x > 0).WithMessage("El campo {PropertyName} debe ser mayor que 0.");

        }

        private bool verificateNombre(string nombre, int id)
        {
            if (_context.Materias.Any(x => x.Nombre.ToLower().Trim() == nombre.ToLower().Trim() && x.Id == id))
                return false;
            else
                return true;
        }
    }
}
