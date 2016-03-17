using System;
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
        /// Returns true if the element can be found; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to try to find
        /// </param>
        /// <returns>
        /// True if the element can be found; otherwise, false
        /// </returns>
        public static bool CanFind(this UITestControl toTest)
        {
            return toTest.TryFind();
        }

        /// <summary>
        /// Waits for the control to exist and returns true if
        /// the element can be found; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to try to find
        /// </param>
        /// <param name="wait"> 
        /// Wait time in milliseconds to wait for the control to exist
        /// before trying to find; if null, Playback.PlaybackSettings.WaitForReadyTimeout
        /// is used as the wait time 
        /// </param>
        /// <returns>
        /// True if the element can be found after waiting; otherwise, false
        /// </returns>
        public static bool CanFind(this UITestControl toTest, int? wait)
        {
            if (wait.HasValue)
            {
                return toTest.CanFind(x => x.WaitForControlExist(wait.Value));
            }
            return toTest.CanFind();
        }

        /// <summary>
        /// Waits for the control condition and returns true if
        /// the element can be found; otherwise, false.  If the condition
        /// is not met before the specified timeout, false is returned.
        /// </summary>
        /// <param name="toTest">
        /// The element to try to find
        /// </param>
        /// <param name="testFunc"> 
        /// The predicate describing the control condition for which to wait
        /// before trying to find the specified test control
        /// </param>
        /// <param name="timeOut">
        /// Time to wait for the control condition before returning false; if
        /// null, Playback.PlaybackSettings.WaitForReadyTimeout is used
        /// </param>
        /// <returns>
        /// True if the element can be found after the condition is met;
        /// otherwise, false
        /// </returns>
        public static bool CanFind<T>(this T toTest, Predicate<T> testFunc, int? timeOut = null) where T : UITestControl
        {
            if (!toTest.WaitForControlCondition(testFunc, timeOut))
            {
                //return false;
            }
            return toTest.CanFind();
        }

        /// <summary>
        /// Returns false if the element can be found; otherwise, true
        /// </summary>
        /// <param name="toTest">
        /// The element to try to find
        /// </param>
        /// <returns>
        /// True if the element cannot be found; otherwise, false
        /// </returns>
        public static bool CanNotFind(this UITestControl toTest)
        {
            return !toTest.CanFind();
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
        public static bool CanNotFind(this UITestControl toTest, int? wait)
        {
            if (wait.HasValue)
            {
                return toTest.CanNotFind(x => x.WaitForControlNotExist(wait.Value));
            }
            return toTest.CanNotFind();
        }

        /// <summary>
        /// Optionally waits for the control condition and returns false if
        /// the element can be found; otherwise, true
        /// </summary>
        /// <param name="toTest">
        /// The element to try to find
        /// </param>
        /// <param name="testFunc"> 
        /// The predicate describing the control condition for which to wait
        /// before trying to find the specified test control
        /// </param>
        /// <param name="timeOut">
        /// Time to wait for the control condition before returning false; if
        /// null, Playback.PlaybackSettings.WaitForReadyTimeout is used
        /// </param>
        /// <returns>
        /// True if the element cannot be found after the specified condition;
        /// otherwise, false
        /// </returns>
        public static bool CanNotFind<T>(this T toTest, Predicate<T> testFunc, int? timeOut = null) where T : UITestControl
        {
            if (!toTest.WaitForControlCondition(testFunc, timeOut))
            {
                //return false;
            }
            return toTest.CanNotFind();
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
        /// Returns true if an element is filling space after the specified
        /// condition; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to test for filling space
        /// </param>
        /// <param name="condition"> 
        /// The predicate describing the control condition for which to wait
        /// before testing
        /// </param>
        /// <param name="wait">
        /// Time to wait for the control condition before returning false; if
        /// null, Playback.PlaybackSettings.WaitForReadyTimeout is used
        /// </param>
        /// <returns>
        /// True if an element is filling space; otherwise, false
        /// </returns>
        /// <remarks>
        /// The element must have non-zero width and height to be
        /// considered filling space
        /// </remarks>
        public static bool IsFillingSpace<T>(this T toTest, Predicate<T> condition, int? wait = null) where T : UITestControl
        {
            if (!toTest.WaitForControlCondition(condition, wait))
            {
                return false;
            }
            return toTest.IsFillingSpace();
        }

        /// <summary>
        /// Returns true if an element is visible, but not
        /// necessarily clickable; otherwise, false.  A visible element
        /// must be able to be found and must fill space on the rendering canvas.
        /// An element can be off screen and not visible to the user, but
        /// still considered visible if it can be found and has non-zero
        /// height and width.
        /// </summary>
        /// <param name="toTest">
        /// The element to test for visibility
        /// </param>
        /// <returns>
        /// True if an element is visible; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element can be visible, but not clickable
        /// </remarks>
        [Obsolete("Will be removed in future. Use IsRendered instead.")]
        public static bool IsVisible(this UITestControl toTest)
        {
            return toTest.IsRendered();
        }

        /// <summary>
        /// Returns true if an element is rendered, but not
        /// necessarily clickable; otherwise, false.  A rendered element
        /// must be able to be found and must fill space on rendering canvas.
        /// An element can be off screen and not visible to the user, but
        /// still considered rendered if it can be found and has non-zero
        /// height and width.
        /// </summary>
        /// <param name="toTest">
        /// The element to test for rendered
        /// </param>
        /// <returns>
        /// True if an element is rendered; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element can be rendered, but not clickable or visible to
        /// the client (eg, off screen)
        /// </remarks>
        public static bool IsRendered(this UITestControl toTest)
        {
            return toTest.TryFind() && toTest.IsFillingSpace();
        }

        /// <summary>
        /// Returns true if an element is visible, but not
        /// necessarily clickable; otherwise, false.  A visible element
        /// must be able to be found and must fill space on the screen.
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
        [Obsolete("Will be removed in future. Use IsRendered instead.")]
        public static bool IsVisible(this UITestControl toTest, int? wait)
        {
            return toTest.IsRendered(wait);
        }

        /// <summary>
        /// Returns true if an element is rendered, but not
        /// necessarily clickable; otherwise, false.  A rendered element
        /// must be able to be found and must fill space on rendering canvas.
        /// An element can be off screen and not visible to the user, but
        /// still considered rendered if it can be found and has non-zero
        /// height and width.
        /// </summary>
        /// <param name="toTest">
        /// The element to test for rendered
        /// </param>
        /// <param name="wait">
        /// Optional wait time in milliseconds to wait for the control to
        /// exist before trying to test for rendered
        /// </param>
        /// <returns>
        /// True if an element is rendered; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element can be rendered, but not clickable or visible to
        /// the client (eg, off screen)
        /// </remarks>
        public static bool IsRendered(this UITestControl toTest, int? wait)
        {
            if (wait.HasValue)
            {
                return toTest.IsRendered(x => x.WaitForControlExist(wait.Value));
            }
            return toTest.IsRendered();
        }

        /// <summary>
        /// Returns true if an element is visible, but not
        /// necessarily clickable, after the specified condition; otherwise, false.
        /// A visible element must be able to be found and must fill space on the screen.
        /// </summary>
        /// <param name="toTest">
        /// The element to test for visibility
        /// </param>
        /// <param name="condition"> 
        /// The predicate describing the control condition for which to wait
        /// before testing
        /// </param>
        /// <param name="wait">
        /// Time to wait for the control condition before returning false; if
        /// null, Playback.PlaybackSettings.WaitForReadyTimeout is used
        /// </param>
        /// <returns>
        /// True if an element is visible; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element can be visible, but not clickable
        /// </remarks>
        [Obsolete("Will be removed in future. Use IsRendered instead.")]
        public static bool IsVisible<T>(this T toTest, Predicate<T> condition, int? wait = null) where T : UITestControl
        {
            return toTest.IsRendered(condition, wait);
        }

        /// <summary>
        /// Returns true if an element is rendered, but not
        /// necessarily clickable, after the specified condition; otherwise, false.
        /// A rendered element must be able to be found and must fill space on rendering canvas.
        /// An element can be off screen and not visible to the user, but
        /// still considered rendered if it can be found and has non-zero
        /// height and width.
        /// </summary>
        /// <param name="toTest">
        /// The element to test for rendered
        /// </param>
        /// <param name="condition"> 
        /// The predicate describing the control condition for which to wait
        /// before testing
        /// </param>
        /// <param name="wait">
        /// Time to wait for the control condition before returning false; if
        /// null, Playback.PlaybackSettings.WaitForReadyTimeout is used
        /// </param>
        /// <returns>
        /// True if an element is rendered; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element can be rendered, but not clickable or visible to
        /// the client (eg, off screen)
        /// </remarks>
        public static bool IsRendered<T>(this T toTest, Predicate<T> condition, int? wait = null) where T : UITestControl
        {
            if (!toTest.WaitForControlCondition(condition, wait))
            {
                //return false;
            }
            return toTest.IsRendered();
        }

        /// <summary>
        /// Returns true if an element is not rendered; otherwise, false.
        /// A rendered element must be able to be found and must fill space on rendering canvas.
        /// An element can be off screen and not visible to the user, but
        /// still considered rendered if it can be found and has non-zero
        /// height and width.
        /// </summary>
        /// <param name="toTest">
        /// The element to test for rendered
        /// </param>
        /// <returns>
        /// True if an element is not rendered; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element can be rendered, but not clickable or visible to
        /// the client (eg, off screen)
        /// </remarks>
        [Obsolete("Will be removed in future. Use IsNotRendered instead.")]
        public static bool IsHidden(this UITestControl toTest)
        {
            return toTest.IsNotRendered();
        }

        /// <summary>
        /// Returns true if an element is not rendered; otherwise, false.
        /// A rendered element must be able to be found and must fill space on rendering canvas.
        /// An element can be off screen and not visible to the user, but
        /// still considered rendered if it can be found and has non-zero
        /// height and width.
        /// </summary>
        /// <param name="toTest">
        /// The element to test for rendered
        /// </param>
        /// <returns>
        /// True if an element is not rendered; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element can be rendered, but not clickable or visible to
        /// the client (eg, off screen)
        /// </remarks>
        public static bool IsNotRendered(this UITestControl toTest)
        {
            return !toTest.IsRendered();
        }

        /// <summary>
        /// Returns true if an element is hidden; otherwise, false.  An
        /// element is hidden if it cannot be found or it is not filling space
        /// on the screen.
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
        /// <remarks>
        /// An element that can be found on the page, but is not filling space,
        /// is considered hidden.  An element that cannot be found is also
        /// considered hidden.
        /// </remarks>
        [Obsolete("Will be removed in future. Use IsNotRendered instead.")]
        public static bool IsHidden(this UITestControl toTest, int? wait)
        {
            return toTest.IsNotRendered(wait);
        }

        /// <summary>
        /// Returns true if an element is not rendered; otherwise, false.
        /// A rendered element must be able to be found and must fill space on rendering canvas.
        /// An element can be off screen and not visible to the user, but
        /// still considered rendered if it can be found and has non-zero
        /// height and width.
        /// </summary>
        /// <param name="toTest">
        /// The element to test for rendered
        /// </param>
        /// <param name="wait">
        /// Optional wait time in milliseconds to wait for the control to not
        /// exist before trying to test for rendered
        /// </param>
        /// <returns>
        /// True if an element is not rendered; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element can be rendered, but not clickable or visible to
        /// the client (eg, off screen)
        /// </remarks>
        public static bool IsNotRendered(this UITestControl toTest, int? wait)
        {
            if (wait.HasValue)
            {
                return toTest.IsNotRendered(x => x.WaitForControlNotExist(wait.Value));
            }
            return toTest.IsNotRendered();
        }

        /// <summary>
        /// Returns true if an element is not rendered; otherwise, false.
        /// A rendered element must be able to be found and must fill space on rendering canvas.
        /// An element can be off screen and not visible to the user, but
        /// still considered rendered if it can be found and has non-zero
        /// height and width.
        /// </summary>
        /// <param name="toTest">
        /// The element to test for rendered
        /// </param>
        /// <param name="condition"> 
        /// The predicate describing the control condition for which to wait
        /// before testing
        /// </param>
        /// <param name="wait">
        /// Time to wait for the control condition before returning false; if
        /// null, Playback.PlaybackSettings.WaitForReadyTimeout is used
        /// </param>
        /// <returns>
        /// True if an element is not rendered; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element can be rendered, but not clickable or visible to
        /// the client (eg, off screen)
        /// </remarks>
        public static bool IsNotRendered<T>(this T toTest, Predicate<T> condition, int? wait = null) where T : UITestControl
        {
            if (!toTest.WaitForControlCondition(condition, wait))
            {
                //return false;
            }
            return toTest.IsNotRendered();
        }
        #endregion

        #region Clickable Helpers
        /// <summary>
        /// Returns true if there is a point on the screen which can trigger
        /// the click action of this control; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to test if it is clickable
        /// </param>
        /// <returns>
        /// True if there is a point on the screen which can trigger
        /// the click action of this control; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element which is clickable is not necessarily enabled and
        /// clicking may not result in any page model response.  See
        /// <see cref="IsActionable(Microsoft.VisualStudio.TestTools.UITesting.UITestControl)"/>
        /// </remarks>
        public static bool IsClickable(this UITestControl toTest)
        {
            try
            {
                toTest.EnsureClickable();
            }
            catch { }
            return toTest.CanGetClickablePoint();
        }

        /// <summary>
        /// Returns true if there is a point on the screen which can trigger
        /// the click action of this control; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to test if it is clickable
        /// </param>
        /// <param name="wait">
        /// Optional wait time in milliseconds to wait for the control to
        /// exist before trying to test for clickability
        /// </param>
        /// <returns>
        /// True if there is a point on the screen which can trigger
        /// the click action of this control; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element which is clickable is not necessarily enabled and
        /// clicking may not result in any page model response.  See
        /// <see cref="IsActionable(Microsoft.VisualStudio.TestTools.UITesting.UITestControl, System.Nullable{int})"/>
        /// </remarks>
        public static bool IsClickable(this UITestControl toTest, int? wait)
        {
            if (wait.HasValue)
            {
                return toTest.IsClickable(x => x.WaitForControlExist(wait.Value));
            }
            return toTest.IsClickable();
        }

        /// <summary>
        /// Returns true if there is a point on the screen which can trigger
        /// the click action of this control; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to test if it is clickable
        /// </param>
        /// <param name="condition"> 
        /// The predicate describing the control condition for which to wait
        /// before testing
        /// </param>
        /// <param name="wait">
        /// Time to wait for the control condition before returning false; if
        /// null, Playback.PlaybackSettings.WaitForReadyTimeout is used
        /// </param>
        /// <returns>
        /// True if there is a point on the screen which can trigger
        /// the click action of this control; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element which is clickable is not necessarily enabled and
        /// clicking may not result in any page model response.  See
        /// <see cref="IsActionable(Microsoft.VisualStudio.TestTools.UITesting.UITestControl, System.Predicate{T}, System.Nullable{int})"/>
        /// </remarks>
        public static bool IsClickable<T>(this T toTest, Predicate<T> condition, int? wait = null) where T : UITestControl
        {
            if (!toTest.WaitForControlCondition(condition, wait))
            {
                //return false;
            }
            return toTest.IsClickable();
        }

        /// <summary>
        /// Returns false if there is a point on the screen which can trigger
        /// the click action of this control; otherwise, true
        /// </summary>
        /// <param name="toTest">
        /// The element to test if it is clickable
        /// </param>
        /// <returns>
        /// False if there is a point on the screen which can trigger
        /// the click action of this control; otherwise, true
        /// </returns>
        /// <remarks>
        /// An element which is clickable is not necessarily enabled and
        /// clicking may not result in any page model response.  See
        /// <see cref="IsActionable(Microsoft.VisualStudio.TestTools.UITesting.UITestControl)"/>
        /// </remarks>
        public static bool IsNotClickable(this UITestControl toTest)
        {
            return !toTest.IsClickable();
        }

        /// <summary>
        /// Returns false if there is a point on the screen which can trigger
        /// the click action of this control; otherwise, true
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
        /// <remarks>
        /// An element which is clickable is not necessarily enabled and
        /// clicking may not result in any page model response.  See
        /// <see cref="IsActionable(Microsoft.VisualStudio.TestTools.UITesting.UITestControl, System.Nullable{int})"/>
        /// </remarks>
        public static bool IsNotClickable(this UITestControl toTest, int? wait)
        {
            if (wait.HasValue)
            {
                return toTest.IsNotClickable(x => x.WaitForControlNotExist(wait.Value));
            }
            return toTest.IsNotClickable();
        }

        /// <summary>
        /// Returns false if there is a point on the screen which can trigger
        /// the click action of this control; otherwise, true
        /// </summary>
        /// <param name="toTest">
        /// The element to test if it is clickable
        /// </param>
        /// <param name="condition"> 
        /// The predicate describing the control condition for which to wait
        /// before testing
        /// </param>
        /// <param name="wait">
        /// Time to wait for the control condition before returning false; if
        /// null, Playback.PlaybackSettings.WaitForReadyTimeout is used
        /// </param>
        /// <returns>
        /// False if there is a point on the screen which can trigger
        /// the click action of this control; otherwise, true
        /// </returns>
        /// <remarks>
        /// An element which is clickable is not necessarily enabled and
        /// clicking may not result in any page model response.  See
        /// <see cref="IsActionable(Microsoft.VisualStudio.TestTools.UITesting.UITestControl, System.Predicate{T}, System.Nullable{int})"/>
        /// </remarks>
        public static bool IsNotClickable<T>(this T toTest, Predicate<T> condition, int? wait = null) where T : UITestControl
        {
            if (!toTest.WaitForControlCondition(condition, wait))
            {
                //return false;
            }
            return toTest.IsNotClickable();
        }
        #endregion

        #region Actionable Helpers
        /// <summary>
        /// Returns true if this control is clickable and enabled; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to test if it is clickable and enabled
        /// </param>
        /// <returns>
        /// True if this control is clickable and enabled; otherwise, false
        /// </returns>
        public static bool IsActionable(this UITestControl toTest)
        {
            return toTest.IsClickable() && toTest.Enabled;
        }
        
        /// <summary>
        /// Returns true if this control is clickable and enabled; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to test if it is clickable and enabled
        /// </param>
        /// <param name="wait">
        /// Optional wait time in milliseconds to wait for the control to
        /// exist before trying to test for clickability and enabled status
        /// </param>
        /// <returns>
        /// True if this control is clickable and enabled; otherwise, false
        /// </returns>
        public static bool IsActionable(this UITestControl toTest, int? wait)
        {
            return toTest.IsClickable(wait) && toTest.Enabled;
        }

        /// <summary>
        /// Returns true if this control is clickable and enabled; otherwise, false
        /// </summary>
        /// <param name="toTest">
        /// The element to test if it is clickable and enabled
        /// </param>
        /// <param name="condition"> 
        /// The predicate describing the control condition for which to wait
        /// before testing
        /// </param>
        /// <param name="wait">
        /// Time to wait for the control condition before returning false; if
        /// null, Playback.PlaybackSettings.WaitForReadyTimeout is used
        /// </param>
        /// <returns>
        /// True if this control is clickable and enabled; otherwise, false
        /// </returns>
        public static bool IsActionable<T>(this T toTest, Predicate<T> condition, int? wait = null) where T : UITestControl
        {
            if (!toTest.WaitForControlCondition(condition, wait))
            {
                //return false;
            }
            return toTest.IsActionable();
        }

        /// <summary>
        /// Returns false if this control is clickable and enabled; otherwise, true
        /// </summary>
        /// <param name="toTest">
        /// The element to test if it is clickable and enabled
        /// </param>
        /// <returns>
        /// False if this control is clickable and enabled; otherwise, true
        /// </returns>
        public static bool IsNotActionable(this UITestControl toTest)
        {
            return !toTest.IsActionable();
        }

        /// <summary>
        /// Returns false if this control is clickable and enabled; otherwise, true
        /// </summary>
        /// <param name="toTest">
        /// The element to test if it is clickable and enabled
        /// </param>
        /// <param name="wait">
        /// Optional wait time in milliseconds to wait for the control to not
        /// exist before trying to test for clickability and enabled status
        /// </param>
        /// <returns>
        /// False if this control is clickable and enabled; otherwise, true
        /// </returns>
        public static bool IsNotActionable(this UITestControl toTest, int? wait)
        {
            return toTest.IsNotClickable(wait) || !toTest.Enabled;
        }

        /// <summary>
        /// Returns false if this control is clickable and enabled; otherwise, true
        /// </summary>
        /// <param name="toTest">
        /// The element to test if it is clickable and enabled
        /// </param>
        /// <param name="condition"> 
        /// The predicate describing the control condition for which to wait
        /// before testing
        /// </param>
        /// <param name="wait">
        /// Time to wait for the control condition before returning false; if
        /// null, Playback.PlaybackSettings.WaitForReadyTimeout is used
        /// </param>
        /// <returns>
        /// False if this control is clickable and enabled; otherwise, true
        /// </returns>
        public static bool IsNotActionable<T>(this T toTest, Predicate<T> condition, int? wait = null) where T : UITestControl
        {
            if (!toTest.WaitForControlCondition(condition, wait))
            {
                //return false;
            }
            return toTest.IsNotActionable();
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
            return new UIControlPageModelWrapper(current);
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
            return new ClickableControlPageModelWrapper<TNextModel>(current, nextModel);
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