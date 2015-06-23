using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling
{
    /// <summary>
    /// Extensions for testing whether a UI control can be found, whether
    /// it is clickable, etc... along with some helpers for treating UI
    /// controls as page models with common semantics
    /// </summary>
    public static class CodedUIControlExtensions
    {
        #region Find Helpers
        /// <summary>
        /// Optionally waits for the control to exist and returns true if
        /// the element can be found; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to try to find
        /// </param>
        /// <param name="wait"> 
        /// Optional wait time in milliseconds to wait for the control to exist
        /// before trying to find
        /// </param>
        /// <returns>
        /// True if the element can be found after the specified wait;
        /// otherwise, false
        /// </returns>
        public static bool CanFind(this UITestControl toTest, int? wait = null)
        {
            if (wait.HasValue)
            {
                toTest.WaitForControlExist(wait.Value);
            }
            return toTest.TryFind();
        }

        /// <summary>
        /// Optionally waits for the control to not exist and returns false if
        /// the element can be found; otherwise, true
        /// </summary>
        /// <param name="toTest">
        /// The element to try to find
        /// </param>
        /// <param name="wait"> 
        /// Optional wait time in milliseconds to wait for the control to
        /// not exist before trying to find
        /// </param>
        /// <returns>
        /// True if the element cannot be found after the specified wait;
        /// otherwise, false
        /// </returns>
        public static bool CanNotFind(this UITestControl toTest, int? wait = null)
        {
            if (wait.HasValue)
            {
                toTest.WaitForControlNotExist(wait.Value);
            }
            return !toTest.TryFind();
        }
        #endregion

        #region Visibility Helpers
        /// <summary>
        /// Returns true if an element is filling space; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to test for filling space
        /// </param>
        /// <returns>
        /// True if an element is filling space; otherwise, false
        /// </returns>
        /// <remarks>
        /// The element must have non-zero width and height to be
        /// considered filling space
        /// </remarks>
        public static bool IsFillingSpace(this UITestControl toTest)
        {
            return toTest.Width > 0 && toTest.Height > 0;
        }

        /// <summary>
        /// Returns true if an element is visible, but not
        /// necessarily clickable; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to test for visibility
        /// </param>
        /// <param name="wait">
        /// Optional wait time in milliseconds to wait for the control to
        /// exist before trying to test for visibility
        /// </param>
        /// <returns>
        /// True if an element is visible; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element can be visible, but not clickable
        /// </remarks>
        public static bool IsVisible(this UITestControl toTest, int? wait = null)
        {
            if (wait.HasValue)
            {
                toTest.WaitForControlExist(wait.Value);
            }
            return toTest.TryFind() && toTest.IsFillingSpace();
        }

        /// <summary>
        /// Returns true if an element is hidden; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to test for visibility
        /// </param>
        /// <param name="wait">
        /// Optional wait time in milliseconds to wait for the control to not
        /// exist before trying to test for visibility
        /// </param>
        /// <returns>
        /// True if an element is hidden; otherwise, false
        /// </returns>
        public static bool IsHidden(this UITestControl toTest, int? wait = null)
        {
            if (wait.HasValue)
            {
                toTest.WaitForControlNotExist(wait.Value);
            }
            return !toTest.TryFind() || !toTest.IsFillingSpace();
        }
        #endregion

        #region Clickable Helpers
        /// <summary>
        /// Returns true if an element is not clickable; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to test if it is clickable
        /// </param>
        /// <param name="wait">
        /// Optional wait time in milliseconds to wait for the control to not
        /// exist before trying to test for clickability
        /// </param>
        /// <returns>
        /// True if an element is not clickable; otherwise, false
        /// </returns>
        public static bool IsNotClickable(this UITestControl toTest, int? wait = null)
        {
            if (wait.HasValue)
            {
                toTest.WaitForControlNotExist(wait.Value);
            }
            Point p;
            return !toTest.TryGetClickablePoint(out p);
        }

        /// <summary>
        /// Returns true if an element is clickable; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to test if it is clickable
        /// </param>
        /// <param name="wait">
        /// Optional wait time in milliseconds to wait for the control to
        /// exist before trying to test for clickability
        /// </param>
        /// <returns>
        /// True if an element is clickable; otherwise, false
        /// </returns>
        public static bool IsClickable(this UITestControl toTest, int? wait = null)
        {
            if (wait.HasValue)
            {
                toTest.WaitForControlExist(wait.Value);
            }
            Point p;
            return toTest.TryGetClickablePoint(out p);
        }
        #endregion

        #region Actionable Helpers
        public static bool IsActionable(this UITestControl toTest, int? wait = null)
        {
            if (wait == null)
            {
                return toTest.IsClickable() && toTest.Enabled;
            }
            Thread.Sleep((int)wait);
            return toTest.IsClickable() && toTest.Enabled;
        }

        public static bool IsNotActionable(this UITestControl toTest, int? wait = null)
        {
            return toTest.IsNotClickable(wait) || !toTest.Enabled;
        }
        #endregion

        #region Page Model Extensions
        /// <summary>
        /// Wraps the current control in an IPageModel adapter
        /// </summary>
        /// <param name="current">
        /// The control to wrap in an IPageModel adapter
        /// </param>
        /// <returns>
        /// The current control wrapped as an IPageModel
        /// </returns>
        /// <remarks>
        /// Remember, we do not want to expose native controls, instead
        /// we want to work with page models.  Every UITestControl can
        /// be represented as a stand alone page model which simply
        /// provides an interface for testing the visibility,
        /// actionability, ... of an element.
        /// </remarks>
        public static IPageModel AsPageModel(this UITestControl current)
        {
            return new UIControlPageModelWrapper<UITestControl>(current);
        }

        /// <summary>
        /// Wraps the current control in an IClickablePageModel adapter
        /// </summary>
        /// <typeparam name="TNextModel">
        /// Type of next model after clicking
        /// </typeparam>
        /// <param name="current">
        /// The control to wrap in an IClickablePageModel adapter
        /// </param>
        /// <param name="nextModel">
        /// The next model after clicking
        /// </param>
        /// <returns>
        /// The current control wrapped as an IClickablePageModel
        /// </returns>
        /// <remarks>
        /// While just about every control supports being clicked on,
        /// many do not have a useful semantic around clicking.  This is
        /// why IPageModel does not natively support a click action.
        /// </remarks>
        public static IClickablePageModel<TNextModel> AsClickablePageModel<TNextModel>(this UITestControl current, TNextModel nextModel) where TNextModel : IPageModel
        {
            return new ClickableControlPageModelWrapper<UITestControl, TNextModel>(current, nextModel);
        }

        /// <summary>
        /// Wraps the current control in an IValuedPageModel adapter
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of value stored in this control
        /// </typeparam>
        /// <typeparam name="TControl">
        /// Type of GUI element
        /// </typeparam>
        /// <param name="current">
        /// The control to wrap in an IValuedPageModel adapter
        /// </param>
        /// <param name="controlToValueFunc">
        /// Function that can convert the control to its value
        /// </param>
        /// <returns>
        /// The current control wrapped as an IValuedPageModel
        /// </returns>
        /// <remarks>
        /// Just about every control stores a value that the user
        /// can observe, though it may not be textual.  Consider a
        /// checkbox; it does not have &quot;text&quot; shown to the user,
        /// simply some sort of checkmark or the absense of it is shown.
        /// </remarks>
        public static IValuedPageModel<TValue> AsValuedPageModel<TValue, TControl>(this TControl current, Func<TControl, TValue> controlToValueFunc) where TControl : UITestControl
        {
            return new ValuedControlPageModelWrapper<TControl, TValue>(current, controlToValueFunc);
        }

        /// <summary>
        /// Wraps the current control in an ITextValuedPageModel adapter
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of value stored in this control
        /// </typeparam>
        /// <typeparam name="TControl">
        /// Type of GUI element
        /// </typeparam>
        /// <param name="current">
        /// The control to wrap in an ITextValuedPageModel adapter
        /// </param>
        /// <param name="stringToValueFunc">
        /// Function that can convert the text shown to the user into
        /// the native value type
        /// </param>
        /// <param name="controlToStringFunc">
        /// Function that can get the text shown to the user from the control
        /// </param>
        /// <returns>
        /// The current control wrapped as an ITextValuedPageModel
        /// </returns>
        /// <remarks>
        /// Many controls show some text to the user to represent a value type.
        /// Examples include Date column in a table, text block with a money
        /// value inside, etc.
        /// 
        /// However, many controls do not have a text component and should not
        /// be coerced into this representation.
        /// </remarks>
        public static ITextValuedPageModel<TValue> AsTextValuedPageModel<TValue, TControl>(this TControl current, Func<string, TValue> stringToValueFunc, Func<TControl, string> controlToStringFunc) where TControl : UITestControl
        {
            return new TextValuedControlPageModelWrapper<TControl, TValue>(current, stringToValueFunc, controlToStringFunc);
        }
        #endregion
    }
}