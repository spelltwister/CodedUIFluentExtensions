using CaptainPav.Testing.UI.CodedUI;
using CaptainPav.Testing.UI.CodedUI.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Lib.Tests.DecomposingPageObjects.AccountRequired
{
    public interface IRegisterPageModel : ILayoutPageModel
    {
        IReadWriteValuePageModel<string, IRegisterPageModel> Username { get; }
        IValueablePageModel<string, IRegisterPageModel> Password { get; }
        IValueablePageModel<string, IRegisterPageModel> ConfirmPassword { get; }
        IClickablePageModel<IAccountSettingsPageModel> Register { get; }
    }

    public class RegisterPageModel :  HtmlPageModelBase<HtmlDiv>, IRegisterPageModel
    {
        public RegisterPageModel(BrowserWindow bw) : base(bw)
        {
        }

        protected override HtmlDiv Me => this.parent.Find<HtmlDiv>("registerControl");

        public INavPageModel Nav => new NavPageModel(this.parent, this.Me.Find<HtmlNavigation>());

        public IReadWriteValuePageModel<string, IRegisterPageModel> Username
            => this.Me
                .Find<HtmlEdit>(HtmlEdit.PropertyNames.ControlDefinition, "username", PropertyExpressionOperator.Contains)
                .AsPageModel(this);

        public IValueablePageModel<string, IRegisterPageModel> Password
            => this.Me
                .Find<HtmlEdit>(HtmlEdit.PropertyNames.ControlDefinition, "password", PropertyExpressionOperator.Contains)
                .AsPageModel(this);

        public IValueablePageModel<string, IRegisterPageModel> ConfirmPassword
            => this.Me
                .Find<HtmlEdit>(HtmlEdit.PropertyNames.ControlDefinition, "confirmPassword", PropertyExpressionOperator.Contains)
                .AsPageModel(this);

        public IClickablePageModel<IAccountSettingsPageModel> Register
            => this.Me
                .Find<HtmlButton>()
                .AsPageModel(new AccountSettingsPageModel(this.parent));
    }
}