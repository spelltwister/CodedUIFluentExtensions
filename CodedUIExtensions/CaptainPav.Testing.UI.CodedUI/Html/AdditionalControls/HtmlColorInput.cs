using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
	public class HtmlColorInput : HtmlCustomInput
	{
		public HtmlColorInput() : this(null) { }
		public HtmlColorInput(UITestControl parent) : base(parent, "color", PropertyExpressionOperator.EqualTo) { }
	}
}