using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlMark : HtmlCustomTag
    {
        public static readonly string MarkTag = "mark";

        public HtmlMark() : base(MarkTag) { }
        public HtmlMark(UITestControl parent) : base(parent, MarkTag) { }
    }
}