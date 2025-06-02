using Serilog;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using Serilog.Exceptions.EntityFrameworkCore.Destructurers;

namespace Test.API.Configurations
{
    public static class LoggerConfiguration
    {
        public static void AddSerilog(this ConfigureHostBuilder builder)
        {
            builder.UseSerilog(Configure);
        }

        private static void Configure(HostBuilderContext context, IServiceProvider services, Serilog.LoggerConfiguration configuration)
        {

            configuration
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
                    .WithDefaultDestructurers()
                    .WithDestructurers(new[] { new DbUpdateExceptionDestructurer() }))
                .WriteTo.Debug()
                .WriteTo.Console()
                .ReadFrom.Services(services)
                .ReadFrom.Configuration(context.Configuration);


        }
    }
}
