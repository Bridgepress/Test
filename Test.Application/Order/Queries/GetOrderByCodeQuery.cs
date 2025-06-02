using MediatR;
using Test.Domain.Entities.Views;

namespace Test.Application.Order.Queries
{
    public record GetOrderByCodeQuery(string OrderCode) : IRequest<OrderView?>;
}
