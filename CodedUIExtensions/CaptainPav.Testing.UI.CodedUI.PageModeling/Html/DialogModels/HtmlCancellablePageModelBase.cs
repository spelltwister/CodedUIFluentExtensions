using CaptainPav.Testing.UI.PageModeling;
using CaptainPav.Testing.UI.PageModeling.DialogPageModels;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.DialogModels
{
    public abstract class HtmlCancellablePageModelBase<TUIType, TUICancelClickElement, TNextModel> : HtmlHasNextModelPageModelBase<TUIType, TNextModel>, ICancellablePageModel<TNextModel>
        where TNextModel : IPageModel
        where TUIType : HtmlControl
        where TUICancelClickElement : HtmlControl
    {
        protected HtmlCancellablePageModelBase(BrowserWindow bw, TNextModel nextModel) : base(bw, nextModel)
        {
        }

        abstract protected TUICancelClickElement ClickToCancelElement { get; }
        abstract public string Message { get; }

        public IClickablePageModel<TNextModel> CancelModel
        {
            get { return this.ClickToCancelElement.AsClickablePageModel(this.NextModel1); }
        } 

        public TNextModel Cancel()
        {
            return this.CancelModel.Click();
        }
    }
}