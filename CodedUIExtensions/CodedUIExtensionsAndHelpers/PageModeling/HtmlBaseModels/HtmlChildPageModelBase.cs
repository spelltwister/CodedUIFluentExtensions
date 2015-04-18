using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Helper implementation for a child page model which has its Me property
    /// set via constructor dependency injection, typically because the child
    /// model is dynamically created or cannot find itself for some reason
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

        internal protected override T Me
        {
            get { return this._me; }
        }
    }
}