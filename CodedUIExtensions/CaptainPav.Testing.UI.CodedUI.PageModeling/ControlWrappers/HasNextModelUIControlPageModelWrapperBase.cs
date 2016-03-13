using System;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers
{
    /// <summary>
    /// Base class used when a page model wrapper needs to capture
    /// information regarding the next logical model that will be used by
    /// the client
    /// </summary>
    /// <typeparam name="TUIControl">
    /// Type of control wrapped as a page model
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// Type of the next logical model that will be used by the client
    /// </typeparam>
    public abstract class HasNextModelUIControlPageModelWrapperBase<TUIControl, TNextModel> : UIControlPageModelWrapper<TUIControl>
        where TUIControl : UITestControl
        where TNextModel : IPageModel
    {
        protected readonly TNextModel NextModel;
        protected HasNextModelUIControlPageModelWrapperBase(TUIControl control, TNextModel nextModel) : base(control)
        {
            if (null == nextModel)
            {
                throw new ArgumentNullException(nameof(nextModel));
            }

            this.NextModel = nextModel;
        }
    }
}