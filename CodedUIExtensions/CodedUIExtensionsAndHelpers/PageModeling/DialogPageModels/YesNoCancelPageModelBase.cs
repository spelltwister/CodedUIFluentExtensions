using System;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public abstract class YesNoCancelPageModelBase<TYesModel, TNoModel, TCancelModel, TUIType> : PageModelBase<TUIType>, IConfirmDenyPageModel, ICancellablePageModel, IPageModel
                                                                                                 where TYesModel : IPageModel
                                                                                                 where TNoModel : IPageModel
                                                                                                 where TCancelModel : IPageModel
                                                                                                 where TUIType : UITestControl
    {
        protected readonly TYesModel YesModel;
        protected readonly TNoModel NoModel;
        protected readonly TCancelModel CancelModel;
        protected YesNoCancelPageModelBase(TYesModel yesModel, TNoModel noModel, TCancelModel cancelModel)
        {
            if (null == yesModel)
            {
                throw new ArgumentNullException("yesModel");
            }

            if (null == noModel)
            {
                throw new ArgumentNullException("noModel");
            }

            if (null == cancelModel)
            {
                throw new ArgumentNullException("cancelModel");
            }

            this.YesModel = yesModel;
            this.NoModel = noModel;
            this.CancelModel = cancelModel;
        }

        IPageModel IConfirmDenyPageModel.Confirm()
        {
            return this.Confirm();
        }

        abstract public TYesModel Confirm();

        IPageModel IConfirmDenyPageModel.Deny()
        {
            return this.Deny();
        }

        abstract public TNoModel Deny();

        IPageModel ICancellablePageModel.Cancel()
        {
            return this.Cancel();
        }

        abstract public TCancelModel Cancel();
    }
}