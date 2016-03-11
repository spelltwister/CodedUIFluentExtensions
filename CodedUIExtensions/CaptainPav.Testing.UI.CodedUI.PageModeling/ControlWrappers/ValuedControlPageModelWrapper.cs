using System;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers
{
    public class ValuedControlPageModelWrapper<TUIType, TValue> : UIControlPageModelWrapper<TUIType>, IValuedPageModel<TValue>
        where TUIType : UITestControl
    {
        protected readonly Func<TUIType, TValue> ControlToValueFunc;

        public ValuedControlPageModelWrapper(TUIType control, Func<TUIType, TValue> controlToValueFunc) : base(control)
        {
            this.ControlToValueFunc = controlToValueFunc;
        }

        public TValue Value => this.ControlToValueFunc(this._control);
    }
}