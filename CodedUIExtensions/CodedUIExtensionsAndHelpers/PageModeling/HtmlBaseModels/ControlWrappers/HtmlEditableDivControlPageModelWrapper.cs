using System;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class HtmlEditableDivControlPageModelWrapper<TValue, TNextModel> : TextValuableControlPageModelWrapperBase<HtmlEditableDiv, TValue, TNextModel>
        where TNextModel : IPageModel
    {
        public HtmlEditableDivControlPageModelWrapper(HtmlEditableDiv toWrap, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc)
            : base(toWrap, nextModel, stringToValueFunc, valueToStringFunc)
        {
        }

        public override string ValueText
        {
            get { return Me.InnerText; }
        }

        public override TNextModel SetValueText(string valueText)
        {
            Me.Text = valueText;
            return this.NextModel;
        }
    }
}