using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Order.Queries;
using Test.Domain.Entities.Views;

namespace Test.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(ISender sender) : ControllerBase
    {
        [HttpGet("{orderCode}")]
        public async ValueTask<OrderView> GetVacancyById(string orderCode, CancellationToken cancellationToken) =>
            await sender.Send(new GetOrderByCodeQuery(orderCode), cancellationToken);
    }
}
