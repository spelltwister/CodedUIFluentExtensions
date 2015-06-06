using System;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers
{
    public abstract class HasNextModelUIControlPageModelWrapperBase<TUIControl, TNextModel> : UIControlPageModelWrapper<TUIControl>
        where TUIControl : UITestControl
        where TNextModel : IPageModel
    {
        protected readonly TNextModel NextModel;
        protected HasNextModelUIControlPageModelWrapperBase(TUIControl control, TNextModel nextModel) : base(control)
        {
            if (null == nextModel)
            {
                throw new ArgumentNullException("nextModel");
            }
            NextModel = nextModel;
        }
    }
}