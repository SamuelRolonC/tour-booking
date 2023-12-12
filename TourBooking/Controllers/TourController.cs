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
    public class TourController : CustomBaseController
    {
        private readonly ILogger<TourController> _logger;
        private readonly IBookingManagerService _bookingManagerService;

        public TourController(ILogger<TourController> logger
            , IBookingManagerService bookingMangerService
            , IMapper mapper) : base(mapper)
        {
            _logger = logger;
            _bookingManagerService = bookingMangerService;
        }

        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add([FromBody]TourModel tourModel)
        {
            try
            {
                var tour = _mapper.Map<Tour>(tourModel);
                tour = await _bookingManagerService.CreateTourAsync(tour);
                tourModel = _mapper.Map<TourModel>(tour);
                return Ok(new ItemResultModel<TourModel>()
                {
                    Successful = true,
                    Message = string.Empty,
                    Data = tourModel
                });
            }
            catch (Exception ex)
            {
                var uniqueId = DateTime.Now.Ticks.ToString("x");
                _logger.LogError(ex, Functions.ErrorMessageTemplate(uniqueId, ex.Message));
                return BadRequest(new ItemResultModel<TourModel>()
                {
                    Successful = true,
                    Message = Functions.ErrorMessageTemplate(uniqueId, "No se pudo crear el tour. Por favor inténtelo más tarde"),
                    Data = null
                });
            }
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listTour = await _bookingManagerService.GetAllTourAsync();
                var listTourModel = _mapper.Map<List<TourModel>>(listTour);
                return Ok(new ListResultModel<TourModel>()
                {
                    Successful = true,
                    Message = string.Empty,
                    Data = listTourModel
                });
            }
            catch (Exception ex)
            {
                var uniqueId = DateTime.Now.Ticks.ToString("x");
                _logger.LogError(ex, Functions.ErrorMessageTemplate(uniqueId, ex.Message));
                return BadRequest(new ListResultModel<TourModel>()
                {
                    Successful = false,
                    Message = Functions.ErrorMessageTemplate(uniqueId, "No se pudo obtener la lista de tours. Por favor inténtelo más tarde"),
                    Data = new List<TourModel>()
                });
            }
        }
    }
}