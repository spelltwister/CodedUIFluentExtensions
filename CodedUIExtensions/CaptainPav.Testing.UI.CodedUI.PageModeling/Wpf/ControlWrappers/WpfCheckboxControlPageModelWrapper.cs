using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf.ControlWrappers
{
    public class WpfCheckboxControlPageModelWrapper<TNextModel> : SelectableControlPageModelWrapper<WpfCheckBox, TNextModel>
        where TNextModel : IPageModel
    {
        public WpfCheckboxControlPageModelWrapper(WpfCheckBox toWrap, TNextModel nextModel) : base (toWrap, nextModel) { }

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