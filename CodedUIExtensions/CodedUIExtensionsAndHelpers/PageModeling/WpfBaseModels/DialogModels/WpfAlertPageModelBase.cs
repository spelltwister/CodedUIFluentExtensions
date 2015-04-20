using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public abstract class WpfAlertPageModelBase<TUIType, TUIClickElement, TNextModel> : WpfHasNextModelPageModelBase<TUIType, TNextModel>, IAlertPageModel<TNextModel>
        where TNextModel : IPageModel
        where TUIType : WpfControl
        where TUIClickElement : WpfControl
    {
        protected WpfAlertPageModelBase(WpfWindow bw, TNextModel nextModel) : base(bw, nextModel)
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