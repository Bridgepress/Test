using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.Property(x => x.TotalMoney).HasPrecision(18, 2);
            builder.HasKey(v => v.Id);
            builder.HasOne(v => v.Customer)
                       .WithMany(v => v.Orders)
                       .HasForeignKey(v => v.CustomerId)
                       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
