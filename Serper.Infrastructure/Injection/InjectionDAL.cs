using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serper.DAL;
using Serper.DAL.Entity.Identity;
using Serper.DAL.EntityFramework;
using Serper.Infrastructure.Repository.Factory;

namespace Serper.Infrastructure.Injection
{
    public static class InjectionDAL
    {
        public static IServiceCollection AddDbContext(
            this IServiceCollection serviceCollection,
            IConfiguration configure)
        {
            var connection = configure.GetConnectionString("DefaultConnection");

            serviceCollection.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            serviceCollection.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                #region Lockout

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 5; 
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(365);

                #endregion
            })
                .AddEntityFrameworkStores<ApplicationContext>();

            return serviceCollection;
        }

        public static IServiceCollection AddDAL(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRepositoryFactory, RepositoryFactory>();

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            return serviceCollection;
        }
    }
}