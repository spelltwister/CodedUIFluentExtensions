using Microsoft.VisualStudio.TestTools.UITesting;

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
                return new HtmlFigureCaption(this).InnerText;
            }
        }

        protected class HtmlFigureCaption : HtmlCustomTag
        {
            public static readonly string FigureCaptionTag = "figcaption";

            public HtmlFigureCaption(HtmlFigure parent) : base(parent, FigureCaptionTag) { }
        }
    }
}