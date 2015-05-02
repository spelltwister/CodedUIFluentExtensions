using System;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class WpfTextControlPageModelWrapper<TValue> : TextValuedControlPageModelWrapper<WpfText, TValue>
    {
        public WpfTextControlPageModelWrapper(WpfText control, Func<string, TValue> stringToValueFunc, Func<WpfText, string> valueToStringFunc)
            : base(control, stringToValueFunc, valueToStringFunc)
        {
        }

        public WpfTextControlPageModelWrapper(WpfText control, Func<string, TValue> stringToValueFunc)
            : this(control, stringToValueFunc, x => x.DisplayText)
        {
        }
    }
}