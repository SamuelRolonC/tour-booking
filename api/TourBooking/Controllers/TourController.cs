using AutoMapper;
using Core.Entity;
using Core.Interface.Service;
using Core.Utils;
using FluentValidation;
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
                    Messages = null,
                    Data = tourModel
                });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new ItemResultModel<TourModel>()
                {
                    Successful = false,
                    Messages = ex.Errors.Select(x => x.ErrorMessage).ToList(),
                    Data = null
                });
            }
            catch (Exception ex)
            {
                var uniqueId = DateTime.Now.Ticks.ToString("x");
                _logger.LogError(ex, Functions.ErrorMessageTemplate(uniqueId, ex.Message));
                return BadRequest(new ItemResultModel<TourModel>()
                {
                    Successful = true,
                    Messages = new List<string>()
                    {
                        Functions.ErrorMessageTemplate(uniqueId, "No se pudo crear el tour. Por favor int�ntelo m�s tarde")
                    },
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
                    Messages = null,
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
                    Messages = new List<string>()
                    {
                        Functions.ErrorMessageTemplate(uniqueId, "No se pudo obtener la lista de tours. Por favor int�ntelo m�s tarde")
                    },
                    Data = new List<TourModel>()
                });
            }
        }
    }
}