using System;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class HtmlTextAreaControlPageModelWrapper<TValue, TNextModel> : TextControlPageModelWrapperBase<HtmlTextArea, TValue, TNextModel>
        where TNextModel : IPageModel
    {
        public HtmlTextAreaControlPageModelWrapper(HtmlTextArea toWrap, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc)
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