using System;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf
{
    /// <summary>
    /// Default implementation of a Wpf page model
    /// </summary>
    public abstract class WpfPageModelBase<T> : PageModelBase<T> where T : WpfControl
    {
        protected readonly WpfWindow parent;
        protected WpfPageModelBase(WpfWindow bw)
        {
	        if (null == bw)
	        {
		        throw new ArgumentNullException(nameof(bw));
	        }

			this.parent = bw;
        }

        protected WpfWindow DocumentWindow => this.parent;
    }
}