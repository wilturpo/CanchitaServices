using Application.DTOs;
using FluentValidation;


namespace Infraestructure.Transversal.FluentValidations
{
    public class DepartamentoDTOValidator : AbstractValidator<DepartamentoDTO>
    {
        public DepartamentoDTOValidator()
        {
            RuleFor(x => x.DtoNombre).NotEmpty();
            RuleFor(x => x.DtoNombre).Length(10, 200);
        }
    }
}
