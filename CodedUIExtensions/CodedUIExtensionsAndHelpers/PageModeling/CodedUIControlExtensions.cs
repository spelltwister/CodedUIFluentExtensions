using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Extensions providing convenience implementations for the Page Model
    /// test methods
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
            return toTest.IsClickable(wait) && toTest.Enabled;
        }

        public static bool IsNotActionable(this UITestControl toTest, int? wait = null)
        {
            return toTest.IsNotClickable(wait) || !toTest.Enabled;
        }
        #endregion
    }
}