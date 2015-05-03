using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.Fluent
{
    public static class FluentLegacyExtensions
    {
        #region Find By Reflection
        /// <summary>
        /// Creates a search control that finds the first child control
        /// of type T from the given parent control
        /// </summary>
        /// <typeparam name="T">
        /// The type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <returns>
        /// A search control that finds the first child control
        /// of type T from the given parent control
        /// </returns>
        /// <remarks>
        /// This will not succeed if the type T does not specify enough
        /// search properties by default to actually perform a search.
        /// 
        /// Eg, Find&lt;HtmlControl&gt; will fail as HtmlControl
        /// does not have enough search properties specified.
        /// </remarks>
        public static T FindReflection<T>(this UITestControl parent) where T : UITestControl
        {
            return (T)Activator.CreateInstance(typeof(T), parent);
        }

        /// <summary>
        /// Creates a search control that finds the first child control
        /// of type T from the given parent that matches some property
        /// name and value pair using the specified operator
        /// </summary>
        /// <typeparam name="T">
        /// The type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <param name="propertyName">
        /// The name of the property whose value should be compared
        /// </param>
        /// <param name="propertyValue">
        /// The value against which the specified property should be compared
        /// </param>
        /// <param name="expressionOperator">
        /// The operater used to compare the property value
        /// </param>
        /// <returns>
        /// A search control that finds the first child control
        /// of type T from the given parent that matches some property
        /// name and value pair using the specified operator
        /// </returns>
        public static T FindReflection<T>(this UITestControl parent, string propertyName, string propertyValue, PropertyExpressionOperator expressionOperator) where T : UITestControl
        {
            return parent.FindReflection<T>(new PropertyExpression { PropertyName = propertyName, PropertyValue = propertyValue, PropertyOperator = expressionOperator });
        }

        /// <summary>
        /// Creates a search control that finds the first child control
        /// of type T from the given parent that matches the given
        /// property expression
        /// </summary>
        /// <typeparam name="T">
        /// The type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <param name="propertyExpression">
        /// The search expression to match when searching
        /// </param>
        /// <returns>
        /// A search control that finds the first child control
        /// of type T from the given parent that matches the given
        /// property expression
        /// </returns>
        public static T FindReflection<T>(this UITestControl parent, PropertyExpression propertyExpression) where T : UITestControl
        {
            return parent.FindReflection<T>().Extend(propertyExpression);
        }

        /// <summary>
        /// Creates a search control that finds the first child control
        /// of type T from the given parent that matches the given
        /// name value pairs
        /// </summary>
        /// <typeparam name="T">
        /// The type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <param name="nameValuePairs">
        /// Collection of name values pairs representing the search criteria
        /// </param>
        /// <returns>
        /// A search control that finds the first child control
        /// of type T from the given parent that matches the given
        /// name value pairs
        /// </returns>
        public static T FindReflection<T>(this UITestControl parent, params string[] nameValuePairs) where T : UITestControl
        {
            return parent.FindReflection<T>().Extend(nameValuePairs);
        }

        /// <summary>
        /// Creates a search control that finds the first child control
        /// of type T from the given parent that matches all of the given
        /// property expressions
        /// </summary>
        /// <typeparam name="T">
        /// The type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <param name="expressions">
        /// The search expressions to match when searching
        /// </param>
        /// <returns>
        /// A search control that finds the first child control
        /// of type T from the given parent that matches all of the given
        /// property expression
        /// </returns>
        public static T FindReflection<T>(this UITestControl parent, IEnumerable<PropertyExpression> expressions) where T : UITestControl
        {
            return parent.FindReflection<T>(expressions.ToArray());
        }

        /// <summary>
        /// Creates a search control that finds the first child control
        /// of type T from the given parent that matches all of the given
        /// property expressions
        /// </summary>
        /// <typeparam name="T">
        /// The type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <param name="expressions">
        /// The search expressions to match when searching
        /// </param>
        /// <returns>
        /// A search control that finds the first child control
        /// of type T from the given parent that matches all of the given
        /// property expression
        /// </returns>
        public static T FindReflection<T>(this UITestControl parent, PropertyExpression[] expressions) where T : UITestControl
        {
            return parent.FindReflection<T>().Extend(expressions);
        }

        /// <summary>
        /// Creates a search control that finds the first child control
        /// of type T from the given parent that matches the given
        /// property expression collection
        /// </summary>
        /// <typeparam name="T">
        /// The type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <param name="expressions">
        /// The search expressions to match when searching
        /// </param>
        /// <returns>
        /// A search control that finds the first child control
        /// of type T from the given parent that matches the given
        /// property expression collection
        /// </returns>
        public static T FindReflection<T>(this UITestControl parent, PropertyExpressionCollection expressions) where T : UITestControl
        {
            return parent.FindReflection<T>().Extend(expressions);
        }

        /// <summary>
        /// Creates a search control that finds the child element with
        /// the specified ID
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <param name="propertyValue">
        /// The value against which the specified property should be compared
        /// </param>
        /// <returns>
        /// A search control that finds the child element with
        /// the specified ID
        /// </returns>
        /// <remarks>
        /// This method will use the appropriate ID based on the type of
        /// element to find.  Eg, HtmlControl uses Id,
        /// WpfControl uses AutomationId, and WinControl uses ControlId.
        /// </remarks>
        public static T FindReflection<T>(this UITestControl parent, string propertyValue) where T : UITestControl
        {
            return parent.FindReflection<T>(FluentSearchExtensions.GetIdString<T>(), propertyValue, PropertyExpressionOperator.EqualTo);
        }
        #endregion

        #region Find By Id - Explicit
        /// <summary>
        /// Creates a search control that finds the first child control
        /// of type T from the given parent that matches the ID property
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <param name="propertyValue">
        /// The ID of the element to find
        /// </param>
        /// <returns>
        /// A search control that finds the first child control
        /// of type T from the given parent that matches the ID property
        /// </returns>
        public static T FindByIdHtml<T>(this UITestControl parent, string propertyValue) where T : HtmlControl, new()
        {
            return parent.Find<T>(HtmlControl.PropertyNames.Id, propertyValue, PropertyExpressionOperator.EqualTo);
        }

        /// <summary>
        /// Creates a search control that finds the first child control
        /// of type T from the given parent that matches the
        /// AutomationId property
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <param name="propertyValue">
        /// The ID of the element to find
        /// </param>
        /// <returns>
        /// A search control that finds the first child control
        /// of type T from the given parent that matches the
        /// AutomationId property
        /// </returns>
        public static T FindByIdWpf<T>(this UITestControl parent, string propertyValue) where T : WpfControl, new()
        {
            return parent.Find<T>(WpfControl.PropertyNames.AutomationId, propertyValue, PropertyExpressionOperator.EqualTo);
        }

        /// <summary>
        /// Creates a search control that finds the first child control
        /// of type T from the given parent that matches the ControlId property
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <param name="propertyValue">
        /// The ID of the element to find
        /// </param>
        /// <returns>
        /// A search control that finds the first child control
        /// of type T from the given parent that matches the ControlId property
        /// </returns>
        public static T FindByIdWin<T>(this UITestControl parent, string propertyValue) where T : WinControl, new()
        {
            return parent.Find<T>(WinControl.PropertyNames.ControlId, propertyValue, PropertyExpressionOperator.EqualTo);
        }
        #endregion
    }
}