using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Ticari.Api.Extensions
{
    public static class TicariExtensions
    {
        public static IServiceCollection AddTicariService(this IServiceCollection services)
        {

            services.AddScoped(typeof(IManager<>), typeof(Manager<>));

            return services;
        }
    }
}
