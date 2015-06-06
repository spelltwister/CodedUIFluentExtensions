using System;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf.ControlWrappers
{
    public class WpfTextControlPageModelWrapper<TValue> : TextValuedControlPageModelWrapper<WpfText, TValue>
    {
        public WpfTextControlPageModelWrapper(WpfText control, Func<string, TValue> stringToValueFunc, Func<WpfText, string> controlToStringFunc)
            : base(control, stringToValueFunc, controlToStringFunc)
        {
        }

        public WpfTextControlPageModelWrapper(WpfText control, Func<string, TValue> stringToValueFunc)
            : this(control, stringToValueFunc, x => x.DisplayText)
        {
        }
    }
}