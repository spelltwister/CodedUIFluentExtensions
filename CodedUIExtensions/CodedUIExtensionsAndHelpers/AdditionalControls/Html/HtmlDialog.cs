using Microsoft.VisualStudio.TestTools.UITesting;

using CodedUIExtensionsAndHelpers.Fluent;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlDialog : HtmlCustomTag
    {
        public static readonly string DialogTag = "dialog";

        public HtmlDialog() : base(DialogTag) { }
        public HtmlDialog(UITestControl parent) : base(parent, DialogTag) { }

        public bool IsOpen
        {
            get
            {
                return this.HasProperty("open");
            }
        }
    }
}