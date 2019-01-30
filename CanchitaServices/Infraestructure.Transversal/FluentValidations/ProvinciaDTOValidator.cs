using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Transversal.FluentValidations
{
    public class ProvinciaDTOValidator : AbstractValidator<ProvinciaDTO>
    {
        public ProvinciaDTOValidator()
        {
            RuleFor(x => x.ProvNombre).NotEmpty();
            RuleFor(x => x.ProvNombre).Length(10, 200);
            RuleFor(x => x.DtoId).NotEmpty();
        }
    }
}
