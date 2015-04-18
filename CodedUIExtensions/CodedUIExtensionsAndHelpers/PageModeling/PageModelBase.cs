using System;
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
        internal protected abstract T Me { get; }

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

        public virtual bool CanFind(int? wait = null)
        {
            return this.Me.CanFind(wait);
        }

        public virtual bool CanNotFind(int? wait = null)
        {
            return this.Me.CanNotFind(wait);
        }

        public virtual bool IsActionable(int? wait = null)
        {
            return this.Me.IsActionable(wait);
        }

        public virtual bool IsNotActionable(int? wait = null)
        {
            return this.Me.IsNotActionable(wait);
        }
    }

    internal abstract class ExplicitControlPageModelBase<T> : PageModelBase<T> where T : UITestControl // diamond problem
    {
        protected readonly T _me;
        protected ExplicitControlPageModelBase(T me)
        {
            if (null == me)
            {
                throw new ArgumentNullException("me");
            }
            this._me = me;
        }

        protected internal override T Me
        {
            get { return _me; }
        }
    }
}