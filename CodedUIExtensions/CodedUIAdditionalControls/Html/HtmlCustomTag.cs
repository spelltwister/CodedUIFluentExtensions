using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIAdditionalControls.Html
{
    public class HtmlCustomTag : HtmlCustom
    {
        private void Init()
        {
            this.SearchProperties.Add(HtmlControl.PropertyNames.TagName, this._tagName, this._expressionOperator);
        }
        protected readonly PropertyExpressionOperator _expressionOperator;
        protected readonly string _tagName;
        public HtmlCustomTag(string tagName, PropertyExpressionOperator expressionOperator = PropertyExpressionOperator.EqualTo)
            : base()
        {
            this._tagName = tagName;
            this._expressionOperator = expressionOperator;
            Init();
        }

        public HtmlCustomTag(UITestControl parent, string tagName, PropertyExpressionOperator expressionOperator = PropertyExpressionOperator.EqualTo)
            : base(parent)
        {
            this._tagName = tagName;
            this._expressionOperator = expressionOperator;
            Init();
        }
    }
}