using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
	public class HtmlCustomInput : HtmlCustomTag
	{
		protected readonly PropertyExpressionOperator _inputTypeExpressionOperator;
		protected readonly string _inputType;

		public HtmlCustomInput(string inputType, PropertyExpressionOperator expressionOperator = PropertyExpressionOperator.EqualTo) : this(null, inputType, expressionOperator) { }
		public HtmlCustomInput(UITestControl parent, string inputType, PropertyExpressionOperator expressionOperator = PropertyExpressionOperator.EqualTo) : base(parent, "input")
		{
			this._inputType = inputType;
			this._inputTypeExpressionOperator = expressionOperator;

			this.WithAttribute("type", this._inputType);
		}
	}
}