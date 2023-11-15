using Serper.Infrastructure.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Serper.Infrastructure.Injection
{
    public static class Injection
    {
        public static IServiceCollection AddInjection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(AppMappingProfile));

            return serviceCollection;
        }
    }
}