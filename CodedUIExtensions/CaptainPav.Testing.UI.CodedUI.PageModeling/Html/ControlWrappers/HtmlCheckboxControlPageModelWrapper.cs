using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers
{
    public class HtmlCheckboxControlPageModelWrapper<TNextModel> : SelectableControlPageModelWrapper<HtmlCheckBox, TNextModel>
        where TNextModel : IPageModel
    {
        public HtmlCheckboxControlPageModelWrapper(HtmlCheckBox toWrap, TNextModel nextModel) : base(toWrap, nextModel) { }

        public override bool IsSelected => this.Me.Checked;

        public override TNextModel SetSelected(bool selectionState)
        {
            if (selectionState != this.IsSelected)
            {
                this.Me.Checked = selectionState;
            }

            return this.NextModel;
        }
    }
}