using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public abstract class HtmlConfirmDenyPageModelBase<TUIType, TUIConfirmClickElement, TUIDenyClickElement, TConfirmModel, TDenyModel> : HtmlHasNextModelPageModelBase<TUIType, TConfirmModel, TDenyModel>, IConfirmDenyPageModel<TConfirmModel, TDenyModel>
        where TConfirmModel : IPageModel
        where TDenyModel : IPageModel
        where TUIType : HtmlControl
        where TUIConfirmClickElement : HtmlControl
        where TUIDenyClickElement : HtmlControl
    {
        protected HtmlConfirmDenyPageModelBase(BrowserWindow bw, TConfirmModel confirmModel, TDenyModel denyModel)
            : base(bw, confirmModel, denyModel)
        {
        }

        abstract protected TUIConfirmClickElement ConfirmElement { get; }

        public TConfirmModel Confirm()
        {
            Mouse.Click(ConfirmElement);
            return this.NextModel1;
        }

        abstract protected TUIDenyClickElement DenyElement { get; }

        public TDenyModel Deny()
        {
            Mouse.Click(ConfirmElement);
            return this.NextModel2;
        }
    }
}