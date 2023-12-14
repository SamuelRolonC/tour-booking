using Core.Entity;
using FluentValidation;

namespace Core.Validator
{
    public class TourValidator : AbstractValidator<Tour>
    {
        public TourValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Se debe indicar un nombre.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");
            RuleFor(x => x.Destination)
                .NotEmpty().WithMessage("Se debe indicar un destino.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Se debe indicar un precio.")
                .GreaterThanOrEqualTo(0).WithMessage("El precio no puede ser un valor negativo.");
            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Se debe indicar una fecha de inicio.");
            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("Se debe indicar una fecha de fin.")
                .Must((model, prop) => prop >= model.StartDate).WithMessage("La fecha de fin no puede ser mayor que la fecha de inicio.");
        }
    }
}
