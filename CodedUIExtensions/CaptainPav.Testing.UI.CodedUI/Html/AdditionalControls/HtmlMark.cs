using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    public class HtmlMark : HtmlCustomTag
    {
        public static readonly string MarkTag = "mark";

        public HtmlMark() : base(MarkTag) { }
        public HtmlMark(UITestControl parent) : base(parent, MarkTag) { }
    }
}