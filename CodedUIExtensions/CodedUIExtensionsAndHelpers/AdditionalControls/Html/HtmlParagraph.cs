using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlParagraph : HtmlCustomTag
    {
        public static readonly string ParagraphTag = "p";

        public HtmlParagraph() : base(ParagraphTag) { }
        public HtmlParagraph(UITestControl parent) : base(parent, ParagraphTag) { }
    }
}