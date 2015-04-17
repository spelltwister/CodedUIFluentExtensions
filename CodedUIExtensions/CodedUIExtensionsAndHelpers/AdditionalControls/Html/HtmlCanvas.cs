using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlCanvas : HtmlCustomTag
    {
        public static readonly string CanvasTag = "canvas";

        public HtmlCanvas() : base(CanvasTag) { }
        public HtmlCanvas(UITestControl parent) : base(parent, CanvasTag) { }
    }
}