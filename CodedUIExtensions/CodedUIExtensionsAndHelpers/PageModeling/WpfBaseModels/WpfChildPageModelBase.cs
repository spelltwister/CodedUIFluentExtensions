using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
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
            this._me = me;
        }

        internal protected override T Me
        {
            get { return this._me; }
        }
    }
}