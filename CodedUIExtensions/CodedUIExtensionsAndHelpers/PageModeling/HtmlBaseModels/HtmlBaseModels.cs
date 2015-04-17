using System;
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
            if (null == me)
            {
                throw new ArgumentNullException("me");
            }
            this._me = me;
        }

        protected override T Me
        {
            get { return this._me; }
        }
    }
}