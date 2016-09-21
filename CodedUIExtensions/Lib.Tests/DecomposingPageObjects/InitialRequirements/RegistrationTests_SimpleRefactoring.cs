using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Tests.DecomposingPageObjects.InitialRequirements
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class RegistrationTests_SimpleRefactoring
    {
        protected BrowserWindow window;

        // helper to set registration form values
        // demo: what happens if we add a Remember Me button?
        protected static void SetFormValues(HtmlDiv registerDiv, string username, string password, string confirmPassword)
        {
            HtmlDiv usernamePasswordDiv = new HtmlDiv(registerDiv);

            if (null != username)
            {
                HtmlEdit usernameDiv = new HtmlEdit(usernamePasswordDiv);
                usernameDiv.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "username", PropertyExpressionOperator.Contains);
                usernameDiv.Text = username;
            }

            if (null != password)
            {
                HtmlEdit passwordDiv = new HtmlEdit(usernamePasswordDiv);
                passwordDiv.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "password", PropertyExpressionOperator.Contains);
                passwordDiv.Text = password;
            }

            if (null != confirmPassword)
            {
                HtmlEdit confirmPasswordDiv = new HtmlEdit(registerDiv);
                confirmPasswordDiv.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "confirmPassword", PropertyExpressionOperator.Contains);
                confirmPasswordDiv.Text = confirmPassword;
            }
        }

        [TestInitialize]
        public void GivenRegistrationPage()
        {
            window = BrowserWindow.Launch($"{TestConfig.UrlBase}/DecomposingPageObjects/InitialRequirements");

            HtmlCustom nav = new HtmlCustom(window);
            nav.SearchProperties.Add(HtmlControl.PropertyNames.TagName, "nav");

            HtmlButton registerButton = new HtmlButton(nav);
            registerButton.SearchProperties.Add(HtmlButton.PropertyNames.DisplayText, "Register");

            Mouse.Click(registerButton);
        }

        [TestMethod]
        public void RegistrationButtonEnabledOnlyWhenFormValid()
        {
            HtmlDiv registerDiv = new HtmlDiv(this.window);
            registerDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "registerControl", PropertyExpressionOperator.EqualTo);

            #region Comparison 1
            /*****************************
             * HtmlDiv usernamePasswordDiv = new HtmlDiv(registerDiv);
             *
             * HtmlEdit username = new HtmlEdit(usernamePasswordDiv);
             * username.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "username", PropertyExpressionOperator.Contains);
             * username.Text = "";
             *
             * HtmlEdit password = new HtmlEdit(usernamePasswordDiv);
             * password.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "password", PropertyExpressionOperator.Contains);
             * password.Text = "";
             *
             * HtmlEdit confirmPassword = new HtmlEdit(registerDiv);
             * confirmPassword.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "confirmPassword", PropertyExpressionOperator.Contains);
             * confirmPassword.Text = "";
             */
            #endregion

            // demo: above becomes this one line
            SetFormValues(registerDiv, String.Empty, String.Empty, String.Empty);

            HtmlButton submitRegisterButton = new HtmlButton(registerDiv);
            Assert.IsTrue(submitRegisterButton.TryFind());
            Assert.IsFalse(submitRegisterButton.Enabled);

            #region Comparison 2
            /**********************************
             * HtmlButton submitRegisterButton = new HtmlButton(registerDiv);
             * Assert.IsTrue(submitRegisterButton.TryFind());
             * Assert.IsFalse(submitRegisterButton.Enabled);
             *
             * username.Text = "mike";
             * Assert.IsFalse(submitRegisterButton.Enabled);
             *
             * password.Text = "password";
             * Assert.IsFalse(submitRegisterButton.Enabled);
             *
             * confirmPassword.Text = "nomatch";
             * Assert.IsFalse(submitRegisterButton.Enabled);
             *
             * confirmPassword.Text = "password";
             * Assert.IsTrue(submitRegisterButton.Enabled);
             */
            #endregion

            // demo: this doesn't look quite as nice to me though
            // demo: any thoughts on how to make this nicer? 
            // demo: [interactive]
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

            #region Comparison 1
            /****************************
             * HtmlDiv usernamePasswordDiv = new HtmlDiv(registerDiv);
             *
             * HtmlEdit username = new HtmlEdit(usernamePasswordDiv);
             * username.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "username", PropertyExpressionOperator.Contains);
             * username.Text = Guid.NewGuid().ToString("N");
             * 
             * HtmlEdit password = new HtmlEdit(usernamePasswordDiv);
             * password.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "password", PropertyExpressionOperator.Contains);
             * password.Text = "pass";
             * 
             * HtmlEdit confirmPassword = new HtmlEdit(registerDiv);
             * confirmPassword.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "confirmPassword", PropertyExpressionOperator.Contains);
             * confirmPassword.Text = "pass"; 
             */
            #endregion

            // demo: becomes this one line
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