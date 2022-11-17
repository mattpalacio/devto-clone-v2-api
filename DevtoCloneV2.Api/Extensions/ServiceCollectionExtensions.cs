using DevtoCloneV2.Api.Mapper;

namespace DevtoCloneV2.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile), typeof(BlogProfile));
        }
    }
}
