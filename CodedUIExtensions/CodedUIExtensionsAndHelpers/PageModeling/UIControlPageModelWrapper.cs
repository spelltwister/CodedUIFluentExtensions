using System;
using System.Threading;
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

        internal protected override T Me
        {
            get { return this._control; }
        }
    }

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
    public class ClickableControlPageModelWrapper<TUIControl, TNextModel> : HasNextModelUIControlPageModelWrapperBase<TUIControl, TNextModel>, IClickablePageModel<TNextModel> 
                                                                            where TUIControl : UITestControl
                                                                            where TNextModel : IPageModel
    {
        public ClickableControlPageModelWrapper(TUIControl control, TNextModel nextModel) : base(control, nextModel)
        {
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

    public abstract class SelectableControlPageModelWrapper<TUIControl, TNextModel> : HasNextModelUIControlPageModelWrapperBase<TUIControl, TNextModel>, ISelectablePageModel<TNextModel>
                                                                                      where TUIControl : UITestControl
                                                                                      where TNextModel : IPageModel
    {
        protected SelectableControlPageModelWrapper(TUIControl control, TNextModel nextModel) : base(control, nextModel)
        {
        }

        public abstract bool IsSelected { get; }

        public abstract TNextModel SetSelected(bool selectionState);
    }
}