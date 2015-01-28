using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlArticle : HtmlCustomTag
    {
        public static readonly string ArticleTag = "article";

        public HtmlArticle() : base(ArticleTag) { }
        public HtmlArticle(UITestControl parent) : base(parent, ArticleTag) { }
    }
}