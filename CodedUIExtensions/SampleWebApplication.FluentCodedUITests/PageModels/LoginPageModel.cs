using CodedUIAdditionalControls.Html;
using CodedUIFluentExtensions;
using CodedUIPageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace SampleWebApplication.FluentCodedUITests.PageModels
{
    public class LoginPageModel : HtmlPageModelBase<HtmlDiv>
    {
        public LoginPageModel(BrowserWindow bw) : base(bw) { }
        protected override HtmlDiv Me
        {
            get
            {
                return this.DocumentWindow
                           .Find<HtmlDiv>(HtmlControl.PropertyNames.Class, "body-content", PropertyExpressionOperator.Contains);
            }
        }

        protected HtmlSection LoginFormSection
        {
            get
            {
                return this.Me.Find<HtmlSection>("loginForm");
            }
        }

        protected HtmlEdit EmailTextBox
        {
            get
            {
                return this.LoginFormSection.Find<HtmlEdit>("Email");
            }
        }

        protected HtmlEdit PasswordTextBox
        {
            get
            {
                return this.LoginFormSection.Find<HtmlEdit>("Password");
            }
        }

        protected HtmlCheckBox RememberMeCheck
        {
            get
            {
                return this.LoginFormSection.Find<HtmlCheckBox>("RememberMe");
            }
        }

        protected HtmlInputButton LoginButton
        {
            get
            {
                return this.Me.Find<HtmlInputButton>();
            }
        }

        protected HtmlHyperlink RegisterNewUserLink
        {
            get
            {
                return this.LoginFormSection
                           .Find<HtmlHyperlink>(HtmlControl.PropertyNames.InnerText, "Register as a new user", PropertyExpressionOperator.EqualTo);
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
