using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FluentValidation;

namespace Server.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly=typeof(ServiceCollectionExtensions).Assembly;
            services.AddMediatR(a => a.RegisterServicesFromAssembly(applicationAssembly));
        }
    }
}
