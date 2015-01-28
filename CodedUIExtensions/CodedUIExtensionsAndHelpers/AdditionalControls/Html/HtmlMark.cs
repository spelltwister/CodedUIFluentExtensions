using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlMark : HtmlCustomTag
    {
        public static readonly string MarkTag = "mark";

        public HtmlMark() : base(MarkTag) { }
        public HtmlMark(UITestControl parent) : base(parent, MarkTag) { }
    }
}