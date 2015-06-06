using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    public class HtmlAside : HtmlCustomTag
    {
        public static readonly string AsideTag = "aside";

        public HtmlAside() : base(AsideTag) { }
        public HtmlAside(UITestControl parent) : base(parent, AsideTag) { }
    }
}