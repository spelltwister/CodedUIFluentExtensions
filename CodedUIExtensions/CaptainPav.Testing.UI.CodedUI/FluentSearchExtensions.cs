using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI
{
    public static class FluentSearchExtensions
    {
        #region Find
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
        public static T Find<T>(this UITestControl parent) where T : UITestControl, new()
        {
            return new T() { Container = parent };
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
        public static T Find<T>(this UITestControl parent, string propertyName, string propertyValue, PropertyExpressionOperator expressionOperator) where T : UITestControl, new()
        {
            return parent.Find<T>(new PropertyExpression { PropertyName = propertyName, PropertyValue = propertyValue, PropertyOperator = expressionOperator });
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
        public static T Find<T>(this UITestControl parent, PropertyExpression propertyExpression) where T : UITestControl, new()
        {
            return parent.Find<T>().Extend(propertyExpression);
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
        public static T Find<T>(this UITestControl parent, params string[] nameValuePairs) where T : UITestControl, new()
        {
            return parent.Find<T>().Extend(nameValuePairs);
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
        public static T Find<T>(this UITestControl parent, IEnumerable<PropertyExpression> expressions) where T : UITestControl, new()
        {
            return parent.Find<T>(expressions.ToArray());
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
        public static T Find<T>(this UITestControl parent, PropertyExpression[] expressions) where T : UITestControl, new()
        {
            return parent.Find<T>().Extend(expressions);
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
        public static T Find<T>(this UITestControl parent, PropertyExpressionCollection expressions) where T : UITestControl, new()
        {
            return parent.Find<T>().Extend(expressions);
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
        public static T Find<T>(this UITestControl parent, string propertyValue) where T : UITestControl, new()
        {
            return parent.Find<T>(GetIdString<T>(), propertyValue, PropertyExpressionOperator.EqualTo);
        }
        #endregion
        
        #region Find All
        /// <summary>
        /// Creates a search control that will find all children of the
        /// specified type
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <returns>
        /// A search control that will find all children of the
        /// specified type
        /// </returns>
        public static IEnumerable<T> FindAll<T>(this UITestControl parent) where T : UITestControl, new()
        {
            return parent.Find<T>().FindAllAsType<T>();
        }

        /// <summary>
        /// Creates a search control that will find all children of the
        /// specified type matching the search criteria
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <returns>
        /// A search control that will find all children of the
        /// specified type matching the search criteria
        /// </returns>
        public static IEnumerable<T> FindAll<T>(this UITestControl parent, string propertyName, string propertyValue, PropertyExpressionOperator expressionOperator) where T : UITestControl, new()
        {
            return parent.FindAll<T>(new PropertyExpression() { PropertyName = propertyName, PropertyValue = propertyValue, PropertyOperator = expressionOperator });
        }

        /// <summary>
        /// Creates a search control that will find all children of the
        /// specified type matching the property expression
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <returns>
        /// A search control that will find all children of the
        /// specified type matching the property expression
        /// </returns>
        public static IEnumerable<T> FindAll<T>(this UITestControl parent, PropertyExpression expression) where T : UITestControl, new()
        {
            return parent.Find<T>(expression).FindAllAsType<T>();
        }

        /// <summary>
        /// Creates a search control that will find all children of the
        /// specified type matching the name value pairs representing the
        /// search criteria
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <returns>
        /// A search control that will find all children of the
        /// specified type matching the name value pairs representing the
        /// search criteria
        /// </returns>
        public static IEnumerable<T> FindAll<T>(this UITestControl parent, params string[] nameValuePairs) where T : UITestControl, new()
        {
            return parent.Find<T>(nameValuePairs).FindAllAsType<T>();
        }

        /// <summary>
        /// Creates a search control that will find all children of the
        /// specified type matching all of the property expression
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <returns>
        /// A search control that will find all children of the
        /// specified type matching all of the property expression
        /// </returns>
        public static IEnumerable<T> FindAll<T>(this UITestControl parent, IEnumerable<PropertyExpression> expressions) where T : UITestControl, new()
        {
            return parent.Find<T>(expressions).FindAllAsType<T>();
        }

        /// <summary>
        /// Creates a search control that will find all children of the
        /// specified type matching the property expression collection
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="parent">
        /// The UITestControl from which to start searching
        /// </param>
        /// <returns>
        /// A search control that will find all children of the
        /// specified type matching the property expression collection
        /// </returns>
        public static IEnumerable<T> FindAll<T>(this UITestControl parent, PropertyExpressionCollection expressions) where T : UITestControl, new()
        {
            return parent.Find<T>(expressions).FindAllAsType<T>();
        }

        /// <summary>
        /// Creates a search control that will find all of the controls
        /// which are of the specified type matching the current
        /// search criteria
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The UITestControl representing the search criteria
        /// </param>
        /// <returns>
        /// A search control that will find all of the controls
        /// which are of the specified type matching the current
        /// search criteria
        /// </returns>
        public static IEnumerable<T> FindAllOfMe<T>(this T current) where T : UITestControl, new()
        {
            return current.FindAllAsType();
        }

        /// <summary>
        /// Creates a search control that will find all of the controls which
        /// are of the specified type matching the current search criteria,
        /// and cast to the target type
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <typeparam name="U">
        /// Type of control to which to cast
        /// </typeparam>
        /// <param name="current">
        /// The element from which to start searching
        /// </param>
        /// <returns>
        /// A search control that will find all of the controls which are of
        /// the specified type matching the current search criteria,
        /// and cast to the target type
        /// </returns>
        private static IEnumerable<U> FindAllCastTo<T, U>(this T current) where T : UITestControl
        {
            return current.FindMatchingControls().Cast<U>();
        }

        /// <summary>
        /// Creates a search control that will find all of the controls
        /// which are of the specified type matching the current
        /// search criteria
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The UITestControl representing the search criteria
        /// </param>
        /// <returns>
        /// A search control that will find all of the controls
        /// which are of the specified type matching the current
        /// search criteria
        /// </returns>
        private static IEnumerable<T> FindAllAsType<T>(this T current) where T : UITestControl, new()
        {
            if (typeof(T).IsSubclassOf(typeof(HtmlControl)))
            {
                return current.FindMatchingControls().Select(x => new T().ExtendFrom(x));
            }
            return current.FindMatchingControls().OfType<T>();
        }

        /// <summary>
        /// Provides a fluent method of copying search properties from
        /// some control to this control
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to which to copy search properties
        /// </typeparam>
        /// <param name="current">
        /// The control to which to copy search properties
        /// </param>
        /// <param name="toCopy"></param>
        /// <returns></returns>
        /// <remarks>
        /// The original properties are not cleared and this method is meant
        /// for copying properties to new objects
        /// </remarks>
        private static T ExtendFrom<T>(this T current, UITestControl toCopy) where T : UITestControl
        {
            current.CopyFrom(toCopy);
            return current;
        }
        #endregion

        #region Extend
        /// <summary>
        /// Extends the search properties of the current UITestControl
        /// and returns that search control with the additional property
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The UITestControl to extend
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
        /// The current UITestControl with the additional search property
        /// </returns>
        public static T Extend<T>(this T current, string propertyName, string propertyValue, PropertyExpressionOperator expressionOperator) where T : UITestControl
        {
            current.SearchProperties.Add(propertyName, propertyValue, expressionOperator);
            return current;
        }

        /// <summary>
        /// Extends the search properties of the current UITestControl
        /// and returns that search control with the additional property
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The UITestControl to extend
        /// </param>
        /// <returns>
        /// The current UITestControl with the additional search property
        /// </returns>
        public static T Extend<T>(this T current, PropertyExpression expression) where T : UITestControl
        {
            current.SearchProperties.Add(expression);
            return current;
        }

        /// <summary>
        /// Extends the search properties of the current UITestControl
        /// and returns that search control with the additional property
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The UITestControl to extend
        /// </param>
        /// <returns>
        /// The current UITestControl with the additional search property
        /// </returns>
        public static T Extend<T>(this T current, params string[] nameValuePairs) where T : UITestControl
        {
            current.SearchProperties.Add(nameValuePairs);
            return current;
        }

        /// <summary>
        /// Extends the search properties of the current UITestControl
        /// and returns that search control with the additional property
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The UITestControl to extend
        /// </param>
        /// <returns>
        /// The current UITestControl with the additional search property
        /// </returns>
        public static T Extend<T>(this T current, IEnumerable<PropertyExpression> expressions) where T : UITestControl
        {
            return current.Extend(expressions.ToArray());
        }

        /// <summary>
        /// Extends the search properties of the current UITestControl
        /// and returns that search control with the additional property
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The UITestControl to extend
        /// </param>
        /// <returns>
        /// The current UITestControl with the additional search property
        /// </returns>
        public static T Extend<T>(this T current, PropertyExpression[] expressions) where T : UITestControl
        {
            current.SearchProperties.AddRange(expressions);
            return current;
        }

        /// <summary>
        /// Extends the search properties of the current UITestControl
        /// and returns that search control with the additional property
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The UITestControl to extend
        /// </param>
        /// <returns>
        /// The current UITestControl with the additional search property
        /// </returns>
        public static T Extend<T>(this T current, PropertyExpressionCollection expressions) where T : UITestControl
        {
            current.SearchProperties.AddRange(expressions);
            return current;
        }

        internal static string GetIdString<T>() where T : UITestControl
        {
            Type type = typeof(T);

            if (type.IsHtmlControl())
            {
                return HtmlControl.PropertyNames.Id;
            }

            if (type.IsWpfControl())
            {
                return WpfControl.PropertyNames.AutomationId;
            }

            if (type.IsWinControl())
            {
                return WinControl.PropertyNames.ControlId;
            }

            throw new NotImplementedException();
        }
        #endregion
    }
}