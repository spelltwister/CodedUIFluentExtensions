using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html
{
    /// <summary>
    /// Default implementation of an HTML page model
    /// </summary>
    public abstract class HtmlPageModelBase<T> : PageModelBase<T> where T : HtmlControl
    {
        protected readonly BrowserWindow parent;
        protected HtmlPageModelBase(BrowserWindow bw)
        {
            if (null == bw)
            {
                throw new ArgumentNullException("bw");
            }
            parent = bw;
        }

        protected HtmlDocument DocumentWindow
        {
            get { return new HtmlDocument(this.parent); }
        }
    }
}