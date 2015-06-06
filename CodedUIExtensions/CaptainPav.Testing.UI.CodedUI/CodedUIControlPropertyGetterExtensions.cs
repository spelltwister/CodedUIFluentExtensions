using System;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI
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
    }
}