using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

using CodedUIExtensionsAndHelpers.AdditionalControls.Html;
using CodedUIExtensionsAndHelpers.Fluent;

namespace CodedUIExtensionsAndHelpers.PageModeling.HtmlBaseModels.IE
{
    public class IE10CertificateErrorPageModel<TConfirmModel> : HtmlConfirmDenyPageModelBase<HtmlTable, HtmlHyperlink, HtmlHyperlink, TConfirmModel, HtmlDocumentPageModelBase>
        where TConfirmModel : IPageModel
    {
        public IE10CertificateErrorPageModel(BrowserWindow bw, TConfirmModel confirmModel) : base(bw, confirmModel, new HtmlBrowserPageModel(bw))
        {
        }

        protected override HtmlHyperlink ConfirmElement
        {
            get { return this.Me.Find<HtmlHeading4>("closeWebpage").Find<HtmlHyperlink>(); }
        }

        protected override HtmlHyperlink DenyElement
        {
            get { return this.Me.Find<HtmlHyperlink>("overridelink"); }
        }

        protected internal override HtmlTable Me
        {
            get { return new HtmlTable(this.DocumentWindow); }
        }
    }
}