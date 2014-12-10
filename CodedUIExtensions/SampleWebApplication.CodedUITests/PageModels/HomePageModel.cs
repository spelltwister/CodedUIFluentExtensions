using CodedUIExtensionsAndHelpers.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace SampleWebApplication.CodedUITests.PageModels
{
    public class HomePageModel : HtmlPageModelBase<HtmlDiv>
    {
        public HomePageModel(BrowserWindow bw) : base(bw) { }
        protected override HtmlDiv Me
        {
            get
            {
                HtmlDiv ret = new HtmlDiv(this.DocumentWindow);
                ret.SearchProperties.Add(HtmlControl.PropertyNames.Class, "body-content", PropertyExpressionOperator.Contains);
                return ret;
            }
        }
    }
}