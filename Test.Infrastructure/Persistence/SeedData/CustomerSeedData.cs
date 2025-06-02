using Test.Domain.Entities;

namespace Test.Infrastructure.Persistence.SeedData
{
    internal static class CustomerSeedData
    {
        public static readonly Guid Customer1Id = Guid.Parse("9929115f-e463-4645-9325-1bebdbda948b");
        public static readonly Guid Customer2Id = Guid.Parse("53cca54c-213e-4e87-8a1f-7b8cc0922cf4");

        public static readonly Guid Order1Id = Guid.Parse("bc65a948-529f-4d62-b53d-0b12ffb01cc8");
        public static readonly Guid Order2Id = Guid.Parse("7c3265ad-91c7-40d6-b429-7817e1e4b3ba");
        public static readonly Guid Order3Id = Guid.Parse("f9016454-09ca-4dbd-9f67-e963dee647e2");
        public static readonly Guid Order4Id = Guid.Parse("2cd4163b-1285-4480-a390-8c72edb83a1a");
        public static readonly Guid Order5Id = Guid.Parse("f49e060b-ef72-4f8f-abdb-dcdba3269f96");

        public static readonly Customer[] Customers =
        [
            new Customer { Id = Customer1Id },
            new Customer { Id = Customer2Id }
        ];

        public static readonly Order[] Orders =
        [
            new Order { Id = Order1Id, TotalMoney = 100, OrderCode = "ORD001", CustomerId = Customer1Id },
            new Order { Id = Order2Id, TotalMoney = 200, OrderCode = "ORD002", CustomerId = Customer1Id },
            new Order { Id = Order3Id, TotalMoney = 300, OrderCode = "ORD003", CustomerId = Customer1Id },

            new Order { Id = Order4Id, TotalMoney = 150, OrderCode = "ORD004", CustomerId = Customer2Id },
            new Order { Id = Order5Id, TotalMoney = 250, OrderCode = "ORD005", CustomerId = Customer2Id }
        ];
    }
}
