using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using CodedUIExtensionsAndHelpers.Fluent;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlFigure : HtmlCustomTag
    {
        public static readonly string FigureTag = "figure";

        public HtmlFigure() : base(FigureTag) { }
        public HtmlFigure(UITestControl parent) : base(parent, FigureTag) { }

        public string Caption
        {
            get
            {
                return this.Find<HtmlFigureCaption>().InnerText;
            }
        }

        protected class HtmlFigureCaption : HtmlCustomTag
        {
            public static readonly string FigureCaptionTag = "figcaption";

            public HtmlFigureCaption(HtmlFigure parent) : base(parent, FigureCaptionTag) { }
        }
    }
}