using Microsoft.Extensions.DependencyInjection;
using Serper.BLL.Service.User;
using Serper.BLL.Service.Search;
using Serper.BLL.Service.Authorization;
using Serper.Infrastructure.AutoMapper;
using Serper.BLL.Service.Role;

namespace Serper.Infrastructure.Injection
{
    public static class InjectionsBLL
    {
        public static IServiceCollection AddBLL(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(IdentityProfile), typeof(ApplicationProfile));

            serviceCollection.AddScoped<IUserService, UserService>();

            serviceCollection.AddScoped<IAuthorizationsService, AuthorizationsService>();

            serviceCollection.AddScoped<ISearchResultService, SearchResultService>();

            serviceCollection.AddScoped<IUserService, UserService>();

            serviceCollection.AddScoped<IRoleService, RoleService>();

            return serviceCollection;
        }
    }
}