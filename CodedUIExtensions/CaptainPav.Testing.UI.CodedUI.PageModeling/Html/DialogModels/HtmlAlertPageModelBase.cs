using CaptainPav.Testing.UI.PageModeling;
using CaptainPav.Testing.UI.PageModeling.DialogPageModels;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.DialogModels
{
    public abstract class HtmlAlertPageModelBase<TUIType, TUIClickElement, TNextModel> : HtmlHasNextModelPageModelBase<TUIType, TNextModel>, IAlertPageModel<TNextModel>
        where TNextModel : IPageModel
        where TUIType : HtmlControl
        where TUIClickElement : HtmlControl
    {
        protected HtmlAlertPageModelBase(BrowserWindow bw, TNextModel nextModel) : base(bw, nextModel)
        {
        }

        abstract protected TUIClickElement ClickToAcknowledge { get; }
        abstract public string Message { get; }

        public IClickablePageModel<TNextModel> AcknowledgeModel
        {
            get { return this.ClickToAcknowledge.AsClickablePageModel(this.NextModel1); }
        } 

        public TNextModel Acknowledge()
        {
            return this.AcknowledgeModel.Click();
        }
    }
}