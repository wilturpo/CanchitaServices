using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Transversal.FluentValidations
{
    public class ImagenDTOValidator : AbstractValidator<ImagenDTO>
    {
        public ImagenDTOValidator()
        {
            RuleFor(x => x.ImaUrl).NotEmpty();
            RuleFor(x => x.CanchaId).NotEmpty();
            RuleFor(x => x.LocalId).NotEmpty();
            RuleFor(x => x.LocServId).NotEmpty();
        }
    }
}
