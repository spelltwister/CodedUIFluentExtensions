using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html
{
    /// <summary>
    /// Default implementation of an HTML page model which represents
    /// the entire HTML document
    /// </summary>
    public class HtmlBrowserPageModel : HtmlDocumentPageModelBase
    {
        public HtmlBrowserPageModel(BrowserWindow bw) : base(bw) { }
    }
}