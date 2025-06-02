namespace Test.Domain.Entities.Views
{
    public class OrderView
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalMoney { get; set; }
        public string OrderCode { get; set; }
    }
}
