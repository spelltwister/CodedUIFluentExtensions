using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Default implementation of an HTML page model
    /// </summary>
    public abstract class HtmlPageModelBase<T> : PageModelBase<T> where T : HtmlControl
    {
        protected readonly BrowserWindow parent;
        protected HtmlPageModelBase(BrowserWindow bw)
        {
            parent = bw;
        }

        protected HtmlDocument DocumentWindow
        {
            get { return new HtmlDocument(this.parent); }
        }
    }

    /// <summary>
    /// Default implementation of an HTML page model which represents
    /// the entire HTML document
    /// </summary>
    public abstract class HtmlDocumentPageModelBase : HtmlPageModelBase<HtmlDocument>
    {
        protected HtmlDocumentPageModelBase(BrowserWindow bw) : base(bw) { }

        protected override HtmlDocument Me
        {
            get { return this.DocumentWindow; }
        }
    }

    /// <summary>
    /// Helper implementation for a child page model which has its Me property
    /// set via constructor dependency injection
    /// </summary>
    /// <typeparam name="T">
    /// Type of element that represents this child page model
    /// </typeparam>
    public abstract class HtmlChildPageModelBase<T> : HtmlPageModelBase<T> where T : HtmlControl
    {
        protected readonly T _me;
        protected HtmlChildPageModelBase(BrowserWindow bw, T me) : base(bw)
        {
            this._me = me;
        }

        protected override T Me
        {
            get { return this._me; }
        }
    }
}