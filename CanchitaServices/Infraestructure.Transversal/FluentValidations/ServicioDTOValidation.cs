using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Transversal.FluentValidations
{
    public class ServicioDTOValidator : AbstractValidator<ServicioDTO>
    {
        public ServicioDTOValidator()
        {
            RuleFor(x => x.ServNombre).NotEmpty();
            RuleFor(x => x.ServNombre).Length(10, 200);
            //hfcyf
        }
    }
}
