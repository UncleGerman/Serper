using Serper.DAL;
using Serper.DAL.Entity.Identity;
using Serper.DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Serper.Infrastructure.Injection
{
    public static class InjectionDAL
    {
        public static IServiceCollection AddDbContext(
            this IServiceCollection services,
            IConfiguration configure)
        {
            var connection = configure.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationContext>();

            return services;
        }

        public static IServiceCollection AddDAL(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            return serviceCollection;
        }
    }
}