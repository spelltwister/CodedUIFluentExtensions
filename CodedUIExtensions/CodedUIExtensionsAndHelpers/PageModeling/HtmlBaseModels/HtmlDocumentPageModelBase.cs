using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Default implementation of an HTML page model which represents
    /// the entire HTML document
    /// </summary>
    public abstract class HtmlDocumentPageModelBase : HtmlPageModelBase<HtmlDocument>
    {
        protected HtmlDocumentPageModelBase(BrowserWindow bw) : base(bw) { }

        internal protected override HtmlDocument Me
        {
            get { return this.DocumentWindow; }
        }
    }
}