using Core.Entity;
using FluentValidation;

namespace Core.Validator
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(x => x.Customer)
                .NotEmpty().WithMessage("Se debe indicar el cliente.")
                .MaximumLength(50).WithMessage("El nombre del cliente no puede superar los 50 caracteres.");
            RuleFor(x => x.TourId)
                .NotEmpty().WithMessage("Se debe indicar el tour.");
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Se debe indicar una fecha para la reserva.")
                .Must((model, prop) => prop <= model.Tour?.StartDate).WithMessage("La fecha de la reserva no puede ser mayor a la del inicio del tour");
        }
    }
}
