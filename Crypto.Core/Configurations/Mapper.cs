using AutoMapper;
using Crypto.Core.DTOs;
using Crypto.Data.Models;

namespace Crypto.Core.Configurations
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, LoginUserDto>().ReverseMap();
            CreateMap<WatchList, WatchListDto>().ReverseMap();
        }
    }
}
