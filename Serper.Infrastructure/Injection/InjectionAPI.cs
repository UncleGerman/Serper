using RestSharp;
using Microsoft.Extensions.DependencyInjection;
using Serper.API.Services;

namespace Serper.Infrastructure.Injection
{
    public static class InjectionAPI
    {
        public static IServiceCollection AddAPI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRestClient, RestClient>();

            serviceCollection.AddScoped<ISerperRequestService, SerperRequestService>();

            return serviceCollection;
        }
    }
}