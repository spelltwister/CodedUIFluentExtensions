using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlSection : HtmlCustomTag
    {
        public static readonly string SectionTag = "section";

        public HtmlSection() : base(SectionTag) { }
        public HtmlSection(UITestControl parent) : base(parent, SectionTag) { }
    }
}