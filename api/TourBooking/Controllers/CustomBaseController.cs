using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace TourBooking.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        protected IMapper _mapper { get; set; }

        public CustomBaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
