using AutoMapper;
using DevtoCloneV2.Api.DTOs.Blog;
using DevtoCloneV2.Core.Entities;

namespace DevtoCloneV2.Api.Mapper
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog, BlogResponseDto>()
                .ForMember(dest => dest.Author, opts => opts.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.User, opts => opts.Ignore());
        }
    }
}
