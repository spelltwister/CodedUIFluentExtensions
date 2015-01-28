using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlNavigation : HtmlCustomTag
    {
        public static readonly string NavigationTag = "nav";

        public HtmlNavigation() : base(NavigationTag) { }
        public HtmlNavigation(UITestControl parent) : base(parent, NavigationTag) { }
    }
}