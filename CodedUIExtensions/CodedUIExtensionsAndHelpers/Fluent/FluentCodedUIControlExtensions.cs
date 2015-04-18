using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

using CodedUIExtensionsAndHelpers.PageModeling;

namespace CodedUIExtensionsAndHelpers.Fluent
{
    public static class FluentCodedUIControlExtensions
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
            string id = null;
            if (typeof(T).IsSubclassOf(typeof(HtmlControl)) || typeof(T).Equals(typeof(HtmlControl)))
            {
                id = HtmlControl.PropertyNames.Id;
            }
            else if (typeof(T).IsSubclassOf(typeof(WpfControl)) || typeof(T).Equals(typeof(WpfControl)))
            {
                id = WpfControl.PropertyNames.AutomationId;
            }
            else if (typeof(T).IsSubclassOf(typeof(WinControl)) || typeof(T).Equals(typeof(WinControl)))
            {
                id = WinControl.PropertyNames.ControlId;
            }
            else
            {
                throw new NotImplementedException();
            }

            return parent.Find<T>(id, propertyValue, PropertyExpressionOperator.EqualTo);
        }
        #endregion

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
            string id = null;
            if (typeof(T).IsSubclassOf(typeof(HtmlControl)) || typeof(T).Equals(typeof(HtmlControl)))
            {
                id = HtmlControl.PropertyNames.Id;
            }
            else if (typeof(T).IsSubclassOf(typeof(WpfControl)) || typeof(T).Equals(typeof(WpfControl)))
            {
                id = WpfControl.PropertyNames.AutomationId;
            }
            else if (typeof(T).IsSubclassOf(typeof(WinControl)) || typeof(T).Equals(typeof(WinControl)))
            {
                id = WinControl.PropertyNames.ControlId;
            }
            else
            {
                throw new NotImplementedException();
            }

            return parent.FindReflection<T>(id, propertyValue, PropertyExpressionOperator.EqualTo);
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
            return current.FindAllAsType<T>();
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
        #endregion

        #region With Attribute
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
        /// a search definition that can find elements with specific data-
        /// attribute key-value pairs
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
        /// The value to test again the specified data- attribute value
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
        #endregion

        #region Find Siblings
        /// <summary>
        /// Creates a search control which is able to find all children 
        /// of the current control of a specified type
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The UITestControl representing the search criteria
        /// </param>
        /// <returns>
        /// A search control which is able to find all children 
        /// of the current control of a specified type
        /// </returns>
        internal static IEnumerable<T> FindSiblings<T>(this UITestControl current) where T : UITestControl, new()
        {
            return current.GetParent()
                          .FindAll<T>()
                          .Where(x => !current.IsMatch(x));
        }

        /// <summary>
        /// Creates a search control which is able to find all children 
        /// of the current control of a specified type
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The UITestControl representing the search criteria
        /// </param>
        /// <returns>
        /// A search control which is able to find all children 
        /// of the current control of a specified type
        /// </returns>
        internal static IEnumerable<T> FindSiblings<T>(this UITestControl current, string propertyName, string propertyValue, PropertyExpressionOperator expressionOperator) where T : UITestControl, new()
        {
            return current.GetParent()
                          .FindAll<T>(propertyName, propertyValue, expressionOperator)
                          .Where(x => !current.IsMatch(x));
        }

        /// <summary>
        /// Creates a search control which is able to find all children 
        /// of the current control of a specified type
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The UITestControl representing the search criteria
        /// </param>
        /// <returns>
        /// A search control which is able to find all children 
        /// of the current control of a specified type
        /// </returns>
        internal static IEnumerable<T> FindSiblings<T>(this UITestControl current, PropertyExpression expression) where T : UITestControl, new()
        {
            return current.GetParent()
                          .FindAll<T>(expression)
                          .Where(x => !current.IsMatch(x));
        }

        /// <summary>
        /// Creates a search control which is able to find all children 
        /// of the current control of a specified type
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The UITestControl representing the search criteria
        /// </param>
        /// <returns>
        /// A search control which is able to find all children 
        /// of the current control of a specified type
        /// </returns>
        internal static IEnumerable<T> FindSiblings<T>(this UITestControl current, params string[] nameValuePairs) where T : UITestControl, new()
        {
            return current.GetParent()
                          .FindAll<T>(nameValuePairs)
                          .Where(x => !current.IsMatch(x));
        }

        /// <summary>
        /// Creates a search control which is able to find all children 
        /// of the current control of a specified type
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The UITestControl representing the search criteria
        /// </param>
        /// <returns>
        /// A search control which is able to find all children 
        /// of the current control of a specified type
        /// </returns>
        internal static IEnumerable<T> FindSiblings<T>(this UITestControl current, IEnumerable<PropertyExpression> expressions) where T : UITestControl, new()
        {
            return current.GetParent()
                          .FindAll<T>(expressions)
                          .Where(x => !current.IsMatch(x));
        }

        /// <summary>
        /// Creates a search control which is able to find all children 
        /// of the current control of a specified type
        /// </summary>
        /// <typeparam name="T">
        /// Type of control to find
        /// </typeparam>
        /// <param name="current">
        /// The UITestControl representing the search criteria
        /// </param>
        /// <returns>
        /// A search control which is able to find all children 
        /// of the current control of a specified type
        /// </returns>
        internal static IEnumerable<T> FindSiblings<T>(this UITestControl current, PropertyExpressionCollection expressions) where T : UITestControl, new()
        {
            return current.GetParent()
                          .FindAll<T>(expressions)
                          .Where(x => !current.IsMatch(x));
        }
        #endregion

        #region Property Getters
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
            return control.TryGetProperty<T>(propertyName, x => x as T, out propertyValue);
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
        #endregion

        private static bool IsMatch<T>(this UITestControl current, T other) where T : UITestControl
        {
            if (typeof(T).IsSubclassOf(typeof(HtmlControl)))
            {
                return IsMatch(other as HtmlControl, (HtmlControl)current);
            }

            if (typeof(T).IsSubclassOf(typeof(WpfControl)))
            {
                return IsMatch(other as WpfControl, (WpfControl)current);
            }

            if (typeof(T).IsSubclassOf(typeof(WinControl)))
            {
                return IsMatch(other as WinControl, (WinControl)current);
            }

            throw new NotImplementedException();  
        }

        private static bool IsMatch(HtmlControl a, HtmlControl b)
        {
            return a.TagInstance == b.TagInstance;
        }

        private static bool IsMatch(WpfControl a, WpfControl b)
        {
            throw new NotImplementedException();
        }

        private static bool IsMatch(WinControl a, WinControl b)
        {
            throw new NotImplementedException();
        }
    }
}