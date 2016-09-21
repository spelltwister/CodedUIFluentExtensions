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
    public class RegistrationTests_TestInitialize
    {
        // reference to the initialized window
        // on the registration page
        protected BrowserWindow window;

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

            HtmlDiv usernamePasswordDiv = new HtmlDiv(registerDiv);

            HtmlEdit username = new HtmlEdit(usernamePasswordDiv);
            username.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "username", PropertyExpressionOperator.Contains);
            username.Text = "";

            HtmlEdit password = new HtmlEdit(usernamePasswordDiv);
            password.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "password", PropertyExpressionOperator.Contains);
            password.Text = "";

            HtmlEdit confirmPassword = new HtmlEdit(registerDiv);
            confirmPassword.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "confirmPassword", PropertyExpressionOperator.Contains);
            confirmPassword.Text = "";

            HtmlButton submitRegisterButton = new HtmlButton(registerDiv);
            Assert.IsTrue(submitRegisterButton.TryFind());
            Assert.IsFalse(submitRegisterButton.Enabled);

            username.Text = "mike";
            Assert.IsFalse(submitRegisterButton.Enabled);

            password.Text = "password";
            Assert.IsFalse(submitRegisterButton.Enabled);

            confirmPassword.Text = "nomatch";
            Assert.IsFalse(submitRegisterButton.Enabled);

            confirmPassword.Text = "password";
            Assert.IsTrue(submitRegisterButton.Enabled);
        }

        [TestMethod]
        public void AfterRegisteringNewUser_AccountSettingsIsShown()
        {
            HtmlDiv registerDiv = new HtmlDiv(this.window);
            registerDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "registerControl", PropertyExpressionOperator.EqualTo);

            HtmlDiv usernamePasswordDiv = new HtmlDiv(registerDiv);

            HtmlEdit username = new HtmlEdit(usernamePasswordDiv);
            username.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "username", PropertyExpressionOperator.Contains);
            username.Text = Guid.NewGuid().ToString("N");

            HtmlEdit password = new HtmlEdit(usernamePasswordDiv);
            password.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "password", PropertyExpressionOperator.Contains);
            password.Text = "pass";

            HtmlEdit confirmPassword = new HtmlEdit(registerDiv);
            confirmPassword.SearchProperties.Add(HtmlEdit.PropertyNames.ControlDefinition, "confirmPassword", PropertyExpressionOperator.Contains);
            confirmPassword.Text = "pass";

            HtmlDiv accountSettingsDiv = new HtmlDiv(window);
            accountSettingsDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "accountSettingsControl");

            Assert.IsTrue(accountSettingsDiv.Width == 0 && accountSettingsDiv.Height == 0);

            HtmlButton submitRegisterButton = new HtmlButton(registerDiv);
            Mouse.Click(submitRegisterButton);

            Assert.IsFalse(accountSettingsDiv.Width == 0 && accountSettingsDiv.Height == 0);
        }
    }
}