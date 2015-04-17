using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public abstract class AlertPageModelBase<TNextModel, TUIType> : PageModelBase<TUIType>, IAlertPageModel, IPageModel
                                                                    where TNextModel : IPageModel
                                                                    where TUIType : UITestControl
    {
        IPageModel IAlertPageModel.Acknowledge()
        {
            return this.Acknowledge();
        }

        abstract public TNextModel Acknowledge();
    }
}