using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlHeader : HtmlCustomTag
    {
        public static readonly string HeaderTag = "header";

        public HtmlHeader() : base(HeaderTag) { }
        public HtmlHeader(UITestControl parent) : base(parent, HeaderTag) { }
    }
}