using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlFooter : HtmlCustomTag
    {
        public static readonly string FooterTag = "footer";

        public HtmlFooter() : base(FooterTag) { }
        public HtmlFooter(UITestControl parent) : base(parent, FooterTag) { }
    }
}