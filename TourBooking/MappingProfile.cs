using AutoMapper;
using Core.Entity;
using Core.Utils;
using TourBooking.Models;

namespace TourBooking
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tour, TourModel>()
                .ForMember(
                    dest => dest.StartDate, 
                    opt => opt.MapFrom(src => Functions.ParseDate(src.StartDate)))
                .ForMember(
                    dest => dest.EndDate, 
                    opt => opt.MapFrom(src => Functions.ParseDate(src.EndDate)))
                .ReverseMap()
                .ForMember(
                    dest => dest.StartDate, 
                    opt => opt.MapFrom(src => Functions.ParseDate(src.StartDate)))
                .ForMember(
                    dest => dest.EndDate, 
                    opt => opt.MapFrom(src => Functions.ParseDate(src.EndDate)))
                .ForMember(
                    dest => dest.Bookings, 
                    opt => opt.Ignore());

            CreateMap<Booking, BookingModel>()
                .ForMember(
                    dest => dest.Date, 
                    opt => opt.MapFrom(src => Functions.ParseDate(src.Date)))
                .ReverseMap()
                .ForMember(
                    dest => dest.Date, 
                    opt => opt.MapFrom(src => Functions.ParseDate(src.Date)));
        }
    }
}
