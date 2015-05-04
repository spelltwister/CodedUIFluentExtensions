using CodedUIExtensionsAndHelpers.AdditionalControls.Html;

namespace CodedUIExtensionsAndHelpers.PageModeling
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