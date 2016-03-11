using System;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers
{
    public class HtmlEditableSpanControlPageModelWrapper<TValue, TNextModel> : TextValuableControlPageModelWrapperBase<HtmlEditableSpan, TValue, TNextModel>
        where TNextModel : IPageModel
    {
        public HtmlEditableSpanControlPageModelWrapper(HtmlEditableSpan toWrap, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc)
            : base(toWrap, nextModel, stringToValueFunc, valueToStringFunc)
        {
        }

        public override string ValueText => Me.Text;

	    public override TNextModel SetValueText(string valueText)
        {
            Me.Text = valueText;
            return this.NextModel;
        }
    }
}