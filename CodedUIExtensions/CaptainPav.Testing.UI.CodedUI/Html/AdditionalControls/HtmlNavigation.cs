using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    public class HtmlNavigation : HtmlCustomTag
    {
        public static readonly string NavigationTag = "nav";

        public HtmlNavigation() : base(NavigationTag) { }
        public HtmlNavigation(UITestControl parent) : base(parent, NavigationTag) { }
    }
}