using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace CaptainPav.Testing.UI.CodedUI.Win
{
    public static class FluentWinSearchExtensions
    {
        public static T Find<T>(this WinControl control, string idValue) where T : WinControl, new()
        {
            return control.Find<T>(WinControl.PropertyNames.ControlId, idValue, PropertyExpressionOperator.EqualTo);
        }
    }
}