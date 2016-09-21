using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Tests.DecomposingPageObjects.ButtonHidden
{
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

        // demo: had to add a property, but still needed the old one
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

    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class RegistrationTests_PageObjects
    {
        protected BrowserWindow window;
        
        [TestInitialize]
        public void GivenRegistrationPage()
        {
            window = BrowserWindow.Launch($"{TestConfig.UrlBase}/DecomposingPageObjects/Change2");

            HtmlCustom nav = new HtmlCustom(window);
            nav.SearchProperties.Add(HtmlControl.PropertyNames.TagName, "nav");

            HtmlButton registerButton = new HtmlButton(nav);
            registerButton.SearchProperties.Add(HtmlButton.PropertyNames.DisplayText, "Register");

            Mouse.Click(registerButton);
        }

        [TestMethod]
        public void ConfirmPasswordNotVisibleWhenCredentialsNotSet()
        {
            var registerControl = new RegistrationControlPageObject(this.window);

            registerControl.SetFormValues("a", "b", String.Empty);
            registerControl.SetFormValues(String.Empty, String.Empty, null);

            Assert.IsFalse(registerControl.IsConfirmPasswordVisible);

            registerControl.SetFormValues("mike", null, null);
            Assert.IsFalse(registerControl.IsConfirmPasswordVisible);

            registerControl.SetFormValues(null, "pass", null);
            Assert.IsTrue(registerControl.IsConfirmPasswordVisible);

            registerControl.SetFormValues(String.Empty, null, null);
            Assert.IsFalse(registerControl.IsConfirmPasswordVisible);
        }

        [TestMethod]
        public void RegistrationButtonEnabledOnlyWhenFormValid()
        {
            var registerControl = new RegistrationControlPageObject(this.window);

            registerControl.SetFormValues("a", "b", String.Empty);
            registerControl.SetFormValues(String.Empty, String.Empty, null);

            // demo: remember these?
            // Assert.IsTrue(registerControl.RegisterButton.TryFind());
            // Assert.IsFalse(registerControl.RegisterButton.Enabled);
            #region Spoiler
            // demo:
            // try find will still succeed because it is in the markup
            // regarless of whether it is visible!
            // Assert.IsTrue(registerControl.RegisterButton.TryFind());
            // Assert.IsFalse(registerControl.RegisterButton.Enabled);
            #endregion
            Assert.IsFalse(registerControl.IsRegisterButtonVisible);

            registerControl.SetFormValues("mike", null, null);
            Assert.IsFalse(registerControl.IsRegisterButtonVisible);

            registerControl.SetFormValues(null, "password", null);
            Assert.IsTrue(registerControl.IsRegisterButtonVisible);
            Assert.IsFalse(registerControl.IsRegisterButtonEnabled);

            registerControl.SetFormValues(null, null, "nomatch");
            Assert.IsTrue(registerControl.IsRegisterButtonVisible);
            Assert.IsFalse(registerControl.IsRegisterButtonEnabled);

            registerControl.SetFormValues(null, null, "password");
            Assert.IsTrue(registerControl.IsRegisterButtonVisible);
            Assert.IsTrue(registerControl.IsRegisterButtonEnabled);
        }

        [TestMethod]
        public void AfterRegisteringNewUser_AccountSettingsIsShown()
        {
            var registerControl = new RegistrationControlPageObject(this.window);
            registerControl.SetFormValues(Guid.NewGuid().ToString("N"), "pass", "pass");

            HtmlDiv accountSettingsDiv = new HtmlDiv(window);
            accountSettingsDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "accountSettingsControl");

            Assert.IsTrue(accountSettingsDiv.Width == 0 && accountSettingsDiv.Height == 0);

            registerControl.ClickRegister();

            Assert.IsFalse(accountSettingsDiv.Width == 0 && accountSettingsDiv.Height == 0);
        }
    }
}