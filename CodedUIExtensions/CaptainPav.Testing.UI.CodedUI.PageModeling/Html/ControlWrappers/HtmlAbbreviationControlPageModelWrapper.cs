using CaptainPav.Testing.UI.CodedUI.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers
{
    public class HtmlAbbreviationControlPageModelWrapper : UIControlPageModelWrapper<HtmlAbbreviation>, ITextValuedPageModel<string>
    {
        public HtmlAbbreviationControlPageModelWrapper(HtmlAbbreviation aside) : base(aside)
        {
        }

        public string Value { get { return this.Me.TitleAttributeValue; } }
        
        public string ValueText
        {
            get { return this.Me.InnerText; }
        }
    }
}