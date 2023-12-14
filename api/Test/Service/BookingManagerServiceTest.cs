using Core.Entity;
using Core.Interface.Repository;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Service;
using Test.Data;

namespace Test.Service
{
    public class BookingManagerServiceTest
    {
        public readonly Mock<ITourRepository> _tourRepositoryMock;
        public readonly Mock<IBookingRepository> _bookingRepositoryMock;
        public readonly Mock<IValidator<Tour>> _tourValidatorMock;
        public readonly Mock<IValidator<Booking>> _bookingValidatorMock;

        public BookingManagerServiceTest()
        {
            _tourRepositoryMock = new Mock<ITourRepository>();
            _bookingRepositoryMock = new Mock<IBookingRepository>();
            _tourValidatorMock = new Mock<IValidator<Tour>>();
            _bookingValidatorMock = new Mock<IValidator<Booking>>();
        }

        [Fact]
        public async Task GetAllAsync()
        {
            // Arrange
            _tourRepositoryMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(TourData.GetTourListValid());

            var bookingManagerService = new BookingManagerService(_tourRepositoryMock.Object
                , _bookingRepositoryMock.Object
                , _tourValidatorMock.Object
                , _bookingValidatorMock.Object);

            // Act
            var cardNumberResultModel = await bookingManagerService.GetAllTourAsync();

            // Assert
            Assert.NotNull(cardNumberResultModel);
        }

        [Fact]
        public async Task CreateTourAsync_Valid()
        {
            // Arrange
            _tourRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Tour>()))
                .ReturnsAsync(new Tour());

            _tourValidatorMock.Setup(x => x.Validate(It.IsAny<Tour>()))
                .Returns(new ValidationResult());

            var bookingManagerService = new BookingManagerService(_tourRepositoryMock.Object
                , _bookingRepositoryMock.Object
                , _tourValidatorMock.Object
                , _bookingValidatorMock.Object);

            // Act
            var tour = await bookingManagerService.CreateTourAsync(It.IsAny<Tour>());

            // Assert
            Assert.NotNull(tour);
        }

        [Fact]
        public async Task CreateTourAsync_NonValid()
        {
            // Arrange
            _tourRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Tour>()))
                .ReturnsAsync(new Tour());

            var validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure(It.IsAny<string>(), It.IsAny<string>()));
            _tourValidatorMock.Setup(x => x.Validate(It.IsAny<Tour>()))
                .Returns(validationResult);

            var bookingManagerService = new BookingManagerService(_tourRepositoryMock.Object
                , _bookingRepositoryMock.Object
                , _tourValidatorMock.Object
                , _bookingValidatorMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => bookingManagerService.CreateTourAsync(new Tour()
            {
                Name = string.Empty,
                Destination = "Bs As",
                StartDate = new DateTime(2023, 1, 1),
                EndDate = new DateTime(2023, 1, 1),
                Price = 1000.50M
            }));
        }

        [Fact]
        public async Task BookTourAsync_Valid()
        {
            // Arrange
            _bookingRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Booking>()))
                .ReturnsAsync(new Booking());

            _bookingValidatorMock.Setup(x => x.Validate(It.IsAny<Booking>()))
                .Returns(new ValidationResult());

            var bookingManagerService = new BookingManagerService(_tourRepositoryMock.Object
                , _bookingRepositoryMock.Object
                , _tourValidatorMock.Object
                , _bookingValidatorMock.Object);

            // Act
            var tour = await bookingManagerService.BookTourAsync(new Booking());

            // Assert
            Assert.NotNull(tour);
        }

        [Fact]
        public async Task BookTourAsync_NonValid()
        {
            // Arrange
            _bookingRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Booking>()))
                .ReturnsAsync(new Booking());

            var validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure(It.IsAny<string>(), It.IsAny<string>()));
            _bookingValidatorMock.Setup(x => x.Validate(It.IsAny<Booking>()))
                .Returns(validationResult);

            var bookingManagerService = new BookingManagerService(_tourRepositoryMock.Object
                , _bookingRepositoryMock.Object
                , _tourValidatorMock.Object
                , _bookingValidatorMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => bookingManagerService.BookTourAsync(It.IsAny<Booking>()));
        }

        [Fact]
        public async Task RemoveBookingAsync_Valid()
        {
            // Arrange
            _bookingRepositoryMock.Setup(x => x.RemoveAsync(1))
                .ReturnsAsync((true, string.Empty));

            var bookingManagerService = new BookingManagerService(_tourRepositoryMock.Object
                , _bookingRepositoryMock.Object
                , _tourValidatorMock.Object
                , _bookingValidatorMock.Object);

            // Act
            var (success, message) = await bookingManagerService.RemoveBookingAsync(1);

            // Assert
            Assert.True(success);
            Assert.Empty(message);
        }

        [Fact]
        public async Task RemoveBookingAsync_NonValid()
        {
            // Arrange
            _bookingRepositoryMock.Setup(x => x.RemoveAsync(It.IsAny<int>()))
                .ReturnsAsync((false, "Mensaje de error."));

            var bookingManagerService = new BookingManagerService(_tourRepositoryMock.Object
                , _bookingRepositoryMock.Object
                , _tourValidatorMock.Object
                , _bookingValidatorMock.Object);

            // Act
            var (success, message) = await bookingManagerService.RemoveBookingAsync(It.IsAny<int>());

            // Assert
            Assert.False(success);
            Assert.NotEmpty(message);
        }
    }
}
