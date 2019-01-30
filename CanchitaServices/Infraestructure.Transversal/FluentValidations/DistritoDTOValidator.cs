using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Transversal.FluentValidations
{
    public class DistritoDTOValidator : AbstractValidator<DistritoDTO>
    {
        public DistritoDTOValidator()
        {
            RuleFor(x => x.DistDescripcion).NotEmpty();
           
            RuleFor(x => x.ProvId).NotEmpty();
            
        }
    }
}
