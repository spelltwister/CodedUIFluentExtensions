using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlHeader : HtmlCustomTag
    {
        public static readonly string HeaderTag = "header";

        public HtmlHeader() : base(HeaderTag) { }
        public HtmlHeader(UITestControl parent) : base(parent, HeaderTag) { }
    }
}