using Test.Domain.Entities.Views;

namespace Test.Domain.Interfaces
{
    public interface IOrderViewRepository
    {
        Task<OrderView?> GetByOrderCodeAsync(string orderCode, CancellationToken cancellationToken);
    }
}
