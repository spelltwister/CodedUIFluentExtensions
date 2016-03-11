using CaptainPav.Testing.UI.PageModeling;
using CaptainPav.Testing.UI.PageModeling.DialogPageModels;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.DialogModels
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
        abstract public string Message { get; }

        public IClickablePageModel<TConfirmModel> ConfirmModel => this.ConfirmElement.AsClickablePageModel(this.NextModel1);

	    public TConfirmModel Confirm()
        {
            return this.ConfirmModel.Click();
        }

        abstract protected TUIDenyClickElement DenyElement { get; }

        public IClickablePageModel<TDenyModel> DenyModel => this.DenyElement.AsClickablePageModel(this.NextModel2);

	    public TDenyModel Deny()
        {
            return this.DenyModel.Click();
        }
    }
}