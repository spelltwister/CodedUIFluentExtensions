using System;
using System.Collections.Generic;
using System.Linq;
using CaptainPav.Testing.UI.CodedUI;
using CaptainPav.Testing.UI.CodedUI.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Tests.DecomposingPageObjects.OrdersPageQuantityDelete
{
    #region Dependency Page Objects
    public class AccountSettingsPageObject
    {
        protected BrowserWindow window;

        protected HtmlDiv AccountSettingsDiv
        {
            get
            {
                HtmlDiv accountSettingsDiv = new HtmlDiv(this.window);
                accountSettingsDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "accountSettingsControl", PropertyExpressionOperator.EqualTo);

                return accountSettingsDiv;
            }
        }

        public AccountSettingsPageObject(BrowserWindow window)
        {
            this.window = window;
        }

        protected HtmlEdit FirstNameEdit
        {
            get
            {
                HtmlEdit confirmPasswordDiv = new HtmlEdit(this.AccountSettingsDiv);
                confirmPasswordDiv.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "firstName", PropertyExpressionOperator.Contains);

                return confirmPasswordDiv;
            }
        }

        public string FirstName
        {
            get
            {
                return this.FirstNameEdit.Text;
            }
            set
            {
                this.FirstNameEdit.Text = value;
            }
        }

        protected HtmlEdit LastNameEdit
        {
            get
            {
                HtmlEdit confirmPasswordDiv = new HtmlEdit(this.AccountSettingsDiv);
                confirmPasswordDiv.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "lastName", PropertyExpressionOperator.Contains);

                return confirmPasswordDiv;
            }
        }

        public string LastName
        {
            get
            {
                return this.LastNameEdit.Text;
            }
            set
            {
                this.LastNameEdit.Text = value;
            }
        }

        protected HtmlButton SaveButton => new HtmlButton(this.AccountSettingsDiv);

        public bool IsSaveButtonVisible()
        {
            return this.SaveButton.Height > 0 && this.SaveButton.Width > 0;
        }

        public AccountSettingsPageObject ClickSave()
        {
            Mouse.Click(this.SaveButton);
            return this;
        }
    }

    public class RegistrationControlPageObject
    {
        protected BrowserWindow window;

        protected HtmlDiv RegistrationDiv
        {
            get
            {
                HtmlDiv registerDiv = new HtmlDiv(this.window);
                registerDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "registerControl", PropertyExpressionOperator.EqualTo);

                return registerDiv;
            }
        }

        protected HtmlEdit ConfirmPasswordEdit
        {
            get
            {
                HtmlEdit confirmPasswordDiv = new HtmlEdit(this.RegistrationDiv);
                confirmPasswordDiv.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "confirmPassword", PropertyExpressionOperator.Contains);

                return confirmPasswordDiv;
            }
        }

        public bool IsConfirmPasswordVisible => this.ConfirmPasswordEdit.Height > 0 && this.ConfirmPasswordEdit.Width > 0;

        protected HtmlButton RegisterButton => new HtmlButton(this.RegistrationDiv);

        public bool IsRegisterButtonVisible => this.RegisterButton.Width > 0 && this.RegisterButton.Height > 0;

        public bool IsRegisterButtonEnabled => this.RegisterButton.Enabled;

        public AccountSettingsPageObject ClickRegister()
        {
            Mouse.Click(this.RegisterButton);
            return new AccountSettingsPageObject(this.window);
        }

        public RegistrationControlPageObject(BrowserWindow window)
        {
            this.window = window;
        }

        public RegistrationControlPageObject SetFormValues(string username, string password, string confirmPassword)
        {
            HtmlDiv usernamePasswordDiv = new HtmlDiv(this.RegistrationDiv);

            HtmlEdit usernameDiv = new HtmlEdit(usernamePasswordDiv);
            usernameDiv.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "username", PropertyExpressionOperator.Contains);

            if (null != username)
            {
                usernameDiv.Text = username;
            }

            HtmlEdit passwordDiv = new HtmlEdit(usernamePasswordDiv);
            passwordDiv.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "password", PropertyExpressionOperator.Contains);

            if (null != password)
            {
                passwordDiv.Text = password;
            }

            if (null != confirmPassword)
            {
                this.ConfirmPasswordEdit.Text = confirmPassword;
            }

            return this;
        }
    }
    #endregion

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

    public interface IOrdersPageModel : IPageModel
    {
        IClickablePageModel<IOrdersPageModel> AddButton { get; }
        IClickablePageModel<IOrdersPageModel> CancelButton { get; }
        
        IReadWriteValuePageModel<string, IOrdersPageModel> OrderId { get; }   
        IReadWriteValuePageModel<string, IOrdersPageModel> Name { get; }

        IReadWriteTextValuePageModel<int?, IOrdersPageModel> Quantity { get; }
        IReadWriteTextValuePageModel<decimal?, IOrdersPageModel> Price { get; }

        IClickablePageModel<IOrdersPageModel> Save { get; }
        
        // demo: no need for methods like FindOrderById(string orderId)
        IEnumerable<IOrdersRowPageModel> OrdersList { get; } 
    }

    public interface IOrdersRowPageModel : IPageModel
    {
        IValuedPageModel<string> OrderId { get; }
        IValuedPageModel<string> Name { get; }
        
        ITextValuedPageModel<int> Quantity { get; }
        ITextValuedPageModel<decimal> Price { get; } 
        
        IClickablePageModel<IOrdersPageModel> Remove { get; }  
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

    [CodedUITest]
    public class OrdersTests_PageModels
    {
        protected static readonly Random rand = new Random(98765);

        protected BrowserWindow window;
        protected string newUsername;
        protected string newPassword;
        //protected OrdersPageObject ordersPageObject;
        protected IOrdersPageModel ordersPageModel;

        [TestInitialize]
        public void GivenNewUser()
        {
            window = BrowserWindow.Launch($"{TestConfig.UrlBase}/DecomposingPageObjects/Change5");

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

            //this.ordersPageObject = new OrdersPageObject(window);
            this.ordersPageModel = new OrdersPageModel(window);
        }

        [TestMethod]
        public void NewOrderFieldsVisibleWhenAddClickAndCancelHidesForm()
        {
            /******
             * Assert.IsTrue(this.ordersPageObject.IsAddButtonVisible);
             * Assert.IsFalse(this.ordersPageObject.IsCancelButtonVisible);
             * 
             * Assert.IsFalse(this.ordersPageObject.IsOrderIdInputVisible);
             * Assert.IsFalse(this.ordersPageObject.IsNameInputVisible);
             * Assert.IsFalse(this.ordersPageObject.IsPriceInputVisible);
             */

            // demo: slight difference
            // Is{control}{state}()
            // vs
            // {control}.Is{state}()
            Assert.IsTrue(this.ordersPageModel
                              .AddButton.IsRendered());
            Assert.IsFalse(this.ordersPageModel
                               .CancelButton.IsRendered());
            // demo: or,
            //Assert.IsTrue(this.ordersPageModel
            //                  .CancelButton.IsNotRendered());
            // demo: is there any difference?

            Assert.IsFalse(this.ordersPageModel
                               .OrderId.IsRendered());
            Assert.IsFalse(this.ordersPageModel
                               .Name.IsRendered());
            Assert.IsFalse(this.ordersPageModel
                               .Price.IsRendered());

            //this.ordersPageObject.ClickAddButton();
            // demo: same minor difference
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

            // demo: context chaining syntax!
            this.ordersPageModel
                .OrderId.SetValue("abc")
                .Name.SetValue("")
                .Quantity.SetValueText("")
                .OrderId.SetValue("")
                .Price.SetValueText("");

            Assert.IsFalse(this.ordersPageModel.Save.IsActionable());

            // or chain the entire assertion
            // Assert.IsFalse(this.ordersPageModel
            //                    .OrderId.SetValue("")
            //                    .Name.SetValue("")
            //                    .Quantity.SetValueText("")
            //                    .Price.SetValueText("")
            //                    .Save.IsActionable());

            this.ordersPageModel
                .OrderId.SetValue(Guid.NewGuid().ToString("N"));

            Assert.IsFalse(this.ordersPageModel.Save.IsActionable());

            // demo: more consistent naming
            // {control}.{action}
            // vs
            // {control}{valueType} = value;
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
            this.ordersPageModel.AddButton.Click();

            string newOrderId = Guid.NewGuid().ToString("N");
            string newName = Guid.NewGuid().ToString("N");
            int newQuantity = rand.Next(1, 100);
            decimal newPrice = 12.1m;

            this.ordersPageModel
                .OrderId.SetValue(newOrderId)
                .Name.SetValue(newName)
                .Quantity.SetValue(newQuantity)
                .Price.SetValue(newPrice);

            var orders = this.ordersPageModel.Save.Click();

            // demo: test dictates the record it is looking for
            // using linq to objects
            var match = orders.OrdersList
                              .FirstOrDefault(x => StringComparer.OrdinalIgnoreCase.Equals(newOrderId, x.OrderId.Value));

            Assert.IsNotNull(match);
            Assert.IsTrue(StringComparer.Ordinal.Equals(newOrderId, match.OrderId.Value));
            Assert.IsTrue(StringComparer.Ordinal.Equals(newName, match.Name.Value));
            Assert.IsTrue(newPrice == match.Price.Value);
            Assert.IsTrue(newQuantity == match.Quantity.Value);

            // demo: not so hot for this to be here
            // demo: is there something better / more robust that can be done here? [interactive]
            var priceParts = match.Price.ValueText.Split(new char[] {'.'});
            Assert.IsTrue(priceParts.Length == 2);
            Assert.IsTrue(priceParts[1].Length == 2);
        }
    }

    public class OrdersPageModel : HtmlPageModelBase<HtmlDiv>, IOrdersPageModel
    {
        public OrdersPageModel(BrowserWindow bw) : base(bw)
        {
        }

        /********************
         * HtmlDiv ordersDiv = new HtmlDiv(this.window);
         * ordersDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "ordersControl", PropertyExpressionOperator.EqualTo);

         * return ordersDiv;
         */
        
        // demo: fluent syntax
        protected override HtmlDiv Me => this.parent.Find<HtmlDiv>("ordersControl");

        /***************
         *  HtmlButton addButton = new HtmlButton(this.OrdersDiv);
         *  addButton.SearchProperties.Add(HtmlButton.PropertyNames.InnerText, "Add", PropertyExpressionOperator.EqualTo);
         *
         *  return addButton;
         */

        // demo: fluent syntax
        // demo: consistent strategy for controls
        // AsPageModel extensions provide consistent access to test
        // controls for their state and perform common actions like setting text
        public IClickablePageModel<IOrdersPageModel> AddButton 
            => this.Me
                   .Find<HtmlButton>(HtmlButton.PropertyNames.InnerText, "Add", PropertyExpressionOperator.EqualTo)
                   .AsPageModel(this);

        public IClickablePageModel<IOrdersPageModel> CancelButton
            => this.Me
                   .Find<HtmlButton>(HtmlButton.PropertyNames.InnerText, "Cancel", PropertyExpressionOperator.EqualTo)
                   .AsPageModel(this);

        public IReadWriteValuePageModel<string, IOrdersPageModel> OrderId
            => this.Me
                   .Find<HtmlEdit>(HtmlEdit.PropertyNames.ControlDefinition, "orderId", PropertyExpressionOperator.Contains)
                   .AsPageModel(this);

        public IReadWriteValuePageModel<string, IOrdersPageModel> Name
            => this.Me
                   .Find<HtmlEdit>(HtmlEdit.PropertyNames.ControlDefinition, "name", PropertyExpressionOperator.Contains)
                   .AsPageModel(this);

        public IReadWriteTextValuePageModel<int?, IOrdersPageModel> Quantity
            => this.Me
                   .Find<HtmlEdit>(HtmlEdit.PropertyNames.ControlDefinition, "quantity", PropertyExpressionOperator.Contains)
                   .AsPageModel(this, s => { int q;
                                               if (!int.TryParse(s, out q)) return null;
                                               return (int?)q;
                   }, i => i.HasValue ? i.Value.ToString("D") : "");

        public IReadWriteTextValuePageModel<decimal?, IOrdersPageModel> Price
            => this.Me
                   .Find<HtmlEdit>(HtmlEdit.PropertyNames.ControlDefinition, "price", PropertyExpressionOperator.Contains)
                   .AsPageModel(this, s => {
                       decimal q;
                       if (!decimal.TryParse(s, out q)) return null;
                       return (decimal?)q;
                   }, i => i.HasValue ? i.Value.ToString("N2") : "");

        public IClickablePageModel<IOrdersPageModel> Save
            => this.Me
                   .Find<HtmlButton>(HtmlButton.PropertyNames.DisplayText, "Save", PropertyExpressionOperator.EqualTo)
                   .AsPageModel(this);

        public IEnumerable<IOrdersRowPageModel> OrdersList
            => this.Me
                   .FindAll<HtmlReadonlyListItem>()
                   .Select(x => new OrdersRowPageModel(this.parent, x, this));
    }

    public class OrdersRowPageModel : HtmlChildPageModelBase<HtmlReadonlyListItem>, IOrdersRowPageModel
    {
        protected readonly IOrdersPageModel ordersPageParent;

        public OrdersRowPageModel(BrowserWindow bw, HtmlReadonlyListItem me, IOrdersPageModel ordersPageModel) : base(bw, me)
        {
            this.ordersPageParent = ordersPageModel;
        }

        public IValuedPageModel<string> OrderId 
            => this.Me
                   .Find<HtmlSpan>(HtmlSpan.PropertyNames.ControlDefinition, "orderId", PropertyExpressionOperator.Contains)
                   .AsValuedPageModel(x => x.DisplayText);

        public IValuedPageModel<string> Name
             => this.Me
                    .Find<HtmlSpan>(HtmlSpan.PropertyNames.ControlDefinition, "name", PropertyExpressionOperator.Contains)
                    .AsValuedPageModel(x => x.DisplayText);

        public ITextValuedPageModel<int> Quantity
             => this.Me
                    .Find<HtmlSpan>(HtmlSpan.PropertyNames.ControlDefinition, "quantity", PropertyExpressionOperator.Contains)
                    .AsTextValuedPageModel(int.Parse);

        public ITextValuedPageModel<decimal> Price
             => this.Me
                    .Find<HtmlSpan>(HtmlSpan.PropertyNames.ControlDefinition, "price", PropertyExpressionOperator.Contains)
                    .AsTextValuedPageModel(decimal.Parse);

        public IClickablePageModel<IOrdersPageModel> Remove
            => this.Me
                   .Find<HtmlButton>(HtmlButton.PropertyNames.InnerText, "Delete", PropertyExpressionOperator.EqualTo)
                   .AsPageModel(this.ordersPageParent);
    }
}