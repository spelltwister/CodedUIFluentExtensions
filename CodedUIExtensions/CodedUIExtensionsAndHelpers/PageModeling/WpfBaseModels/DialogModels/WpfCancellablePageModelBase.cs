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

        abstract protected TUICancelClickElement ClickToCancelElement { get; }

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