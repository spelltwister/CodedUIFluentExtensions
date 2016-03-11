using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
	public class HtmlPasswordInput : HtmlEdit
	{
		public HtmlPasswordInput() : this(null) { }
		public HtmlPasswordInput(UITestControl parent) : base(parent)
		{
			this.SearchProperties.Add(HtmlControl.PropertyNames.Type, "password", PropertyExpressionOperator.EqualTo);
		}
	}
}