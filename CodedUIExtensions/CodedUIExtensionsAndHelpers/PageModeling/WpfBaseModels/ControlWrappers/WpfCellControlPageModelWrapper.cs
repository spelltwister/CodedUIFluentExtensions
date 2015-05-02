using System;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class WpfCellControlPageModelWrapper<TValue> : TextValuedControlPageModelWrapper<WpfCell, TValue>   
    {
        public WpfCellControlPageModelWrapper(WpfCell control, Func<string, TValue> stringToValueFunc, Func<WpfCell, string> valueToStringFunc) : base(control, stringToValueFunc, valueToStringFunc)
        {
        }

        public WpfCellControlPageModelWrapper(WpfCell control, Func<string, TValue> stringToValueFunc):this(control, stringToValueFunc, x => x.Value)
        {
        }
    }
}