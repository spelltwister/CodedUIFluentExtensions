using CodedUIAdditionalControls.Html;
using CodedUIPageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace SampleWebApplication.CodedUITests.PageModels
{
    public class RegisterPageModel : HtmlPageModelBase<HtmlForm>
    {
        public RegisterPageModel(BrowserWindow bw) : base(bw) { }

        protected override HtmlForm Me
        {
            get
            {
                return new HtmlForm(this.DocumentWindow);
            }
        }

        protected HtmlEdit EmailEdit
        {
            get
            {
                HtmlEdit ret = new HtmlEdit(this.Me);
                ret.SearchProperties.Add(HtmlControl.PropertyNames.Id, "Email", PropertyExpressionOperator.EqualTo);
                return ret;
            }
        }

        protected HtmlEdit HometownEdit
        {
            get
            {
                HtmlEdit ret = new HtmlEdit(this.Me);
                ret.SearchProperties.Add(HtmlControl.PropertyNames.Id, "Hometown", PropertyExpressionOperator.EqualTo);
                return ret;
            }
        }

        protected HtmlEdit PasswordEdit
        {
            get
            {
                HtmlEdit ret = new HtmlEdit(this.Me);
                ret.SearchProperties.Add(HtmlControl.PropertyNames.Id, "Password", PropertyExpressionOperator.EqualTo);
                return ret;
            }
        }

        protected HtmlEdit ConfirmPasswordEdit
        {
            get
            {
                HtmlEdit ret = new HtmlEdit(this.Me);
                ret.SearchProperties.Add(HtmlControl.PropertyNames.Id, "ConfirmPassword", PropertyExpressionOperator.EqualTo);
                return ret;
            }
        }

        protected HtmlInputButton RegisterButton
        {
            get
            {
                return new HtmlInputButton(this.Me);
            }
        }

        public RegisterPageModel SetEmail(string email)
        {
            this.EmailEdit.Text = email;
            return this;
        }

        public RegisterPageModel SetHometown(string hometown)
        {
            this.HometownEdit.Text = hometown;
            return this;
        }

        public RegisterPageModel SetPassword(string password)
        {
            this.PasswordEdit.Text = password;
            return this;
        }

        public RegisterPageModel SetConfirmPassword(string confirm)
        {
            this.ConfirmPasswordEdit.Text = confirm;
            return this;
        }

        /// <summary>
        /// Clicks the register button and navigates to the home page
        /// if the registration is successful
        /// </summary>
        /// <returns>
        /// A reference to the home page model which is valid only if
        /// the registration succeeds
        /// </returns>
        /// <remarks>
        /// Would prefer to upgrade this return type to a registration response
        /// model that indicates whether the registration succeeded, a
        /// reference to the home page if successful, and a reference to the
        /// registration page and access to the error messages if unsuccessful
        /// </remarks>
        public HomePageModel ClickRegisterButton()
        {
            Mouse.Click(this.RegisterButton);
            return new HomePageModel(this.parent);
        }
    }
}
