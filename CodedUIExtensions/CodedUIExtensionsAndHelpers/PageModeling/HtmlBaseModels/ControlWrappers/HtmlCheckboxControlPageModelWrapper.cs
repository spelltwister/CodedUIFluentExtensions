using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class HtmlCheckboxControlPageModelWrapper<TNextModel> : SelectableControlPageModelWrapper<HtmlCheckBox, TNextModel>
        where TNextModel : IPageModel
    {
        public HtmlCheckboxControlPageModelWrapper(HtmlCheckBox toWrap, TNextModel nextModel)
            : base(toWrap, nextModel)
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
}