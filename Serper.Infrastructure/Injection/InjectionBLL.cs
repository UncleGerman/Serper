using Serper.BLL.Service.Validate;
using Serper.BLL.Service.SearchRequest;
using Serper.BLL.Service.Identity.User;
using Serper.BLL.Service.Identity.Account;
using Microsoft.Extensions.DependencyInjection;

namespace Serper.Infrastructure.Injection
{
    public static class InjectionBLL
    {
        public static IServiceCollection AddBLL(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IValueValidateService, ValueValidateService>();

            serviceCollection.AddScoped<ISearchRequestService, SearchRequestService>();

            #region Identity

            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IAccountService, AccountService>();

            #endregion

            return serviceCollection;
        }
    }
}