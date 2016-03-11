using System;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
	// TODO: consider : HtmlEdit
	public class HtmlNumberInput : HtmlCustomInput
	{
		public HtmlNumberInput() : this(null) { }
		public HtmlNumberInput(UITestControl parent) : base(parent, "number", PropertyExpressionOperator.EqualTo)
		{
			this.SearchProperties.Remove(UITestControl.PropertyNames.ControlType);
		}

		protected double? GetPropertyInternal(string propertyName)
		{
			string valueText = this.GetPropertyOrDefault(propertyName, null);
			return ParsePropertyInternal(valueText);
		}

		protected double? ParsePropertyInternal(string valueText)
		{
			if (String.IsNullOrWhiteSpace(valueText))
			{
				return null;
			}
			return double.Parse(valueText);
		}

		public double? Value => ParsePropertyInternal(this.ValueAttribute);
		public double? Min => GetPropertyInternal("min");
		public double? Max => GetPropertyInternal("max");
		public double Step => GetPropertyInternal("step") ?? 1;
	}
}