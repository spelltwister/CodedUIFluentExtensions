using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    public class HtmlSection : HtmlCustomTag
    {
        public static readonly string SectionTag = "section";

        public HtmlSection() : base(SectionTag) { }
        public HtmlSection(UITestControl parent) : base(parent, SectionTag) { }
    }
}