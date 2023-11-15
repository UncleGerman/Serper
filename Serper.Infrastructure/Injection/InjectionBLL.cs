using Serper.BLL.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Serper.Infrastructure.Injection
{
    public static class InjectionBLL
    {
        public static IServiceCollection AddBLL(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISearchService, SearchService>();

            return serviceCollection;
        }
    }
}