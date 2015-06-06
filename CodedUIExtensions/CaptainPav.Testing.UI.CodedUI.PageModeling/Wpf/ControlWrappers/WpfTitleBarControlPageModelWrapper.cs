using System;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf.ControlWrappers
{
    public class WpfTitleBarControlPageModelWrapper : TextValuedControlPageModelWrapper<WpfTitleBar, string>, ITextValuedPageModel<string>
    {
        public WpfTitleBarControlPageModelWrapper(WpfTitleBar control, Func<string, string> stringToValueFunc, Func<WpfTitleBar, string> controlToStringFunc)
            : base(control, stringToValueFunc, controlToStringFunc)
        {
        }

        public WpfTitleBarControlPageModelWrapper(WpfTitleBar control, Func<string, string> stringToValueFunc)
            : base(control, stringToValueFunc, x => x.DisplayText)
        {
        }
    }
}