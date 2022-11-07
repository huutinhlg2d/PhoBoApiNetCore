using AutoMapper;
using BussinessObject.PhoBo.DTO;
using BussinessObject.PhoBo.Models;

namespace PhoBoAPI.MapperConfigs.Profiles
{
    public class BookingConceptConfigProfile : Profile
    {
        public BookingConceptConfigProfile()
        {
            CreateMap<CreateBookingConceptConfig, BookingConceptConfig>();
            CreateMap<BookingConceptConfig, BookingConceptConfigViewModel>();
        }
    }
}
