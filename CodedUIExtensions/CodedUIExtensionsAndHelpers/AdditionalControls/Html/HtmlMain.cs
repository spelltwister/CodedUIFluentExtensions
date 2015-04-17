using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlMain : HtmlCustomTag
    {
        public static readonly string MainTag = "main";

        public HtmlMain() : base(MainTag) { }
        public HtmlMain(UITestControl parent) : base(parent, MainTag) { }
    }
}