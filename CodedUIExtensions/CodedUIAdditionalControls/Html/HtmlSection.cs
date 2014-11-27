using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIAdditionalControls.Html
{
    public class HtmlSection : HtmlCustomTag
    {
        public static readonly string SectionTag = "section";

        public HtmlSection() : base(SectionTag) { }
        public HtmlSection(UITestControl parent) : base(parent, SectionTag) { }
    }
}
