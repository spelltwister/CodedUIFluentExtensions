using CaptainPav.Testing.UI.CodedUI;
using CaptainPav.Testing.UI.CodedUI.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Lib.Tests.DecomposingPageObjects.AccountRequired
{
    public interface ILayoutPageModel : IPageModel
    {
        INavPageModel Nav { get; }
    }

    public class LayoutPageModelBase : HtmlPageModelBase<HtmlDiv>, ILayoutPageModel
    {
        public LayoutPageModelBase(BrowserWindow bw) : base(bw)
        {
        }

        protected HtmlDiv LayoutBodyDiv => this.parent.Find<HtmlDiv>("layoutBodyContainer");

        protected override HtmlDiv Me => this.LayoutBodyDiv;

        public INavPageModel Nav => new NavPageModel(this.parent, this.LayoutBodyDiv.Find<HtmlNavigation>());
    }
}