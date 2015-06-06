using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.Wpf
{
    public static class FluentWpfSearchExtensions
    {
        public static T Find<T>(this WpfControl control, string idValue) where T : WpfControl, new()
        {
            return control.Find<T>(WpfControl.PropertyNames.AutomationId, idValue, PropertyExpressionOperator.EqualTo);
        }
    }
}