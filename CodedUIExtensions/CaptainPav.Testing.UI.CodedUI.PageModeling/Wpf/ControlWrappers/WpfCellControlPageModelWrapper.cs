using System;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf.ControlWrappers
{
    public class WpfCellControlPageModelWrapper<TValue> : TextValuedControlPageModelWrapper<WpfCell, TValue>   
    {
        public WpfCellControlPageModelWrapper(WpfCell control, Func<string, TValue> stringToValueFunc, Func<WpfCell, string> controlToStringFunc) : base(control, stringToValueFunc, controlToStringFunc)
        {
        }

        public WpfCellControlPageModelWrapper(WpfCell control, Func<string, TValue> stringToValueFunc):this(control, stringToValueFunc, x => x.Value)
        {
        }
    }
}