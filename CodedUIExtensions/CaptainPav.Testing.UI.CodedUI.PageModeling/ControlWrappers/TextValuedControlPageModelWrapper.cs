using System;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers
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

        public string ValueText => this.ControlToStringFunc(this.Me);
    }
}