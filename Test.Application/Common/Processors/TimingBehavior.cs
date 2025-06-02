using MediatR;
using Serilog;
using System.Diagnostics;

namespace Test.Application.Common.Processors
{
    public class TimingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;

        public TimingBehavior(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            var response = await next();
            sw.Stop();

            _logger.Information("Handled {RequestName} in {Elapsed}", typeof(TRequest).Name, sw.Elapsed);
            return response;
        }
    }
}
