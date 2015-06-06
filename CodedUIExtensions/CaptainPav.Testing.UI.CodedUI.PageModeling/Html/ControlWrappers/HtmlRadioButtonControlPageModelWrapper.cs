using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers
{
    public class HtmlRadioButtonControlPageModelWrapper<TValue, TNextModel> : ClickableControlPageModelWrapper<HtmlRadioButton, TNextModel>, IValuedPageModel<bool>
        where TNextModel : IPageModel
    {
        public HtmlRadioButtonControlPageModelWrapper(HtmlRadioButton radioButton, TNextModel nextModel) : base(radioButton, nextModel)
        {
        }
        
        public bool Value
        {
            get { return this.Me.Selected; }
        }
    }
}