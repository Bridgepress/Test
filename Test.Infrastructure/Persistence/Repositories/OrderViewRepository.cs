using Microsoft.EntityFrameworkCore;
using Test.Domain.Entities.Views;
using Test.Domain.Interfaces;
using Test.Infrastructure.Persistence.Contexts;

namespace Test.Infrastructure.Persistence.Repositories
{
    internal class OrderViewRepository : IOrderViewRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderViewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderView?> GetByOrderCodeAsync(string orderCode, CancellationToken cancellationToken)
        {
            return await _context.OrderView
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.OrderCode == orderCode, cancellationToken);
        }
    }
}
