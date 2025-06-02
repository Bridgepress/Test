namespace Test.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
