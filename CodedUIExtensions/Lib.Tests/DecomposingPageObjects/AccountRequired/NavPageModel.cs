using CaptainPav.Testing.UI.CodedUI;
using CaptainPav.Testing.UI.CodedUI.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Lib.Tests.DecomposingPageObjects.AccountRequired
{
    public interface INavPageModel : IPageModel
    {
        IClickablePageModel<IRegisterPageModel> Register { get; }
        IClickablePageModel<ILayoutPageModel> Login { get; }
        IClickablePageModel<IOrdersPageModel> Orders { get; }
        IClickablePageModel<IAccountSettingsPageModel> AccountSettings { get; }
    }

    public class NavPageModel : HtmlChildPageModelBase<HtmlNavigation>, INavPageModel
    {
        public NavPageModel(BrowserWindow bw, HtmlNavigation me) : base(bw, me)
        {
        }

        public IClickablePageModel<IRegisterPageModel> Register
            => this.Me
                   .Find<HtmlButton>(HtmlButton.PropertyNames.InnerText, "Register", PropertyExpressionOperator.EqualTo)
                   .AsPageModel(new RegisterPageModel(this.parent));

        public IClickablePageModel<ILayoutPageModel> Login
            => this.Me
                   .Find<HtmlButton>(HtmlButton.PropertyNames.InnerText, "Login", PropertyExpressionOperator.EqualTo)
                   .AsPageModel(new LayoutPageModelBase(this.parent));

        public IClickablePageModel<IOrdersPageModel> Orders
            => this.Me
                   .Find<HtmlButton>(HtmlButton.PropertyNames.InnerText, "Orders", PropertyExpressionOperator.EqualTo)
                   .AsPageModel(new OrdersPageModel(this.parent));

        public IClickablePageModel<IAccountSettingsPageModel> AccountSettings
            => this.Me
                   .Find<HtmlButton>(HtmlButton.PropertyNames.InnerText, "Account Settings", PropertyExpressionOperator.EqualTo)
                   .AsPageModel(new AccountSettingsPageModel(this.parent));
    }
}