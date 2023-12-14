using Core.Entity;
using Core.Interface.Repository;
using Core.Interface.Service;
using FluentValidation;

namespace Service
{
    public class BookingManagerService : IBookingManagerService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IValidator<Tour> _tourValidator;
        private readonly IValidator<Booking> _bookingValidator;

        public BookingManagerService(ITourRepository tourRepository
            , IBookingRepository bookingRepository
            , IValidator<Tour> tourValidator
            , IValidator<Booking> bookingValidator)
        {
            _tourRepository = tourRepository;
            _bookingRepository = bookingRepository;
            _tourValidator = tourValidator;
            _bookingValidator = bookingValidator;
        }

        public async Task<Tour> CreateTourAsync(Tour tour)
        {
            var result = _tourValidator.Validate(tour);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            return await _tourRepository.CreateAsync(tour);
        }

        public async Task<List<Tour>> GetAllTourAsync()
        {
            return await _tourRepository.GetAllAsync();
        }

        public async Task<Booking> BookTourAsync(Booking booking)
        {
            if (booking?.TourId > 0)
                booking.Tour = await _tourRepository.GetByIdAsync(booking.TourId);

            var result = _bookingValidator.Validate(booking);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            return await _bookingRepository.CreateAsync(booking);
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            return await _bookingRepository.GetAllAsync();
        }

        public async Task<(bool, string)> RemoveBookingAsync(int bookingId)
        {
            if (bookingId <= 0)
                return (false, "La reserva no existe.");

            return await _bookingRepository.RemoveAsync(bookingId);
        }
    }
}