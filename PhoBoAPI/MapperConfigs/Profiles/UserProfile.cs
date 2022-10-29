using AutoMapper;
using BussinessObject.PhoBo.DTO;
using BussinessObject.PhoBo.Models;

namespace PhoBoAPI.MapperConfigs.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Register, User>();
            CreateMap<Login, User>();
            CreateMap<User, Customer>();
            CreateMap<User, Photographer>();
        }
    }
}
