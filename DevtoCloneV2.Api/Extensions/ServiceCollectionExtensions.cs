using DevtoCloneV2.Api.Mapper;
using DevtoCloneV2.Api.Middleware;

namespace DevtoCloneV2.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile), typeof(BlogProfile));
        }

        public static void AddMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlingMiddleware>();
        }
    }
}
