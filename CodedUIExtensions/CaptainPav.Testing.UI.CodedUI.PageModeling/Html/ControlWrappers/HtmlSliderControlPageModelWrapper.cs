using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers
{
    public class HtmlSliderControlPageModelWrapper : UIControlPageModelWrapper<HtmlSlider>, ITextValuedPageModel<double> // TODO: determine if this is settable
    {
        public HtmlSliderControlPageModelWrapper(HtmlSlider cell)
            : base(cell)
        {
        }

        public double Value
        {
            get { return this.Me.ValueAsNumber; }
        }

        public string ValueText
        {
            get { return this.Me.Value; }
        }
    }
}