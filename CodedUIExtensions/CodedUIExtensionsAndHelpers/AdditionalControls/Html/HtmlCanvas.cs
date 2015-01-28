using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlCanvas : HtmlCustomTag
    {
        public static readonly string CanvasTag = "canvas";

        public HtmlCanvas() : base(CanvasTag) { }
        public HtmlCanvas(UITestControl parent) : base(parent, CanvasTag) { }
    }
}