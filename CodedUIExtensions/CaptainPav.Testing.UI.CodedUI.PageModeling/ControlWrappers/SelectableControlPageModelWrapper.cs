using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers
{
    /// <summary>
    /// Base class for controls which store a boolean value representing
    /// whether or not the control should be considered selected
    /// </summary>
    /// <typeparam name="TUIControl"></typeparam>
    /// <typeparam name="TNextModel"></typeparam>
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