namespace Lib.Tests.DecomposingPageObjects.AccountRequired
{
    public interface IOrderItem
    {
        string OrderId { get; }
        string Name { get; }
        int Quantity { get; }
        decimal Price { get; }
    }

    public class OrderItem : IOrderItem
    {
        public string OrderId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}