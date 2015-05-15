using System;
using CodedUIExtensionsAndHelpers.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;

public class ValuedControlPageModelWrapper<TUIType, TValue> : UIControlPageModelWrapper<TUIType>, IValuedPageModel<TValue>
    where TUIType : UITestControl
{
    protected readonly Func<TUIType, TValue> ControlToValueFunc;

    public ValuedControlPageModelWrapper(TUIType control, Func<TUIType, TValue> controlToValueFunc) : base(control)
    {
        this.ControlToValueFunc = controlToValueFunc;
    }

    public TValue Value
    {
        get { return this.ControlToValueFunc(this._control); }
    }
}