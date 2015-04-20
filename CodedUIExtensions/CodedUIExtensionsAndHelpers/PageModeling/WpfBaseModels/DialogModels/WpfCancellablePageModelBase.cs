using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public abstract class WpfCancellablePageModelBase<TUIType, TUICancelClickElement, TNextModel> : WpfHasNextModelPageModelBase<TUIType, TNextModel>, ICancellablePageModel<TNextModel>
        where TNextModel : IPageModel
        where TUIType : WpfControl
        where TUICancelClickElement : WpfControl
    {
        protected WpfCancellablePageModelBase(WpfWindow bw, TNextModel nextModel) : base(bw, nextModel)
        {
        }

        abstract protected TUICancelClickElement ClickToAcknowledge { get; }

        public TNextModel Cancel()
        {
            Mouse.Click(ClickToAcknowledge);
            return this.NextModel1;
        }
    }
}