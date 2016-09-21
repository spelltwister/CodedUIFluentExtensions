using CaptainPav.Testing.UI.CodedUI;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Lib.Tests.DecomposingPageObjects.AccountRequired
{
    public interface IAccountSettingsPageModel : ILayoutPageModel
    {
        IReadWriteValuePageModel<string, IAccountSettingsPageModel> FirstName { get; }
        IReadWriteValuePageModel<string, IAccountSettingsPageModel> LastName { get; }

        IClickablePageModel<IAccountSettingsPageModel> Save { get; }
    }

    public class AccountSettingsPageModel : LayoutPageModelBase, IAccountSettingsPageModel
    {
        public AccountSettingsPageModel(BrowserWindow bw) : base(bw)
        {
        }

        protected override HtmlDiv Me => base.Me.Find<HtmlDiv>("accountSettingsControl");

        public IReadWriteValuePageModel<string, IAccountSettingsPageModel> FirstName
            => this.Me
                .Find<HtmlEdit>(HtmlEdit.PropertyNames.ControlDefinition, "firstName", PropertyExpressionOperator.Contains)
                .AsPageModel(this);

        public IReadWriteValuePageModel<string, IAccountSettingsPageModel> LastName
            => this.Me
                .Find<HtmlEdit>(HtmlEdit.PropertyNames.ControlDefinition, "lastName", PropertyExpressionOperator.Contains)
                .AsPageModel(this);

        public IClickablePageModel<IAccountSettingsPageModel> Save
            => this.Me
                .Find<HtmlButton>()
                .AsPageModel(this);
    }
}