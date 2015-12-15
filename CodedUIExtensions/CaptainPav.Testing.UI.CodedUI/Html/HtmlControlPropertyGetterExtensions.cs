using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    public static class HtmlControlPropertyGetterExtensions
    {
       public static bool TryGetProperty(this HtmlControl control, string propertyName, out string propertyValue)
        {
            return control.TryGetProperty<string>(propertyName, out propertyValue);
        }

        public static string GetPropertyOrDefault(this HtmlControl control, string propertyName, string defaultValue)
        {
            string ret;
            control.GetPropertyOrDefault(propertyName, defaultValue, out ret);
            return ret;
        }

        // TODO: ensure that properties without values return true (eg, &lt;details open&gt;)
        public static bool HasProperty(this HtmlControl control, string propertyName)
        {
            object obj;
            return control.TryGetProperty(propertyName, out obj);
        }
    }
}