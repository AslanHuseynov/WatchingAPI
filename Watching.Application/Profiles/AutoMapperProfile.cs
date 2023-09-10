using AutoMapper;
using Watching.Application.Dtos.CategoryDto;
using Watching.Application.Dtos.UserDto;
using Watching.Application.Dtos.WatchingNameDto;
using Watching.Model.Models;

namespace Watching.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<WatchingName, CreateWatchingNameDto>().ReverseMap();
            CreateMap<WatchingName, UpdateWatchingNameDto>().ReverseMap();
        }
    }
}
