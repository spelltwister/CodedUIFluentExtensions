using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf
{
    /// <summary>
    /// Default implementation of a Wpf page model which represents
    /// the entire Wpf window
    /// </summary>
    public abstract class WpfDocumentPageModelBase : WpfPageModelBase<WpfWindow>
    {
        protected WpfDocumentPageModelBase(WpfWindow bw) : base(bw) { }

        internal protected override WpfWindow Me
        {
            get { return this.DocumentWindow; }
        }
    }
}