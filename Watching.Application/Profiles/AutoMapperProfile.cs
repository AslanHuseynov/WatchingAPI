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
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<Content, CreateContentCommand>().ReverseMap();
            CreateMap<Content, UpdateContentCommand>().ReverseMap();
            CreateMap<WatchList, CreateWatchListCommand>().ReverseMap();
        }
    }
}
