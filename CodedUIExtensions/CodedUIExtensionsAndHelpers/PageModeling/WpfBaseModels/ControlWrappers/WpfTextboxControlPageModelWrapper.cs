using System;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class WpfTextboxControlPageModelWrapper<TValue, TNextModel> : TextValuableControlPageModelWrapperBase<WpfEdit, TValue, TNextModel>
        where TNextModel : IPageModel
    {
        public WpfTextboxControlPageModelWrapper(WpfEdit toWrap, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc)
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