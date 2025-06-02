namespace Test.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal TotalMoney { get; set; }
        public string OrderCode { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
