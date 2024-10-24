using Ticari.BusinessLayer.Managers.Abstract;
using Ticari.BusinessLayer.Managers.Concrete;

namespace Ticari.WebMVC.Extensions
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
