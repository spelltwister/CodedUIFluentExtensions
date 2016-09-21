namespace Lib.Tests.DecomposingPageObjects.AccountRequired
{
    public interface IOrdersOrchestrations
    {
        IOrdersPageModel CreateOrder(string orderId, string name, int quantity, decimal price);
        IOrdersPageModel CreateOrder(IOrderItem order);
    }

    public class OrdersOrchestrations : IOrdersOrchestrations
    {
        public IOrdersPageModel Model { get; }
        public OrdersOrchestrations(IOrdersPageModel model)
        {
            this.Model = model;
        }

        public IOrdersPageModel CreateOrder(string orderId, string name, int quantity, decimal price)
        {
            if (this.Model.AddButton.IsRendered())
            {
                this.Model.AddButton.Click();
            }

            return
                this.Model
                    .OrderId.SetValue(orderId)
                    .Quantity.SetValue(quantity)
                    .Price.SetValue(price)
                    .Name.SetValue(name)
                    .Save.Click();
        }

        public IOrdersPageModel CreateOrder(IOrderItem order)
        {
            return this.CreateOrder(order.OrderId, order.Name, order.Quantity, order.Price);
        }
    }
}