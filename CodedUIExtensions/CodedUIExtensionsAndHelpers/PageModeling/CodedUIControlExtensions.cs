using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public static class CodedUIControlExtensions
    {
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
            return toTest.TryFind();
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
            return !toTest.TryFind();
        }
    }
}