using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.Fluent
{
    public static class CodedUIControlPropertyGetterExtensions
    {
        public static bool TryGetProperty(this UITestControl control, string propertyName, out object propertyValue)
        {
            try
            {
                propertyValue = control.GetProperty(propertyName);
                return true;
            }
            catch
            {
                propertyValue = null;
                return false;
            }
        }

        public static bool TryGetProperty<T>(this UITestControl control, string propertyName, out T propertyValue) where T : class
        {
            return control.TryGetProperty(propertyName, x => x as T, out propertyValue);
        }

        public static bool TryGetProperty<T>(this UITestControl control, string propertyName, Func<object, T> transformFunction, out T propertyValue) where T : class
        {
            object value;
            if (!control.TryGetProperty(propertyName, out value))
            {
                propertyValue = null;
                return false;
            }

            try
            {
                propertyValue = transformFunction(value);
            }
            catch
            {
                propertyValue = null;
            }
            return true;
        }

        public static bool TryGetProperty(this HtmlControl control, string propertyName, out string propertyValue)
        {
            return control.TryGetProperty<string>(propertyName, out propertyValue);
        }

        public static string GetPropertyOrDefault(this HtmlControl control, string propertyName, string defaultValue)
        {
            string value;
            if (!control.TryGetProperty(propertyName, out value))
            {
                return defaultValue;
            }
            return value;
        }

        // TODO: ensure that properties without values return true (eg, &lt;details open&gt;)
        public static bool HasProperty(this HtmlControl control, string propertyName)
        {
            object obj;
            return control.TryGetProperty(propertyName, out obj);
        }
    }
}