using Serper.DAL;
using Serper.DAL.Repository;
using Serper.DAL.EntityFramework;
using Serper.Infrastructure.Repository;
using Serper.Infrastructure.Repository.Factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

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

            return services;
        }

        public static IServiceCollection AddDAL(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRepositoryFactory, RepositoryFactory>();

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddScoped<ISearchRepository, SearchRepository>();

            return serviceCollection;
        }
    }
}