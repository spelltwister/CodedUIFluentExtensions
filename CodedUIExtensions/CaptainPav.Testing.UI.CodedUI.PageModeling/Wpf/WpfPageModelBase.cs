using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf
{
    /// <summary>
    /// Default implementation of a Wpf page model
    /// </summary>
    public abstract class WpfPageModelBase<T> : PageModelBase<T> where T : WpfControl
    {
        protected readonly WpfWindow parent;
        protected WpfPageModelBase(WpfWindow window)
        {
            parent = window;
        }

        protected WpfWindow DocumentWindow
        {
            get { return this.parent; }
        }
    }
}