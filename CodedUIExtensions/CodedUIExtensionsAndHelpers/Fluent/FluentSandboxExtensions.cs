using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.Fluent
{
    internal static class FluentSandboxExtensions
    {
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
                .Where(x => !current.IsMatch<T>(x));
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