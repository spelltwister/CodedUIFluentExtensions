using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    public class HtmlDialog : HtmlCustomTag
    {
        public static readonly string DialogTag = "dialog";

        public HtmlDialog() : base(DialogTag) { }
        public HtmlDialog(UITestControl parent) : base(parent, DialogTag) { }

        public bool IsOpen => this.HasProperty("open");
    }
}