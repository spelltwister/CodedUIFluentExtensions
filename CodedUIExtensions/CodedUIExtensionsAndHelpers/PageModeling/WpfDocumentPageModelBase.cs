using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Default implementation of a Wpf page model which represents
    /// the entire Wpf window
    /// </summary>
    public abstract class WpfDocumentPageModelBase : WpfPageModelBase<WpfWindow>
    {
        protected WpfDocumentPageModelBase(WpfWindow bw) : base(bw) { }

        protected override WpfWindow Me
        {
            get { return this.DocumentWindow; }
        }
    }
}