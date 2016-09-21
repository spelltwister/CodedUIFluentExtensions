using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Tests.DecomposingPageObjects.OrdersPage
{
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

        public bool IsSaveButtonEnabled()
        {
            return this.SaveButton.Enabled;
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

        public OrderRowPageObject FindOrderByOrderId(string orderId)
        {
            HtmlCustom matchingItem = new HtmlCustom(this.OrderListCustom);
            matchingItem.SearchProperties.Add(HtmlCustom.PropertyNames.TagName, "li", PropertyExpressionOperator.EqualTo);
            matchingItem.SearchProperties.Add(HtmlCustom.PropertyNames.ControlDefinition, $"data-order-id=\"{orderId}\"", PropertyExpressionOperator.Contains);

            return new OrderRowPageObject(matchingItem);
        }
    }

    // demo: inner page object
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

        // demo: and what do we have here?
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

        // demo: orders table is non deterministic
        // so each order needs to be told who it is (more on this later)
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

        // username of the new user accessible to tests
        protected string newUsername;

        // password of the new user accessible to tests
        protected string newPassword;

        protected OrdersPageObject ordersPageObject;

        [TestInitialize]
        public void GivenNewUser()
        {
            window = BrowserWindow.Launch($"{TestConfig.UrlBase}/DecomposingPageObjects/Change3");

            HtmlCustom nav = new HtmlCustom(window);
            nav.SearchProperties.Add(HtmlControl.PropertyNames.TagName, "nav");

            HtmlButton registerButton = new HtmlButton(nav);
            registerButton.SearchProperties.Add(HtmlButton.PropertyNames.DisplayText, "Register");

            Mouse.Click(registerButton);

            RegistrationControlPageObject registrationControl = new RegistrationControlPageObject(window);

            // allow the tests to use this information
            this.newUsername = Guid.NewGuid().ToString("N");
            this.newPassword = "pass";

            // demo: what happens is registration process changes?
            registrationControl.SetFormValues(this.newUsername, this.newPassword, this.newPassword);
            registrationControl.ClickRegister();

            HtmlButton ordersButton = new HtmlButton(nav);
            ordersButton.SearchProperties.Add(HtmlButton.PropertyNames.DisplayText, "Orders");

            Mouse.Click(ordersButton);

            this.ordersPageObject = new OrdersPageObject(window);
        }

        [TestMethod]
        public void SaveButtonEnabledOnlyWhenFormComplete()
        {
            this.ordersPageObject.OrderId = "";
            this.ordersPageObject.Name = "";
            this.ordersPageObject.PriceText = "";

            Assert.IsFalse(this.ordersPageObject.IsSaveButtonEnabled());

            this.ordersPageObject.OrderId = Guid.NewGuid().ToString("N");
            Assert.IsFalse(this.ordersPageObject.IsSaveButtonEnabled());

            // demo: prefer to use native types rather than figure
            // out how to format the value for input
            //this.ordersPageObject.PriceText = ((decimal)rand.NextDouble() * 100).ToString("N2");
            this.ordersPageObject.PriceDecimal = (decimal)rand.NextDouble()*100;
            Assert.IsFalse(this.ordersPageObject.IsSaveButtonEnabled());

            this.ordersPageObject.Name = Guid.NewGuid().ToString("N");
            Assert.IsTrue(this.ordersPageObject.IsSaveButtonEnabled());
        }

        [TestMethod]
        public void AfterSavingOrder_OrderAppearsInList()
        {
            string newOrderId = Guid.NewGuid().ToString("N");
            string newName = Guid.NewGuid().ToString("N");
            decimal newPrice = 12.1m;

            this.ordersPageObject.OrderId = newOrderId;
            this.ordersPageObject.Name = newName;
            this.ordersPageObject.PriceDecimal = newPrice;

            var orders = this.ordersPageObject.ClickSaveButton();

            // demo: use the page object to abstract reading the values out of the table row
            // demo: what happens if the table changes into a list?
            var match = orders.FindOrderByOrderId(newOrderId);

            Assert.IsTrue(StringComparer.Ordinal.Equals(newOrderId, match.OrderId));
            Assert.IsTrue(StringComparer.Ordinal.Equals(newName, match.Name));
            Assert.IsTrue(match.PriceDecimal.HasValue && newPrice == match.PriceDecimal.Value);
         
            Assert.IsTrue(match.PriceNumberDecimalPoints.HasValue && match.PriceNumberDecimalPoints.Value == 2);   
        }
    }
}