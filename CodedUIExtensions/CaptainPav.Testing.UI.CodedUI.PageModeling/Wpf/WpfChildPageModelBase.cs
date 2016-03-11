using System;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf
{
    /// <summary>
    /// Helper implementation for a child page model which has its Me property
    /// set via constructor dependency injection
    /// </summary>
    /// <typeparam name="T">
    /// Type of element that represents this child page model
    /// </typeparam>
    public abstract class WpfChildPageModelBase<T> : WpfPageModelBase<T> where T : WpfControl
    {
        protected readonly T _me;
        protected WpfChildPageModelBase(WpfWindow bw, T me) : base(bw)
        {
	        if (null == me)
	        {
		        throw new ArgumentNullException(nameof(me));
	        }

            this._me = me;
        }

        internal protected override T Me => this._me;
    }
}