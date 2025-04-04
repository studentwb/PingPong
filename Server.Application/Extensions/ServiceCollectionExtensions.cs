using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Server.Application.Games;
namespace Server.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IGamesService, GamesService>();
        }
    }
}
