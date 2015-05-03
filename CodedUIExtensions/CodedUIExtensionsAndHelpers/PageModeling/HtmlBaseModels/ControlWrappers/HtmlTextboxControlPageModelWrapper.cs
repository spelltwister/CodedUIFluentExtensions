using System;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class HtmlTextboxControlPageModelWrapper<TValue, TNextModel> : TextValuableControlPageModelWrapperBase<HtmlEdit, TValue, TNextModel>
        where TNextModel : IPageModel
    {
        public HtmlTextboxControlPageModelWrapper(HtmlEdit toWrap, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc)
            : base(toWrap, nextModel, stringToValueFunc, valueToStringFunc)
        {
        }

        public override string ValueText
        {
            get { return Me.Text; }
        }

        public override TNextModel SetValueText(string valueText)
        {
            Me.Text = valueText;
            return this.NextModel;
        }
    }
}