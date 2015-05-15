using System;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class TextValuedControlPageModelWrapper<TUIType, TValue> : ValuedControlPageModelWrapper<TUIType, TValue>, ITextValuedPageModel<TValue>
        where TUIType : UITestControl
    {
        protected readonly Func<TUIType, string> ControlToStringFunc;

        public TextValuedControlPageModelWrapper(TUIType control, Func<string, TValue> stringToValueFunc, Func<TUIType, string> controlToStringFunc)
            : base(control, x => stringToValueFunc(controlToStringFunc(x)))
        {
            this.ControlToStringFunc = controlToStringFunc;
        }

        public string ValueText
        {
            get { return this.ControlToStringFunc(this.Me); }
        }
    }
}