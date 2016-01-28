using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html.AdditionalControls
{
    public class HtmlParagraph : HtmlCustomTag
    {
        public static readonly string ParagraphTag = "p";

        public HtmlParagraph() : base(ParagraphTag) { }

        public HtmlParagraph(UITestControl parent) : base(parent, ParagraphTag) { }
    }
}
