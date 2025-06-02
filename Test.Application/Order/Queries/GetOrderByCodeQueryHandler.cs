using MediatR;
using Serilog;
using System.Diagnostics;
using Test.Application.Services.Common;
using Test.Domain.Entities.Views;
using Test.Domain.Interfaces;

namespace Test.Application.Order.Queries
{
    public class GetOrderByCodeQueryHandler : IRequestHandler<GetOrderByCodeQuery, OrderView?>
    {
        private readonly ILogger logger;
        private readonly IOrderViewRepository orderViewRepository;
        private readonly ICacheService cacheService;

        public GetOrderByCodeQueryHandler(ILogger logger,
            IOrderViewRepository orderViewRepository, ICacheService cacheService)
        {
            this.logger = logger;
            this.orderViewRepository = orderViewRepository;
            this.cacheService = cacheService;
        }

        public async Task<OrderView?> Handle(GetOrderByCodeQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.OrderCode))
                return null;

            var order = await cacheService.GetAsync<OrderView>($"Order_{request.OrderCode}");
            if (order != null) return order;

            order = await orderViewRepository.GetByOrderCodeAsync(request.OrderCode, cancellationToken);
            if (order != null)
                await cacheService.SetAsync<OrderView>($"Order_{request.OrderCode}", order);

            return order;
        }
    }
}
