using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Transversal.FluentValidations
{
    public class LocalServicioDTOValidator : AbstractValidator<LocalServicioDTO>
    {
        public LocalServicioDTOValidator()
        {
            RuleFor(x => x.LocalId).NotEmpty();
            //RuleFor(x => x.LocalId).Length(10, 200);
            RuleFor(x => x.ServId).NotEmpty();
            ///ghfvrfvry
        }
    }
}
