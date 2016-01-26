using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html
{
    /// <summary>
    /// Helper implementation for a child page model which has its Me property
    /// set via constructor dependency injection
    /// </summary>
    /// <typeparam name="T">
    /// Type of element that represents this child page model
    /// </typeparam>
    /// <remarks>
    /// This type of child model represents models which cannot find themselves
    /// in a page.  Instead, the parent dictates the children.  This is common
    /// in repeaters where each child is indistinguishable from the others.
    /// </remarks>
    public abstract class HtmlChildPageModelBase<T> : HtmlPageModelBase<T> where T : HtmlControl
    {
        protected readonly T _me;
        protected HtmlChildPageModelBase(BrowserWindow bw, T me) : base(bw)
        {
            this._me = me;
        }

        internal protected override T Me
        {
            get { return this._me; }
        }
    }
}