using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers
{
    public class HtmlStringValuedControlPageModelWrapper<T> : UIControlPageModelWrapper<T>, IValuedPageModel<string> where T : HtmlControl
    {
        public HtmlStringValuedControlPageModelWrapper(T control) : base(control)
        {
        }

        public string Value { get { return this.Me.InnerText; } }
    }
}