using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Tests.DecomposingPageObjects.AccountRequired
{
    [CodedUITest]
    public class OrdersTests_PageModels
    {
        protected static readonly Random rand = new Random(98765);

        protected BrowserWindow window;
        // demo: do we really need these in this test class?
        //protected string newUsername;
        //protected string newPassword;
        protected IOrdersPageModel ordersPageModel;

        [TestInitialize]
        public void GivenNewUser()
        {
            window = BrowserWindow.Launch($"{TestConfig.UrlBase}/DecomposingPageObjects/Change6");

            /*********
             * this.newUsername = Guid.NewGuid().ToString("N");
             * this.newPassword = "pass";
             *
             * var registerOrchestrations = new RegisterOrchestations(
             *     new LayoutPageModelBase(this.window).Nav
             *                                         .Register.Click());
             *
             * this.ordersPageModel =
             * registerOrchestrations.Register(this.newUsername, this.newPassword)
             *                       .Nav
             *                       .Orders.Click();
             *
             */

            // demo: the details of setting up a user with credentials
            // is not something that should be splattered thru TestInitialize methods
            var userScenarios = new NewUserScenarios(new LayoutPageModelBase(window));
            this.ordersPageModel = userScenarios.CreateValidatedUser()
                                                .AccountSettingsModel
                                                .Nav
                                                .Orders.Click();
        }

        [TestMethod]
        public void NewOrderFieldsVisibleWhenAddClickAndCancelHidesForm()
        {
            Assert.IsTrue(this.ordersPageModel
                              .AddButton.IsRendered());
            Assert.IsFalse(this.ordersPageModel
                               .CancelButton.IsRendered());

            Assert.IsFalse(this.ordersPageModel
                               .OrderId.IsRendered());
            Assert.IsFalse(this.ordersPageModel
                               .Name.IsRendered());
            Assert.IsFalse(this.ordersPageModel
                               .Price.IsRendered());

            this.ordersPageModel.AddButton.Click();

            Assert.IsTrue(this.ordersPageModel.AddButton.IsNotRendered());
            Assert.IsTrue(this.ordersPageModel.CancelButton.IsRendered());

            Assert.IsTrue(this.ordersPageModel.OrderId.IsRendered());
            Assert.IsTrue(this.ordersPageModel.Name.IsRendered());
            Assert.IsTrue(this.ordersPageModel.Price.IsRendered());

            this.ordersPageModel.CancelButton.Click();

            // demo: duplicate assertion block
            Assert.IsTrue(this.ordersPageModel.AddButton.IsRendered());
            Assert.IsFalse(this.ordersPageModel.CancelButton.IsRendered());

            Assert.IsFalse(this.ordersPageModel.OrderId.IsRendered());
            Assert.IsFalse(this.ordersPageModel.Name.IsRendered());
            Assert.IsFalse(this.ordersPageModel.Price.IsRendered());
        }

        [TestMethod]
        public void SaveButtonEnabledOnlyWhenFormComplete()
        {
            this.ordersPageModel.AddButton.Click();

            this.ordersPageModel
                .OrderId.SetValue("abc")
                .Name.SetValue("")
                .Quantity.SetValueText("")
                .Price.SetValueText("")
                .OrderId.SetValue("");

            Assert.IsFalse(this.ordersPageModel.Save.IsActionable());

            this.ordersPageModel
                .OrderId.SetValue(Guid.NewGuid().ToString("N"));

            Assert.IsFalse(this.ordersPageModel.Save.IsActionable());

            this.ordersPageModel
                .Price.SetValue((decimal)rand.NextDouble() * 100);

            Assert.IsFalse(this.ordersPageModel.Save.IsActionable());

            this.ordersPageModel
                .Quantity.SetValue(rand.Next(1, 100));

            Assert.IsFalse(this.ordersPageModel.Save.IsActionable());

            this.ordersPageModel
                .Name.SetValue(Guid.NewGuid().ToString("N"));

            Assert.IsTrue(this.ordersPageModel.Save.IsActionable());
        }

        [TestMethod]
        public void AfterSavingOrder_OrderAppearsInList()
        {
            string newOrderId = Guid.NewGuid().ToString("N");
            string newName = Guid.NewGuid().ToString("N");
            int newQuantity = rand.Next(1, 100);
            decimal newPrice = 12.1m;
            
            var orders = new OrdersOrchestrations(this.ordersPageModel).CreateOrder(newOrderId, newName, newQuantity, newPrice);

            var match = orders.OrdersList
                              .FirstOrDefault(x => StringComparer.OrdinalIgnoreCase.Equals(newOrderId, x.OrderId.Value));

            Assert.IsNotNull(match);
            Assert.IsTrue(StringComparer.Ordinal.Equals(newOrderId, match.OrderId.Value));
            Assert.IsTrue(StringComparer.Ordinal.Equals(newName, match.Name.Value));
            Assert.IsTrue(newPrice == match.Price.Value);
            Assert.IsTrue(newQuantity == match.Quantity.Value);
        }
    }
}