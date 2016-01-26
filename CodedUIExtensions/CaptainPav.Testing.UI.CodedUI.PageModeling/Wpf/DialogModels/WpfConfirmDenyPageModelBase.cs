using CaptainPav.Testing.UI.PageModeling;
using CaptainPav.Testing.UI.PageModeling.DialogPageModels;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf.DialogModels
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
        abstract public string Message { get; }

        public IClickablePageModel<TConfirmModel> ConfirmModel
        {
            get { return this.ConfirmElement.AsClickablePageModel(this.NextModel1); }
        }

        public TConfirmModel Confirm()
        {
            return this.ConfirmModel.Click();
        }

        abstract protected TUIDenyClickElement DenyElement { get; }

        public IClickablePageModel<TDenyModel> DenyModel
        {
            get { return this.DenyElement.AsClickablePageModel(this.NextModel2); }
        }

        public TDenyModel Deny()
        {
            return DenyModel.Click();
        }
    }
}