using AutoMapper;
using Core.Entity;
using Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TourBooking.Controllers;
using TourBooking.Models;

namespace Test.Controller
{
    public class TourControllerTest
    {
        private readonly Mock<IBookingManagerService> _bookingManagerServiceMock;
        private readonly Mock<ILogger<TourController>> _loggerMock;
        private readonly Mock<IMapper> _mapperMock;
        
        public TourControllerTest()
        {
            _bookingManagerServiceMock = new Mock<IBookingManagerService>();
            _loggerMock = new Mock<ILogger<TourController>>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task Add_ValidData()
        {
            // Arrange
            _bookingManagerServiceMock.Setup(x => x.CreateTourAsync(It.IsAny<Tour>())).ReturnsAsync(new Tour());
            var controller = new TourController(_loggerMock.Object, _bookingManagerServiceMock.Object, _mapperMock.Object);

            // Act
            var result = await controller.Add(new TourModel()
            {
                Name = "Tour 1",
                Destination = "Bs As",
                StartDate = "2023-01-01",
                EndDate = "2023-01-01",
                Price = 1000.50M
            });

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            var okResult = result as OkObjectResult;
            var itemResult = okResult.Value as ItemResultModel<TourModel>;

            Assert.NotNull(itemResult);
            Assert.True(itemResult.Successful);
            Assert.Empty(itemResult.Messages);
        }
    }
}