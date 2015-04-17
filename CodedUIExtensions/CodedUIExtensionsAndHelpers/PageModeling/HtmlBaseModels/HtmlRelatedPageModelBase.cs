using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public abstract class HtmlRelatedPageModelBase<T, TParent> : HtmlPageModelBase<T> where T : HtmlControl where TParent : UITestControl
    {
        protected readonly TParent _parent;

        protected HtmlRelatedPageModelBase(BrowserWindow bw, TParent parent) : base(bw)
        {
            if (null == parent)
            {
                throw new ArgumentNullException("parent");
            }
            this._parent = parent;
        }
    }
}