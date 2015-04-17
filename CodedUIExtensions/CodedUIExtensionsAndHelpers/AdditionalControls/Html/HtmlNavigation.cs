using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlNavigation : HtmlCustomTag
    {
        public static readonly string NavigationTag = "nav";

        public HtmlNavigation() : base(NavigationTag) { }
        public HtmlNavigation(UITestControl parent) : base(parent, NavigationTag) { }
    }
}