using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers
{
    // TODO: remove INamedPageModel, supposed to be on select item type
    /// <summary>
    /// Base class for controls which are selectable and have some label or
    /// other textual name associated with the control
    /// </summary>
    /// <typeparam name="TUIControl">
    /// </typeparam>
    /// <typeparam name="TNextModel"></typeparam>
    public abstract class NamedSelectableControlPageModelWrapper<TUIControl, TNextModel> : SelectableControlPageModelWrapper<TUIControl, TNextModel>, INamedPageModel
        where TUIControl : UITestControl
        where TNextModel : IPageModel
    {
        protected NamedSelectableControlPageModelWrapper(TUIControl control, TNextModel nextModel) : base(control, nextModel)
        {
        }

        /// <summary>
        /// Gets the name of this selectable control
        /// </summary>
        public abstract string Name { get; }
    }
}