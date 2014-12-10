using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlForm : HtmlCustomTag
    {
        public static readonly string FormTag = "form";

        public HtmlForm() : base(FormTag) { }
        public HtmlForm(UITestControl parent) : base(parent, FormTag) { }

        public string Method { get { throw new System.NotImplementedException(); } }
        public string Action { get { throw new System.NotImplementedException(); } }
    }
}