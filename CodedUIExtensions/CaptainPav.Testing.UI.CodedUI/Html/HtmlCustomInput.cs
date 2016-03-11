using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
	public class HtmlCustomInput : HtmlCustomTag
	{
		protected readonly string _inputType;

		public HtmlCustomInput(string inputType) : this(null, inputType) { }
		public HtmlCustomInput(UITestControl parent, string inputType) : base(parent, "input", PropertyExpressionOperator.EqualTo)
		{
			this._inputType = inputType;

			this.WithAttribute("type", this._inputType); // TODO: see if there is a better way to do this
		}
	}
}