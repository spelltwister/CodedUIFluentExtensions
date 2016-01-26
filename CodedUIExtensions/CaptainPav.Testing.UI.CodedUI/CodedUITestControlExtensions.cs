using System;

using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI
{
    public static class CodedUITestControlExtensions
    {
        /// <summary>
        /// Blocks the current thread until the specified condition is met, or until the specified time-out expires.
        /// </summary>
        /// 
        /// <returns>
        /// true if the condition is met before the time-out; otherwise, false.
        /// </returns>
        /// <param name="conditionContext">The context to evaluate the condition.</param>
        /// <param name="conditionEvaluator">The delegate to evaluate the condition.</param>
        /// <param name="millisecondsTimeout">The number of milliseconds before time-out; if null, Playback.PlaybackSettings.WaitForReadyTimeout is used.</param>
        /// <typeparam name="T">The <see cref="T:System.Type"/> that specifies the Type for the condition and predicate.</typeparam>
        public static bool WaitForControlCondition<T>(this T conditionContext, Predicate<T> conditionEvaluator, int? millisecondsTimeout = null)
        {
            return UITestControl.WaitForCondition(conditionContext, conditionEvaluator, millisecondsTimeout ?? Playback.PlaybackSettings.WaitForReadyTimeout);
        }

        /// <summary>
        /// Returns true if can clickable point can be found for this control
        /// </summary>
        /// <param name="control">
        /// The control for which to find a clickable point
        /// </param>
        /// <returns>
        /// True if can clickable point can be found for this control;
        /// otherwise, false
        /// </returns>
        public static bool CanGetClickablePoint(this UITestControl control)
        {
            System.Drawing.Point p;
            return control.TryGetClickablePoint(out p);
        }
    }
}
