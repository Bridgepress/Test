using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Application.Services.Common;
using Test.Domain.Interfaces;
using Test.Infrastructure.Persistence.Repositories;
using Test.Infrastructure.Services.Common;

namespace Test.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddRepositories();

            return services;
        }

        private static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IOrderViewRepository, OrderViewRepository>();
            serviceCollection.AddScoped<ICacheService, CacheService>();
        }


    }
}
