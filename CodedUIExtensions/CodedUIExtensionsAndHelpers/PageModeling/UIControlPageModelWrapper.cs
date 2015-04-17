using System;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.PageModeling
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

        protected override T Me
        {
            get { return this._control; }
        }
    }

    /// <summary>
    /// Wraps a control in a Button-esque Page Model to provide consistent,
    /// but abstracted access to properties of the control and a means of
    /// clicking the control to get to the next model
    /// </summary>
    /// <typeparam name="TUIControl">
    /// Type of UI Control wrapped as a Button-esque page model
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// Type of Model that results from the Click action
    /// </typeparam>
    public class ButtonControlPageModelWrapper<TUIControl, TNextModel> : UIControlPageModelWrapper<TUIControl> where TUIControl : UITestControl
    {
        /// <summary>
        /// The next model to interact with after clicking
        /// </summary>
        protected readonly TNextModel NextModel;
        public ButtonControlPageModelWrapper(TUIControl control, TNextModel nextModel) : base(control) 
        {
            if (null == nextModel)
            {
                throw new ArgumentNullException("nextModel");
            }
            this.NextModel = nextModel;
        }

        /// <summary>
        /// Click this Page Model and navigate to the next Page Model
        /// </summary>
        /// <returns>
        /// The next Page Model with which to interact
        /// </returns>
        public TNextModel Click()
        {
            Mouse.Click(this._control);
            return this.NextModel;
        }
    }
}