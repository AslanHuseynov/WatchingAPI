using AutoMapper;
using Watching.Application.Dtos.CategoryDto;
using Watching.Application.Dtos.ContentDto;
using Watching.Application.Dtos.UserDto;
using Watching.Application.Dtos.WatchListDto;
using Watching.Model.Models;

namespace Watching.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<Content, CreateContentDto>().ReverseMap();
            CreateMap<Content, UpdateContentDto>().ReverseMap();
            CreateMap<WatchList, CreateWatchListDto>().ReverseMap();
        }
    }
}
