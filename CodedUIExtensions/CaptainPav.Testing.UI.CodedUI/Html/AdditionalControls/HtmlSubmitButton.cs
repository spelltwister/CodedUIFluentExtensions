using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    public class HtmlSubmitButton : HtmlInputButton
    {
        protected const string SubmitType = "submit";

        public HtmlSubmitButton() : this(null)
        {
            this.SearchProperties.Add(HtmlControl.PropertyNames.Type, SubmitType, PropertyExpressionOperator.EqualTo);
        }

        public HtmlSubmitButton(UITestControl parent) : base(parent)
        {
            this.SearchProperties.Add(HtmlControl.PropertyNames.Type, SubmitType, PropertyExpressionOperator.EqualTo);
        }
    }
}