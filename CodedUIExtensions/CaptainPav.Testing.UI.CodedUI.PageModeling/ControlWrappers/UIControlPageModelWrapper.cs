using System;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers
{
    /// <summary>
    /// Wraps a control in a page model to provide consistent, but abstracted
    /// access to properties of the control as though it were a page model
    /// </summary>
    /// <typeparam name="T">
    /// Type of control wrapped as a page model
    /// </typeparam>
    public class UIControlPageModelWrapper<T> : PageModelBase<T> where T : UITestControl
    {
        protected readonly T _control;
        public UIControlPageModelWrapper(T control)
        {
            if (null == control)
            {
                throw new ArgumentNullException("control");
            }
            this._control = control;
        }

        internal protected override T Me
        {
            get { return this._control; }
        }
    }
}