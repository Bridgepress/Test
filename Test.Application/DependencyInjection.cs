using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Test.Application.Common.Processors;

namespace Test.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TimingBehavior<,>));

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
