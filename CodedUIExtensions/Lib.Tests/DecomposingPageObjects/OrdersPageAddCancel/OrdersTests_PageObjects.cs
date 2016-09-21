using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Tests.DecomposingPageObjects.OrdersPageAddCancel
{
    // demo: lots of new methods for visiblity / enabled-ness
    // demo: is this gettings somewhat predictable yet?
    public class OrdersPageObject
    {
        protected BrowserWindow window;

        protected HtmlDiv OrdersDiv
        {
            get
            {
                HtmlDiv ordersDiv = new HtmlDiv(this.window);
                ordersDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "ordersControl", PropertyExpressionOperator.EqualTo);

                return ordersDiv;
            }
        }

        public OrdersPageObject(BrowserWindow window)
        {
            this.window = window;
        }

        protected HtmlButton AddButton
        {
            get
            {
                HtmlButton addButton = new HtmlButton(this.OrdersDiv);
                addButton.SearchProperties.Add(HtmlButton.PropertyNames.InnerText, "Add", PropertyExpressionOperator.EqualTo);

                return addButton;
            }
        }

        public bool IsAddButtonVisible => this.AddButton.TryFind() && this.AddButton.Width > 0 && this.AddButton.Height > 0;

        public OrdersPageObject ClickAddButton()
        {
            Mouse.Click(this.AddButton);
            return this;
        }

        protected HtmlButton CancelButton
        {
            get
            {
                HtmlButton cancelButton = new HtmlButton(this.OrdersDiv);
                cancelButton.SearchProperties.Add(HtmlButton.PropertyNames.InnerText, "Cancel", PropertyExpressionOperator.EqualTo);

                return cancelButton;
            }
        }

        // demo: why did TryFind need to be present here?
        // demo: what if this check was still in all the tests?
        public bool IsCancelButtonVisible => this.CancelButton.TryFind() && this.CancelButton.Width > 0 && this.CancelButton.Height > 0;

        public OrdersPageObject ClickCancelButton()
        {
            Mouse.Click(this.CancelButton);
            return this;
        }

        protected HtmlEdit OrderIdEdit
        {
            get
            {
                HtmlEdit orderId = new HtmlEdit(this.OrdersDiv);
                orderId.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "orderId", PropertyExpressionOperator.Contains);

                return orderId;
            }
        }

        public string OrderId
        {
            get { return this.OrderIdEdit.Text; }
            set { this.OrderIdEdit.Text = value; }
        }

        public bool IsOrderIdInputVisible => this.OrderIdEdit.TryFind() && this.OrderIdEdit.Height > 0 && this.OrderIdEdit.Width > 0;

        protected HtmlEdit NameEdit
        {
            get
            {
                HtmlEdit nameEdit = new HtmlEdit(this.OrdersDiv);
                nameEdit.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "name", PropertyExpressionOperator.Contains);

                return nameEdit;
            }
        }

        public string Name
        {
            get { return this.NameEdit.Text; }
            set { this.NameEdit.Text = value; }
        }

        public bool IsNameInputVisible => this.NameEdit.TryFind() && this.NameEdit.Height > 0 && this.NameEdit.Width > 0;

        protected HtmlEdit PriceEdit
        {
            get
            {
                HtmlEdit priceEdit = new HtmlEdit(this.OrdersDiv);
                priceEdit.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "price", PropertyExpressionOperator.Contains);

                return priceEdit;
            }
        }

        public string PriceText
        {
            get { return this.PriceEdit.Text; }
            set { this.PriceEdit.Text = value; }
        }

        public decimal? PriceDecimal
        {
            get
            {
                decimal val;
                if (!decimal.TryParse(this.PriceText, out val))
                {
                    return null;
                }
                return val;
            }
            set
            {
                if (!value.HasValue)
                {
                    this.PriceText = "";
                }
                else
                {
                    decimal v = value.Value;
                    this.PriceText = v.ToString("N2");
                }
            }
        }

        public bool IsPriceInputVisible => this.PriceEdit.TryFind() && this.PriceEdit.Width > 0 && this.PriceEdit.Height > 0;

        protected HtmlButton SaveButton
        {
            get
            {
                HtmlButton saveButton = new HtmlButton(this.OrdersDiv);
                saveButton.SearchProperties.Add(HtmlButton.PropertyNames.DisplayText, "Save", PropertyExpressionOperator.EqualTo);

                return saveButton;
            }
        }

        public OrdersPageObject ClickSaveButton()
        {
            Mouse.Click(this.SaveButton);
            return this;
        }

        // demo: uh oh, there was a method checking IsSaveButtonEnabled
        // either could change it to a property and add a property for IsSaveButtonVisible
        // or just make IsSaveButtonVisible() a method
        // demo: why is there even a decision to make about this standard check?
        public bool IsSaveButtonEnabled()
        {
            return this.SaveButton.Enabled;
        }

        public bool IsSaveButtonVisible()
        {
            return this.SaveButton.Height > 0 && this.SaveButton.Width > 0;
        }

        protected HtmlCustom OrderListCustom
        {
            get
            {
                HtmlCustom ordersList = new HtmlCustom(this.OrdersDiv);
                ordersList.SearchProperties.Add(HtmlCustom.PropertyNames.TagName, "ul", PropertyExpressionOperator.EqualTo);

                return ordersList;
            }
        }

        // demo: is this method short-sighted?
        // demo: what if I want a could of orders in the table
        // or to find by something else?
        public OrderRowPageObject FindOrderByOrderId(string orderId)
        {
            HtmlCustom matchingItem = new HtmlCustom(this.OrderListCustom);
            matchingItem.SearchProperties.Add(HtmlCustom.PropertyNames.TagName, "li", PropertyExpressionOperator.EqualTo);
            matchingItem.SearchProperties.Add(HtmlCustom.PropertyNames.ControlDefinition, $"data-order-id=\"{orderId}\"", PropertyExpressionOperator.Contains);

            return new OrderRowPageObject(matchingItem);
        }
    }

    public class OrderRowPageObject
    {
        protected HtmlCustom listItemContainer;

        protected HtmlSpan OrderIdSpan
        {
            get
            {
                HtmlSpan orderIdSpan = new HtmlSpan(this.listItemContainer);
                orderIdSpan.SearchProperties.Add(HtmlSpan.PropertyNames.ControlDefinition, "orderId", PropertyExpressionOperator.Contains);

                return orderIdSpan;
            }
        }

        public string OrderId => this.OrderIdSpan.DisplayText;

        protected HtmlSpan NameSpan
        {
            get
            {
                HtmlSpan nameSpan = new HtmlSpan(this.listItemContainer);
                nameSpan.SearchProperties.Add(HtmlSpan.PropertyNames.ControlDefinition, "name", PropertyExpressionOperator.Contains);

                return nameSpan;
            }
        }

        public string Name => this.NameSpan.DisplayText;

        protected HtmlSpan PriceSpan
        {
            get
            {
                HtmlSpan priceSpan = new HtmlSpan(this.listItemContainer);
                priceSpan.SearchProperties.Add(HtmlSpan.PropertyNames.ControlDefinition, "price", PropertyExpressionOperator.Contains);

                return priceSpan;
            }
        }

        public string PriceText => this.PriceSpan.DisplayText;

        public decimal? PriceDecimal
        {
            get
            {
                decimal val;
                if (!decimal.TryParse(this.PriceText, out val))
                {
                    return null;
                }

                return val;
            }
        }

        public int? PriceNumberDecimalPoints
        {
            get
            {
                if (!this.PriceDecimal.HasValue)
                {
                    return null;
                }

                var parts = this.PriceText.Split(new char[] { '.' });
                if (parts.Length == 1)
                {
                    return 0;
                }

                return parts[1].Length;
            }
        }

        public OrderRowPageObject(HtmlCustom listItemContainer)
        {
            this.listItemContainer = listItemContainer;
        }
    }

    [CodedUITest]
    public class OrdersTests_PageObjects
    {
        protected static readonly Random rand = new Random(98765);

        protected BrowserWindow window;
        protected string newUsername;
        protected string newPassword;
        protected OrdersPageObject ordersPageObject;

        [TestInitialize]
        public void GivenNewUser()
        {
            window = BrowserWindow.Launch($"{TestConfig.UrlBase}/DecomposingPageObjects/Change4");

            HtmlCustom nav = new HtmlCustom(window);
            nav.SearchProperties.Add(HtmlControl.PropertyNames.TagName, "nav");

            HtmlButton registerButton = new HtmlButton(nav);
            registerButton.SearchProperties.Add(HtmlButton.PropertyNames.DisplayText, "Register");

            Mouse.Click(registerButton);

            RegistrationControlPageObject registrationControl = new RegistrationControlPageObject(window);
            this.newUsername = Guid.NewGuid().ToString("N");
            this.newPassword = "pass";
            registrationControl.SetFormValues(this.newUsername, this.newPassword, this.newPassword);
            registrationControl.ClickRegister();

            HtmlButton ordersButton = new HtmlButton(nav);
            ordersButton.SearchProperties.Add(HtmlButton.PropertyNames.DisplayText, "Orders");

            Mouse.Click(ordersButton);

            this.ordersPageObject = new OrdersPageObject(window);
        }

        [TestMethod]
        public void NewOrderFieldsVisibleWhenAddClickAndCancelHidesForm()
        {
            // demo: while there are a lot of assertions,
            // they are easy to read and understand
            Assert.IsTrue(this.ordersPageObject.IsAddButtonVisible);
            Assert.IsFalse(this.ordersPageObject.IsCancelButtonVisible);

            Assert.IsFalse(this.ordersPageObject.IsOrderIdInputVisible);
            Assert.IsFalse(this.ordersPageObject.IsNameInputVisible);
            Assert.IsFalse(this.ordersPageObject.IsPriceInputVisible);

            this.ordersPageObject.ClickAddButton();

            Assert.IsFalse(this.ordersPageObject.IsAddButtonVisible);
            Assert.IsTrue(this.ordersPageObject.IsCancelButtonVisible);

            Assert.IsTrue(this.ordersPageObject.IsOrderIdInputVisible);
            Assert.IsTrue(this.ordersPageObject.IsNameInputVisible);
            Assert.IsTrue(this.ordersPageObject.IsPriceInputVisible);

            this.ordersPageObject.ClickCancelButton();

            // demo: duplicate assertion block
            Assert.IsTrue(this.ordersPageObject.IsAddButtonVisible);
            Assert.IsFalse(this.ordersPageObject.IsCancelButtonVisible);

            Assert.IsFalse(this.ordersPageObject.IsOrderIdInputVisible);
            Assert.IsFalse(this.ordersPageObject.IsNameInputVisible);
            Assert.IsFalse(this.ordersPageObject.IsPriceInputVisible);
        }

        [TestMethod]
        public void SaveButtonEnabledOnlyWhenFormComplete()
        {
            // demo: only needed to click the add button first
            // which is exactly what changed
            // demo: isn't it nice when changes to the tests
            // match a high level UI change?
            this.ordersPageObject.ClickAddButton();

            this.ordersPageObject.OrderId = "";
            this.ordersPageObject.Name = "";
            this.ordersPageObject.PriceText = "";

            Assert.IsFalse(this.ordersPageObject.IsSaveButtonEnabled());

            this.ordersPageObject.OrderId = Guid.NewGuid().ToString("N");
            Assert.IsFalse(this.ordersPageObject.IsSaveButtonEnabled());

            this.ordersPageObject.PriceDecimal = (decimal)rand.NextDouble()*100;
            Assert.IsFalse(this.ordersPageObject.IsSaveButtonEnabled());

            this.ordersPageObject.Name = Guid.NewGuid().ToString("N");
            Assert.IsTrue(this.ordersPageObject.IsSaveButtonEnabled());
        }

        [TestMethod]
        public void AfterSavingOrder_OrderAppearsInList()
        {
            this.ordersPageObject.ClickAddButton();

            string newOrderId = Guid.NewGuid().ToString("N");
            string newName = Guid.NewGuid().ToString("N");
            decimal newPrice = 12.1m;

            this.ordersPageObject.OrderId = newOrderId;
            this.ordersPageObject.Name = newName;
            this.ordersPageObject.PriceDecimal = newPrice;

            var orders = this.ordersPageObject.ClickSaveButton();
            var match = orders.FindOrderByOrderId(newOrderId);

            Assert.IsTrue(StringComparer.Ordinal.Equals(newOrderId, match.OrderId));
            Assert.IsTrue(StringComparer.Ordinal.Equals(newName, match.Name));
            Assert.IsTrue(match.PriceDecimal.HasValue && newPrice == match.PriceDecimal.Value);
         
            Assert.IsTrue(match.PriceNumberDecimalPoints.HasValue && match.PriceNumberDecimalPoints.Value == 2);   
        }
    }
}