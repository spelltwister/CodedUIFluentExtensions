using CaptainPav.Testing.UI.CodedUI.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html.DialogModels;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.IE
{
    public class IE10CertificateErrorPageModel<TConfirmModel> : HtmlConfirmDenyPageModelBase<HtmlTable, HtmlHyperlink, HtmlHyperlink, TConfirmModel, HtmlDocumentPageModelBase>
        where TConfirmModel : IPageModel
    {
        public IE10CertificateErrorPageModel(BrowserWindow bw, TConfirmModel confirmModel) : base(bw, confirmModel, new HtmlBrowserPageModel(bw))
        {
        }

        protected override HtmlHyperlink ConfirmElement => this.Me.Find<HtmlHeading4>("closeWebpage")
                                                                  .Find<HtmlHyperlink>();

        protected override HtmlHyperlink DenyElement => this.Me.Find<HtmlHyperlink>("overridelink");

        internal protected override HtmlTable Me => new HtmlTable(this.DocumentWindow);

        public override string Message
        {
            get { throw new System.NotImplementedException(); } // TODO: implement
        }
    }
}