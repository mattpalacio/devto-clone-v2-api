using AutoMapper;
using DevtoCloneV2.Api.DTOs.User;
using DevtoCloneV2.Core.Entities;

namespace DevtoCloneV2.Api.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<User, UserWithBlogPostsResponseDto>();
            CreateMap<CreateUserRequestDto, User>();
            CreateMap<UpdateUserRequestDto, User>();
        }
    }
}
