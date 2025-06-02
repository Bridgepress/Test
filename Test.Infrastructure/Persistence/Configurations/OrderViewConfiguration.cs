using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities.Views;

namespace Test.Infrastructure.Persistence.Configurations
{
    public class OrderViewConfiguration : IEntityTypeConfiguration<OrderView>
    {
        public void Configure(EntityTypeBuilder<OrderView> builder)
        {
            builder.ToView("V_Orders"); 
            builder.HasNoKey();
        }
    }
}
