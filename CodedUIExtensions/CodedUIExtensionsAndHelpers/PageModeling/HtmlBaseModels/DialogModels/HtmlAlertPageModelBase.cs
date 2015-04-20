using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
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

        public TNextModel Acknowledge()
        {
            Mouse.Click(ClickToAcknowledge);
            return this.NextModel1;
        }
    }
}