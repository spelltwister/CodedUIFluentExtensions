using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.PageModeling
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

        TNextModel IValueablePageModel<bool, TNextModel>.SetValue(bool toValue)
        {
            return SetSelected(toValue);
        }

        bool IValuedPageModel<bool>.Value
        {
            get { return this.IsSelected; }
        }
    }
}