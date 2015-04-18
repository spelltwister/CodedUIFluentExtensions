using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class WpfCheckboxControlPageModelWrapper<TNextModel> : SelectableControlPageModelWrapper<WpfCheckBox, TNextModel>
        where TNextModel : IPageModel
    {
        public WpfCheckboxControlPageModelWrapper(WpfCheckBox toWrap, TNextModel nextModel) : base (toWrap, nextModel)
        {
        }

        public override bool IsSelected
        {
            get { return this._control.Checked; }
        }

        public override TNextModel SetSelected(bool selectionState)
        {
            if (selectionState != this.IsSelected)
            {
                this._control.Checked = selectionState;
            }
            return NextModel;
        }
    }

    public class WpfRadioButtonControlPageModelWrapper<TNextModel> : SelectableControlPageModelWrapper<WpfRadioButton, TNextModel>
        where TNextModel : IPageModel
    {
        public WpfRadioButtonControlPageModelWrapper(WpfRadioButton toWrap, TNextModel nextModel) : base(toWrap, nextModel)
        {
        }

        public override bool IsSelected
        {
            get { return this._control.Selected; }
        }

        public override TNextModel SetSelected(bool selectionState)
        {
            if (selectionState != this.IsSelected)
            {
                this._control.Selected = selectionState;
            }
            return NextModel;
        }
    }
}