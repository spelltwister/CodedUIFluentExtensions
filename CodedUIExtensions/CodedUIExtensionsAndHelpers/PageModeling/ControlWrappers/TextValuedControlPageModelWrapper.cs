using System;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class TextValuedControlPageModelWrapper<TUIType, TValue> : UIControlPageModelWrapper<TUIType>, ITextValuedPageModel<TValue>
        where TUIType : UITestControl
    {
        protected readonly Func<TUIType, string> ValueToStringFunc;
        protected readonly Func<string, TValue> StringToValueFunc;

        public TextValuedControlPageModelWrapper(TUIType control, Func<string, TValue> stringToValueFunc, Func<TUIType, string> valueToStringFunc)
            : base(control)
        {
            this.ValueToStringFunc = valueToStringFunc;
            this.StringToValueFunc = stringToValueFunc;
        }

        public TValue Value
        {
            get { return this.StringToValueFunc(this.ValueText); }
        }

        public string ValueText
        {
            get { return this.ValueToStringFunc(this.Me); }
        }
    }
}