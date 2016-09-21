using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Tests.DecomposingPageObjects.OrdersPageAddCancel
{
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

    public class LoginPageObject
    {
        protected BrowserWindow window;

        protected HtmlDiv LoginDiv
        {
            get
            {
                HtmlDiv loginDiv = new HtmlDiv(this.window);
                loginDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "loginControl", PropertyExpressionOperator.EqualTo);

                return loginDiv;
            }
        }

        protected HtmlDiv UsernamePasswordDiv => new HtmlDiv(this.LoginDiv);
                
        protected HtmlEdit UsernameDiv
        {
            get
            {
                HtmlEdit usernameDiv = new HtmlEdit(this.UsernamePasswordDiv);
                usernameDiv.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "username", PropertyExpressionOperator.Contains);
                return usernameDiv;
            }
        }

        protected HtmlEdit PasswordDiv
        {
            get
            {
                HtmlEdit passwordDiv = new HtmlEdit(this.UsernamePasswordDiv);
                passwordDiv.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "password", PropertyExpressionOperator.Contains);

                return passwordDiv;
            }
        }

        public LoginPageObject(BrowserWindow window)
        {
            this.window = window;
        }

        public string Username
        {
            get { return this.UsernameDiv.Text; }
            set { this.UsernameDiv.Text = value; }
        }

        public string Password
        {
            // no get since password is WriteOnly
            set { this.PasswordDiv.Text = value; }
        }

        public AccountSettingsPageObject ClickLoginButton()
        {
            Mouse.Click(new HtmlButton(this.LoginDiv));

            return new AccountSettingsPageObject(this.window);
        }
    }

    [CodedUITest]
    public class NewUserAccountSettingsTests_PageObjects
    {
        protected BrowserWindow window;
        protected string newUsername;
        protected string newPassword;
        protected AccountSettingsPageObject accountSettingsPageObject;

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

            this.accountSettingsPageObject = registrationControl.ClickRegister();
        }

        [TestMethod]
        public void SavedSettingsAreRestoredAfterLogin()
        {
            const string firstName = "Mike";
            const string lastName = "Pav";

            this.accountSettingsPageObject.FirstName = firstName;
            this.accountSettingsPageObject.LastName = lastName;
            this.accountSettingsPageObject.ClickSave();

            this.accountSettingsPageObject.FirstName = "";
            this.accountSettingsPageObject.LastName = "";

            // duplicate nav definition
            HtmlCustom nav = new HtmlCustom(window);
            nav.SearchProperties.Add(HtmlControl.PropertyNames.TagName, "nav");

            HtmlButton loginButton = new HtmlButton(nav);
            loginButton.SearchProperties.Add(HtmlButton.PropertyNames.DisplayText, "Login");

            Mouse.Click(loginButton);

            // need access to the login page in account settings tests!
            // Yuck, how to deal with this?
            var loginPage = new LoginPageObject(this.window);
            loginPage.Username = this.newUsername;
            loginPage.Password = this.newPassword;

            var newReferenceToAccountSettings = loginPage.ClickLoginButton();

            Assert.IsTrue(StringComparer.Ordinal.Equals(firstName, newReferenceToAccountSettings.FirstName));
            Assert.IsTrue(StringComparer.Ordinal.Equals(lastName, newReferenceToAccountSettings.LastName));
        }
    }
}