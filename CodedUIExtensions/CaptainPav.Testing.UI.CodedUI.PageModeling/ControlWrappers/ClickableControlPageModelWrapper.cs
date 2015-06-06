using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers
{
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

        /// <summary>
        /// Double click this Page Model and navigate to the next Page Model
        /// </summary>
        /// <returns>
        /// The next Page Model with which to interact
        /// </returns>
        public TNextModel DoubleClick()
        {
            Mouse.DoubleClick(this._control);
            return this.NextModel;
        }
    }
}