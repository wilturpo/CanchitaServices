using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Transversal.FluentValidations
{
    public class LocalDTOValidator : AbstractValidator<LocalDTO>
    {
        public LocalDTOValidator()
        {
            RuleFor(x => x.LocalDescripcion).NotEmpty();
            RuleFor(x => x.LocalNombre).NotEmpty();
            RuleFor(x => x.LocalDireccion).NotEmpty();
            RuleFor(x => x.LocalHoraApertura).NotEmpty();
            RuleFor(x => x.LocalHoraCierre).NotEmpty();
            RuleFor(x => x.LocalTelefono).NotEmpty();
            RuleFor(x => x.LocalLatitud).NotEmpty();
            RuleFor(x => x.LocalLongitud).NotEmpty();
            RuleFor(x => x.LocalDist).NotEmpty();
        }
    }
}
