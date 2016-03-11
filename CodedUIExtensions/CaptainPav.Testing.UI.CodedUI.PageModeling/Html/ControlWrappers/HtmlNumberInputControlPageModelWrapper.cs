using System;
using System.Globalization;
using CaptainPav.Testing.UI.CodedUI.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers
{
	public class HtmlNumberInputControlPageModelWrapper<TNextModel> : HasNextModelUIControlPageModelWrapperBase<HtmlNumberInput, TNextModel>, IReadWriteTextValuePageModel<double?, TNextModel> where TNextModel : IPageModel
	{
		protected readonly NumberStyles NumberInputTypes = NumberStyles.AllowDecimalPoint | 
		                                                   NumberStyles.AllowLeadingSign  |
		                                                   NumberStyles.AllowLeadingWhite |
		                                                   NumberStyles.AllowThousands    |
		                                                   NumberStyles.AllowTrailingWhite;

		public HtmlNumberInputControlPageModelWrapper(HtmlNumberInput toWrap, TNextModel nextModel) : base(toWrap, nextModel) { }

		public double? Value => this._control.Value;
		public string ValueText => this._control.ValueAttribute;

		public TNextModel SetValue(double? toValue)
		{
			if (!toValue.HasValue)
			{
				return this.SetValueText(String.Empty);
			}
			return this.SetValueText(toValue.Value.ToString("G"));
		}

		public TNextModel SetValueText(string valueText)
		{
			HtmlEdit adapter = new HtmlEdit();
			adapter.CopyFrom(this._control);
			adapter.Text = valueText;
			return NextModel;
		}
	}
}