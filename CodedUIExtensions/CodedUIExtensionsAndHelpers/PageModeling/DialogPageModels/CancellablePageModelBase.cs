using System;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public abstract class CancellablePageModelBase<TCancelModel, TUIType> : PageModelBase<TUIType>, ICancellablePageModel, IPageModel
                                                                            where TCancelModel : IPageModel
                                                                            where TUIType : UITestControl
    {
        protected readonly TCancelModel CancelModel;
        protected CancellablePageModelBase(TCancelModel cancelModel)
        {
            if (null == cancelModel)
            {
                throw new ArgumentNullException("cancelModel");
            }

            this.CancelModel = cancelModel;
        }

        IPageModel ICancellablePageModel.Cancel()
        {
            return this.Cancel();
        }

        abstract public TCancelModel Cancel();
    }
}