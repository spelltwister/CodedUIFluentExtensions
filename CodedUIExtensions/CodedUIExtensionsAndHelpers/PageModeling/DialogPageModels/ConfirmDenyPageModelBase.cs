using System;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public abstract class ConfirmDenyPageModelBase<TConfirmModel, TDenyModel, TUIType> : PageModelBase<TUIType>, IConfirmDenyPageModel, IPageModel
                                                                                         where TConfirmModel : IPageModel
                                                                                         where TDenyModel : IPageModel
                                                                                         where TUIType : UITestControl
    {
        protected readonly TConfirmModel ConfirmModel;
        protected readonly TDenyModel DenyModel;
        protected ConfirmDenyPageModelBase(TConfirmModel confirmModel, TDenyModel denyModel)
        {
            if (null == confirmModel)
            {
                throw new ArgumentNullException("confirmModel");
            }

            if (null == denyModel)
            {
                throw new ArgumentNullException("denyModel");
            }

            this.ConfirmModel = confirmModel;
            this.DenyModel = denyModel;            
        }
        
        IPageModel IConfirmDenyPageModel.Confirm()
        {
            return this.Confirm();
        }

        abstract public TConfirmModel Confirm();

        IPageModel IConfirmDenyPageModel.Deny()
        {
            return this.Deny();
        }

        abstract public TDenyModel Deny();
    }
}