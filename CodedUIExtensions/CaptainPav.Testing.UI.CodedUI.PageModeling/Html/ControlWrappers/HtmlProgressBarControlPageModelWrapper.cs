using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers
{
    public class HtmlProgressBarControlPageModelWrapper : UIControlPageModelWrapper<HtmlProgressBar>, IValuedPageModel<float>
    {
        public HtmlProgressBarControlPageModelWrapper(HtmlProgressBar cell) : base(cell) { }

        public float Value => this.Me.Value;
    }
}