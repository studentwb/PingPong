using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Domain.Entites;
using Server.Domain.Repositories;
using Server.Infrastructure.Persistence;
using Server.Infrastructure.Repositories;
namespace Server.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ApplicationDb");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IGamesRepository, GamesRepository>();


        }
    }
}
