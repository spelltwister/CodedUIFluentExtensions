using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Tests.DecomposingPageObjects.PasswordHidden
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

        // demo: other inputs are not available
        // this one needs visibility testing
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

        // demo: this button is publicly so that the test can make assertions
        public HtmlButton RegisterButton => new HtmlButton(this.RegistrationDiv);
        
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
            window = BrowserWindow.Launch($"{TestConfig.UrlBase}/DecomposingPageObjects/Change1");

            HtmlCustom nav = new HtmlCustom(window);
            nav.SearchProperties.Add(HtmlControl.PropertyNames.TagName, "nav");

            HtmlButton registerButton = new HtmlButton(nav);
            registerButton.SearchProperties.Add(HtmlButton.PropertyNames.DisplayText, "Register");

            Mouse.Click(registerButton);
        }

        [TestMethod]
        public void ConfirmPasswordNotVisibleWhenCredentialsNotSet()
        {
            /***************
             * HtmlDiv registerDiv = new HtmlDiv(this.window);
             * registerDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "registerControl", PropertyExpressionOperator.EqualTo);
             */

            // demo: no need to search
            // this is a top level page and it can find itself in the window (more on this later)
            var registerControl = new RegistrationControlPageObject(this.window);

            /*************
             * SetFormValues(registerDiv, "a", "b", String.Empty);
             * SetFormValues(registerDiv, String.Empty, String.Empty, null);
             */

             // demo: OOP style
            registerControl.SetFormValues("a", "b", String.Empty);
            registerControl.SetFormValues(String.Empty, String.Empty, null);

            /******************
             * // demo: duplicate code definition for finding this input
             * HtmlEdit confirmPasswordDiv = new HtmlEdit(registerDiv);
             * confirmPasswordDiv.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "confirmPassword", PropertyExpressionOperator.Contains);
             *
             * // demo: who can actually read these assertions ?!
             * Assert.IsTrue(confirmPasswordDiv.Width == 0 && confirmPasswordDiv.Height == 0);
             */

            // demo: no need for searching code
            // demo: can actually read the assertion, yay! :)
            #region Forshadow
            // demo: aaaand, as we'll see, the incorrect definition
            // for IsVisible has been moved into a property on the page object and out of the test
            #endregion
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

            // demo: the button was exposed to support these assertions
            Assert.IsTrue(registerControl.RegisterButton.TryFind());
            Assert.IsFalse(registerControl.RegisterButton.Enabled);

            registerControl.SetFormValues("mike", null, null);
            Assert.IsFalse(registerControl.RegisterButton.Enabled);

            registerControl.SetFormValues(null, "password", null);
            Assert.IsFalse(registerControl.RegisterButton.Enabled);

            registerControl.SetFormValues(null, null, "nomatch");
            Assert.IsFalse(registerControl.RegisterButton.Enabled);

            registerControl.SetFormValues(null, null, "password");
            Assert.IsTrue(registerControl.RegisterButton.Enabled);
        }

        [TestMethod]
        public void AfterRegisteringNewUser_AccountSettingsIsShown()
        {
            var registerControl = new RegistrationControlPageObject(this.window);
            registerControl.SetFormValues(Guid.NewGuid().ToString("N"), "pass", "pass");

            HtmlDiv accountSettingsDiv = new HtmlDiv(window);
            accountSettingsDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "accountSettingsControl");

            Assert.IsTrue(accountSettingsDiv.Width == 0 && accountSettingsDiv.Height == 0);

            // demo: the button is also exposed for clicking in the test
            Mouse.Click(registerControl.RegisterButton);

            Assert.IsFalse(accountSettingsDiv.Width == 0 && accountSettingsDiv.Height == 0);
        }
    }
}