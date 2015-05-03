using System;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public abstract class TextValuableControlPageModelWrapperBase<TUIType, TValue, TNextModel> : HasNextModelUIControlPageModelWrapperBase<TUIType, TNextModel>, ITextValueablePageModel<TValue, TNextModel>
        where TUIType : UITestControl
        where TNextModel : IPageModel
    {
        protected readonly Func<string, TValue> StringToValueFunc;
        protected readonly Func<TValue, string> ValueToStringFunc;

        protected TextValuableControlPageModelWrapperBase(TUIType control, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc) : base(control, nextModel)
        {
            this.StringToValueFunc = stringToValueFunc;
            this.ValueToStringFunc = valueToStringFunc;
        }
        
        public abstract string ValueText { get; }

        public abstract TNextModel SetValueText(string toValue);

        public TNextModel SetValue(TValue toValue)
        {
            return SetValueText(this.ValueToStringFunc(toValue));
        }

        public TValue Value
        {
            get { return this.StringToValueFunc(ValueText); }
        }
    }
}