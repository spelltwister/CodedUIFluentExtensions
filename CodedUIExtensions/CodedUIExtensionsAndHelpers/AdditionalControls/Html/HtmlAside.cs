using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlAside : HtmlCustomTag
    {
        public static readonly string AsideTag = "aside";

        public HtmlAside() : base(AsideTag) { }
        public HtmlAside(UITestControl parent) : base(parent, AsideTag) { }
    }
}