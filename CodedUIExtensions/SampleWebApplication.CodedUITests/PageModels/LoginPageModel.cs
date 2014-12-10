using CodedUIExtensionsAndHelpers.AdditionalControls.Html;
using CodedUIExtensionsAndHelpers.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace SampleWebApplication.CodedUITests.PageModels
{
    public class LoginPageModel : HtmlPageModelBase<HtmlDiv>
    {
        public LoginPageModel(BrowserWindow bw) : base(bw) { }
        protected override HtmlDiv Me
        {
            get
            {
                HtmlDiv ret = new HtmlDiv(this.DocumentWindow);
                ret.SearchProperties.Add(HtmlControl.PropertyNames.Class, "body-content", PropertyExpressionOperator.Contains);
                return ret;
            }
        }

        protected HtmlSection LoginFormSection
        {
            get
            {
                HtmlSection c = new HtmlSection(this.Me);
                c.SearchProperties.Add(HtmlControl.PropertyNames.Id, "loginForm", PropertyExpressionOperator.EqualTo);
                return c;
            }
        }

        protected HtmlEdit EmailTextBox
        {
            get
            {
                HtmlEdit email = new HtmlEdit(this.LoginFormSection);
                email.SearchProperties.Add(HtmlControl.PropertyNames.Id, "Email", PropertyExpressionOperator.EqualTo);
                return email;
            }
        }

        protected HtmlEdit PasswordTextBox
        {
            get
            {
                HtmlEdit password = new HtmlEdit(this.LoginFormSection);
                password.SearchProperties.Add(HtmlControl.PropertyNames.Id, "Password", PropertyExpressionOperator.EqualTo);
                return password;
            }
        }

        protected HtmlCheckBox RememberMeCheck
        {
            get
            {
                HtmlCheckBox remember = new HtmlCheckBox(this.LoginFormSection);
                remember.SearchProperties.Add(HtmlControl.PropertyNames.Id, "RememberMe", PropertyExpressionOperator.EqualTo);
                return remember;
            }
        }

        protected HtmlInputButton LoginButton
        {
            get
            {
                return new HtmlInputButton(this.Me);
            }
        }

        protected HtmlHyperlink RegisterNewUserLink
        {
            get
            {
                HtmlHyperlink registerNew = new HtmlHyperlink(this.LoginFormSection);
                registerNew.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, "Register as a new user", PropertyExpressionOperator.EqualTo);
                return registerNew;
            }
        }

        public LoginPageModel SetEmail(string email)
        {
            this.EmailTextBox.Text = email;
            return this;
        }

        public LoginPageModel SetPassword(string password)
        {
            this.PasswordTextBox.Text = password;
            return this;
        }

        public LoginPageModel SetRememberMe(bool check)
        {
            if (this.RememberMeCheck.Checked != check)
            {
                Mouse.Click(this.RememberMeCheck);
            }
            return this;
        }

        public HomePageModel ClickLoginButton()
        {
            Mouse.Click(this.LoginButton);
            return new HomePageModel(this.parent);
        }

        public RegisterPageModel ClickRegisterLink()
        {
            Mouse.Click(this.RegisterNewUserLink);
            return new RegisterPageModel(this.parent);
        }
    }
}