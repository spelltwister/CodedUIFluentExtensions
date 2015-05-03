using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.Fluent
{
    public static class FluentHtmlSearchExtensions
    {
        /// <summary>
        /// Extends the search properties of the current HtmlControl with a
        /// search for a specified attribute-value pair
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The HtmlControl to extend
        /// </param>
        /// <param name="attributeName">
        /// The name of the attribute whose value should be tested
        /// </param>
        /// <param name="attributeValue">
        /// The value against which to test the specified attribute
        /// </param>
        /// <returns>
        /// The HtmlControl with the additional search property
        /// </returns>
        public static T WithAttribute<T>(this T current, string attributeName, string attributeValue) where T : HtmlControl
        {
            current.SearchProperties.Add(HtmlControl.PropertyNames.ControlDefinition, String.Format("{0}=\"{1}\"", attributeName, attributeValue), PropertyExpressionOperator.Contains);
            return current;
        }

        /// <summary>
        /// Extends the search properties of the current HtmlControl with
        /// search definitions for the specified attribute-value pairs
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The HtmlControl to extend
        /// </param>
        /// <param name="attributes">
        /// The collection of attribute-value pairs to add as search properties
        /// </param>
        /// <returns>
        /// The HtmlControl with the additional search properties
        /// </returns>
        public static T WithAttributes<T>(this T current, IDictionary<string, string> attributes) where T : HtmlControl
        {
            foreach (var kvp in attributes)
            {
                current.WithAttribute(kvp.Key, kvp.Value);
            }
            return current;
        }

        /// <summary>
        /// Extends the search properties of the current HtmlControl with
        /// a search definition that can find elements with a specific data-
        /// attribute key-value pair
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The HtmlControl to extend
        /// </param>
        /// <param name="dataAttributeName">
        /// The data- attribute name (section following the 'data-')
        /// </param>
        /// <param name="dataAttributeValue">
        /// The value to test against the specified data- attribute value
        /// </param>
        /// <returns>
        /// The HtmlControl with the additional search property
        /// </returns>
        /// <remarks>
        /// This is a convenience method that adds the 'data-' suffix
        /// to the attribute name.
        /// </remarks>
        public static T WithDataAttribute<T>(this T current, string dataAttributeName, string dataAttributeValue) where T : HtmlControl
        {
            return current.WithAttribute(String.Format("data-{0}", dataAttributeName), dataAttributeValue);
        }

        /// <summary>
        /// Extends the search properties of the current HtmlControl with
        /// a search definition that can find elements with specific data-
        /// attribute key-value pairs
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The HtmlControl to extend
        /// </param>
        /// <param name="dataAttributes">
        /// Dictionary containing the data attribute key value pairs
        /// </param>
        /// <returns>
        /// The HtmlControl with the additional search property
        /// </returns>
        /// <remarks>
        /// This is a convenience method that adds the 'data-' suffix
        /// to the attribute name.
        /// </remarks>
        public static T WithDataAttributes<T>(this T current, IDictionary<string, string> dataAttributes) where T : HtmlControl
        {
            foreach (var kvp in dataAttributes)
            {
                current = current.WithDataAttribute(kvp.Key, kvp.Value);
            }
            return current;
        }

        public static IEnumerable<T> AllWithAttribute<T>(this T current, string attributeName, string attributeValue) where T : HtmlControl, new()
        {
            return current.WithAttribute(attributeName, attributeValue).FindAllOfMe();
        }

        public static IEnumerable<T> AllWithDataAttribute<T>(this T current, string dataAttributeName, string dataAttributeValue) where T : HtmlControl, new()
        {
            return current.WithDataAttribute(dataAttributeName, dataAttributeValue).FindAllOfMe();
        }

        public static IEnumerable<T> AllWithAttributes<T>(this T current, IDictionary<string, string> attributes) where T : HtmlControl, new()
        {
            return current.WithAttributes(attributes).FindAllOfMe();
        }

        public static IEnumerable<T> AllWithDataAttributes<T>(this T current, IDictionary<string, string> attributes) where T : HtmlControl, new()
        {
            return current.WithDataAttributes(attributes).FindAllOfMe();
        }
    }
}