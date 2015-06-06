using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    public class HtmlArticle : HtmlCustomTag
    {
        public static readonly string ArticleTag = "article";

        public HtmlArticle() : base(ArticleTag) { }
        public HtmlArticle(UITestControl parent) : base(parent, ArticleTag) { }
    }
}