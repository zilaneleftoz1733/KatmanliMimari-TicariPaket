using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using Ticari.BusinessLayer.Managers.Abstract;
using Ticari.BusinessLayer.Managers.Concrete;
using Ticari.Entities.DBContexts;

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
