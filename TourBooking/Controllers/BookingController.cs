using AutoMapper;
using Core.Entity;
using Core.Interface.Service;
using Core.Utils;
using Microsoft.AspNetCore.Mvc;
using TourBooking.Models;

namespace TourBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : CustomBaseController
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingManagerService _bookingManagerService;

        public BookingController(ILogger<BookingController> logger
            , IBookingManagerService BookingManagerService
            , IMapper mapper) : base(mapper)
        {
            _logger = logger;
            _bookingManagerService = BookingManagerService;
        }

        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add([FromBody]BookingModel bookingModel)
        {
            try
            {
                var booking = _mapper.Map<Booking>(bookingModel);
                booking = await _bookingManagerService.BookTourAsync(booking);
                bookingModel = _mapper.Map<BookingModel>(booking);
                return Ok(new ItemResultModel<BookingModel>()
                {
                    Successful = true,
                    Message = string.Empty,
                    Data = bookingModel
                });
            }
            catch (Exception ex)
            {
                var uniqueId = DateTime.Now.Ticks.ToString("x");
                _logger.LogError(ex, Functions.ErrorMessageTemplate(uniqueId, ex.Message));
                return BadRequest(new ItemResultModel<BookingModel>()
                {
                    Successful = false,
                    Message = Functions.ErrorMessageTemplate(uniqueId, "No se pudo crear la reserva. Por favor inténtelo más tarde"),
                    Data = null
                });
            }
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listBooking = await _bookingManagerService.GetAllBookingsAsync();
                var listBookingModel = _mapper.Map<List<BookingModel>>(listBooking);
                return Ok(new ListResultModel<BookingModel>()
                {
                    Successful = true,
                    Message = string.Empty,
                    Data = listBookingModel
                });
            }
            catch (Exception ex)
            {
                var uniqueId = DateTime.Now.Ticks.ToString("x");
                _logger.LogError(ex, Functions.ErrorMessageTemplate(uniqueId, ex.Message));
                return BadRequest(new ListResultModel<BookingModel>()
                {
                    Successful = false,
                    Message = Functions.ErrorMessageTemplate(uniqueId, "No se pudo obtener la lista de reservas. Por favor inténtelo más tarde"),
                    Data = new List<BookingModel>()
                });
            }
        }

        [HttpDelete(nameof(Remove))]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var (success, message) = await _bookingManagerService.RemoveBookingAsync(id);
                return Ok(new ResultModel()
                {
                    Successful = success,
                    Message = message
                });
            }
            catch (Exception ex)
            {
                var uniqueId = DateTime.Now.Ticks.ToString("x");
                _logger.LogError(ex, Functions.ErrorMessageTemplate(uniqueId, ex.Message));
                return BadRequest(new ResultModel()
                {
                    Successful = false,
                    Message = Functions.ErrorMessageTemplate(uniqueId, "No se pudo eliminar la reserva. Por favor inténtelo más tarde"),
                });
            };
        }
    }
}