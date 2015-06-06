using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    public class HtmlCanvas : HtmlCustomTag
    {
        public static readonly string CanvasTag = "canvas";

        public HtmlCanvas() : base(CanvasTag) { }
        public HtmlCanvas(UITestControl parent) : base(parent, CanvasTag) { }
    }
}