using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Win
{
    public static class FluentWinSearchExtensions
    {
        public static T Find<T>(this UITestControl control, string idValue) where T : WinControl, new()
        {
            return control.Find<T>(WinControl.PropertyNames.ControlId, idValue, PropertyExpressionOperator.EqualTo);
        }
    }
}