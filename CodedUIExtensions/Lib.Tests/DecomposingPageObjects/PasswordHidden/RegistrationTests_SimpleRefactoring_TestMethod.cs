using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Tests.DecomposingPageObjects.PasswordHidden
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class RegistrationTests_SimpleRefactoring_TestMethod
    {
        protected BrowserWindow window;

        protected static void SetFormValues(HtmlDiv registerDiv, string username, string password, string confirmPassword)
        {
            HtmlDiv usernamePasswordDiv = new HtmlDiv(registerDiv);

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

            HtmlEdit confirmPasswordDiv = new HtmlEdit(registerDiv);
            confirmPasswordDiv.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "confirmPassword", PropertyExpressionOperator.Contains);

            if (null != confirmPassword)
            {
                confirmPasswordDiv.Text = confirmPassword;
            }
        }

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
            HtmlDiv registerDiv = new HtmlDiv(this.window);
            registerDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "registerControl", PropertyExpressionOperator.EqualTo);

            SetFormValues(registerDiv, "a", "b", String.Empty);
            SetFormValues(registerDiv, String.Empty, String.Empty, null);

            // demo: duplicate code definition for finding this input
            HtmlEdit confirmPasswordDiv = new HtmlEdit(registerDiv);
            confirmPasswordDiv.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "confirmPassword", PropertyExpressionOperator.Contains);

            // demo: who can actually read these assertions ?!
            Assert.IsTrue(confirmPasswordDiv.Width == 0 && confirmPasswordDiv.Height == 0);

            SetFormValues(registerDiv, "mike", null, null);
            Assert.IsTrue(confirmPasswordDiv.Width == 0 && confirmPasswordDiv.Height == 0);

            SetFormValues(registerDiv, null, "pass", null);
            Assert.IsFalse(confirmPasswordDiv.Width == 0 && confirmPasswordDiv.Height == 0);

            SetFormValues(registerDiv, String.Empty, null, null);
            Assert.IsTrue(confirmPasswordDiv.Width == 0 && confirmPasswordDiv.Height == 0);
        }

        [TestMethod]
        public void RegistrationButtonEnabledOnlyWhenFormValid()
        {
            HtmlDiv registerDiv = new HtmlDiv(this.window);
            registerDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "registerControl", PropertyExpressionOperator.EqualTo);

            SetFormValues(registerDiv, "a", "b", String.Empty);
            SetFormValues(registerDiv, String.Empty, String.Empty, null);

            HtmlButton submitRegisterButton = new HtmlButton(registerDiv);
            Assert.IsTrue(submitRegisterButton.TryFind());
            Assert.IsFalse(submitRegisterButton.Enabled);

            // demo: would prefer the password hidden checks looked more like this
            #region Spoiler
            // ... sounds like a job for page objects
            #endregion
            SetFormValues(registerDiv, "mike", null, null);
            Assert.IsFalse(submitRegisterButton.Enabled);

            SetFormValues(registerDiv, null, "password", null);
            Assert.IsFalse(submitRegisterButton.Enabled);

            SetFormValues(registerDiv, null, null, "nomatch");
            Assert.IsFalse(submitRegisterButton.Enabled);

            SetFormValues(registerDiv, null, null, "password");
            Assert.IsTrue(submitRegisterButton.Enabled);
        }

        [TestMethod]
        public void AfterRegisteringNewUser_AccountSettingsIsShown()
        {
            HtmlDiv registerDiv = new HtmlDiv(this.window);
            registerDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "registerControl", PropertyExpressionOperator.EqualTo);

            SetFormValues(registerDiv, Guid.NewGuid().ToString("N"), "pass", "pass");

            HtmlDiv accountSettingsDiv = new HtmlDiv(window);
            accountSettingsDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "accountSettingsControl");

            Assert.IsTrue(accountSettingsDiv.Width == 0 && accountSettingsDiv.Height == 0);

            HtmlButton submitRegisterButton = new HtmlButton(registerDiv);
            Mouse.Click(submitRegisterButton);

            Assert.IsFalse(accountSettingsDiv.Width == 0 && accountSettingsDiv.Height == 0);
        }
    }
}