using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Default implementation of a page model
    /// </summary>
    /// <typeparam name="T">
    /// Type of control that impelements this model
    /// </typeparam>
    public abstract class PageModelBase<T> : IPageModel where T : UITestControl
    {
        protected abstract T Me { get; }
        public virtual bool IsVisible(int? wait = null)
        {
            return this.Me.IsVisible(wait);
        }

        public virtual bool IsClickable(int? wait = null)
        {
            return this.Me.IsClickable(wait);
        }

        public virtual bool IsHidden(int? wait = null)
        {
            return this.Me.IsHidden(wait);
        }

        public virtual bool IsNotClickable(int? wait = null)
        {
            return this.Me.IsNotClickable(wait);
        }
    }
}