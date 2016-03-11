using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers
{
    public class HtmlSliderControlPageModelWrapper : UIControlPageModelWrapper<HtmlSlider>, ITextValuedPageModel<double> // TODO: determine if this is settable
    {
        public HtmlSliderControlPageModelWrapper(HtmlSlider slider) : base(slider) { }

        public double Value => this.Me.ValueAsNumber;

	    public string ValueText => this.Me.Value;
    }
}