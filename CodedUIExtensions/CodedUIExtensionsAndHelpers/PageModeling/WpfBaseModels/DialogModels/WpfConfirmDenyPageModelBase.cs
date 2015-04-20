using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public abstract class WpfConfirmDenyPageModelBase<TUIType, TUIConfirmClickElement, TUIDenyClickElement, TConfirmModel, TDenyModel> : WpfHasNextModelPageModelBase<TUIType, TConfirmModel, TDenyModel>, IConfirmDenyPageModel<TConfirmModel, TDenyModel>
        where TConfirmModel : IPageModel
        where TDenyModel : IPageModel
        where TUIType : WpfControl
        where TUIConfirmClickElement : WpfControl
        where TUIDenyClickElement : WpfControl
    {
        protected WpfConfirmDenyPageModelBase(WpfWindow bw, TConfirmModel confirmModel, TDenyModel denyModel)
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