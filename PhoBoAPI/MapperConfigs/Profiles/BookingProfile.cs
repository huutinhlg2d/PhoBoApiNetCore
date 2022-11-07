using AutoMapper;
using BussinessObject.PhoBo.DTO;
using BussinessObject.PhoBo.Models;

namespace PhoBoAPI.MapperConfigs.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<CreateBooking, Booking>().ReverseMap();
        }
    }
}
