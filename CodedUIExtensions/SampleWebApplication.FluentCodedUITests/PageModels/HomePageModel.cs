using CodedUIExtensionsAndHelpers.Fluent;
using CodedUIExtensionsAndHelpers.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace SampleWebApplication.FluentCodedUITests.PageModels
{
    public class HomePageModel : HtmlPageModelBase<HtmlDiv>
    {
        public HomePageModel(BrowserWindow bw) : base(bw) { }
        protected override HtmlDiv Me
        {
            get
            {
                return this.DocumentWindow
                           .Find<HtmlDiv>(HtmlControl.PropertyNames.Class, "body-content", PropertyExpressionOperator.Contains);
            }
        }
    }
}