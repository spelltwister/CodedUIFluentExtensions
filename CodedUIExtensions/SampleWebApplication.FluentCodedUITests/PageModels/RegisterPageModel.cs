using CodedUIExtensionsAndHelpers.AdditionalControls.Html;
using CodedUIExtensionsAndHelpers.Fluent;
using CodedUIExtensionsAndHelpers.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace SampleWebApplication.FluentCodedUITests.PageModels
{
    public class RegisterPageModel : HtmlPageModelBase<HtmlForm>
    {
        public RegisterPageModel(BrowserWindow bw) : base(bw) { }

        protected override HtmlForm Me
        {
            get
            {
                return this.DocumentWindow.Find<HtmlForm>();
            }
        }

        protected HtmlEdit EmailEdit
        {
            get
            {
                return this.Me.Find<HtmlEdit>("Email");
            }
        }

        protected HtmlEdit HometownEdit
        {
            get
            {
                return this.Me.Find<HtmlEdit>("Hometown");
            }
        }

        protected HtmlEdit PasswordEdit
        {
            get
            {
                return this.Me.Find<HtmlEdit>("Password");
            }
        }

        protected HtmlEdit ConfirmPasswordEdit
        {
            get
            {
                return this.Me.Find<HtmlEdit>("ConfirmPassword");
            }
        }

        protected HtmlInputButton RegisterButton
        {
            get
            {
                return this.Me.Find<HtmlInputButton>();
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
