using System;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI
{
    /// <summary>
    /// Set of extensions to help get property values from UI controls
    /// </summary>
    public static class CodedUIControlPropertyGetterExtensions
    {
        /// <summary>
        /// Tries to get the value of the specified property
        /// </summary>
        /// <param name="control">
        /// The controls containing the property whose value should be fetched
        /// </param>
        /// <param name="propertyName">
        /// The name of the property whose value should be fetched
        /// </param>
        /// <param name="propertyValue">
        /// When this method returns, contains the value of the property or
        /// null if the property's value could not be fetched
        /// </param>
        /// <returns>
        /// True if the property's value was able to be fetched;
        /// otherwise, false
        /// </returns>
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

        /// <summary>
        /// Tries to get the value of the specified proprty as its native type
        /// </summary>
        /// <typeparam name="T">
        /// The native type of the property's value to return
        /// </typeparam>
        /// <param name="control">
        /// The controls containing the property whose value should be fetched
        /// </param>
        /// <param name="propertyName">
        /// The name of the property whose value should be fetched
        /// </param>
        /// <param name="propertyValue">
        /// When this method returns, contains the value of the property or
        /// null if the property's value could not be fetched
        /// </param>
        /// <returns>
        /// True if the property's value was able to be fetched;
        /// otherwise, false
        /// </returns>
        public static bool TryGetProperty<T>(this UITestControl control, string propertyName, out T propertyValue) where T : class
        {
            return control.TryGetProperty(propertyName, x => x as T, out propertyValue);
        }

        /// <summary>
        /// Tries to get the value of the specified proprty as its native type
        /// by converting the property's value object using the specified
        /// transformation function
        /// </summary>
        /// <typeparam name="T">
        /// The native type of the property's value to return
        /// </typeparam>
        /// <param name="control">
        /// The controls containing the property whose value should be fetched
        /// </param>
        /// <param name="propertyName">
        /// The name of the property whose value should be fetched
        /// </param>
        /// <param name="transformFunction">
        /// The function that can be used to transform the property's value
        /// object into its native type
        /// </param>
        /// <param name="propertyValue">
        /// When this method returns, contains the value of the property or
        /// default if the property's value could not be fetched
        /// </param>
        /// <returns>
        /// True if the property's value was able to be fetched and transformed;
        /// otherwise, false
        /// </returns>
        public static bool TryGetProperty<T>(this UITestControl control, string propertyName, Func<object, T> transformFunction, out T propertyValue)
        {
            object value;
            if (!control.TryGetProperty(propertyName, out value))
            {
                propertyValue = default(T);
                return false;
            }

            try
            {
                propertyValue = transformFunction(value);
            }
            catch
            {
                propertyValue = default(T);
	            return false;
            }
            return true;
        }

        public static bool GetPropertyOrDefault(this UITestControl control, string propertyName, object defaultValue, out object propertyValue)
        {
            if (!control.TryGetProperty(propertyName, out propertyValue))
            {
                propertyValue = defaultValue;
                return false;
            }
            return true;
        }

        public static bool GetPropertyOrDefault<T>(this UITestControl control, string propertyName, T defaultValue, out T propertyValue) where T : class
        {
            if (!control.TryGetProperty(propertyName, out propertyValue))
            {
                propertyValue = defaultValue;
                return false;
            }
            return true;
        }

        public static bool GetPropertyOrDefault<T>(this UITestControl control, string propertyName, Func<object, T> transformFunction, T defaultValue, out T propertyValue)
        {
            if (!control.TryGetProperty(propertyName, transformFunction, out propertyValue))
            {
                propertyValue = defaultValue;
                return false;
            }
            return true;
        }
    }
}