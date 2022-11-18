using Castle.Core.Configuration;
using DevtoCloneV2.Core.Interfaces.Repository;
using DevtoCloneV2.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevtoCloneV2.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            // Add ef database context
            services.AddDbContext<AppContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            //Add repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
        }
    }
}
