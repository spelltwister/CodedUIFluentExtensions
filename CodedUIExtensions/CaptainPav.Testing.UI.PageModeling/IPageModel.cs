namespace CaptainPav.Testing.UI.PageModeling
{
    /// <summary>
    /// Page models describe the behaviors and observations of a user
    /// interface as seen by a client
    /// </summary>
    /// <remarks>
    /// All page models represent some component of a user interface.  Because
    /// of this, there is not really the concept of a <code>null</code> model.
    /// Instead, page models can be tested for whether they are currently
    /// available to a client and whether or not that client can interact with
    /// the modeled component.
    /// </remarks>
    public interface IPageModel
    {
        /// <summary>
        /// Tries to find the control and returns true if the model can be
        /// found - regardless of whether or not the end user is able to
        /// interact with the modeled page
        /// </summary>
        /// <param name="wait">
        /// [Optional] Time to wait for the control to be found
        /// </param>
        /// <returns>
        /// True if the model can be found; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element that is &quot;display: none&quot; will still be found by
        /// this method.  The only way for it to return false would
        /// be that element does not exist anywhere in the page.
        /// </remarks>
        bool CanFind(int? wait = null);

        /// <summary>
        /// Tries to find the control and returns true if the model
        /// cannot be found
        /// </summary>
        /// <param name="wait">
        /// [Optional] Time to wait for the control to not be found
        /// </param>
        /// <returns>
        /// True if the control cannot be found
        /// </returns>
        /// <remarks>
        /// While this is the opposite of CanFind, they may not
        /// have inverse results.  CanNotFind will wait for the element
        /// to disappear if the wait time is specified.  !CanFind
        /// would return incorrectly as the element could be found,
        /// though it was transitioning out of the page.
        /// </remarks>
        bool CanNotFind(int? wait = null);

        /// <summary>
        /// Returns true if the element is Visible
        /// </summary>
        /// <param name="wait">
        /// [Optional] Time to wait for the control to become visible
        /// </param>
        /// <returns>
        /// True if the control is visible; otherwise, false
        /// </returns>
        /// <remarks>
        /// An element is considered visible if it is able to be found and has
        /// non-zero width and height.  This does not mean that the controls is
        /// necessarily in view (eg, the control may not actually be able to
        /// be seen due to being off screen or blocked).
        /// </remarks>
        bool IsVisible(int? wait = null);

        /// <summary>
        /// Returns true if the element is hidden
        /// </summary>
        /// <param name="wait">
        /// [Optional] Time to wait for the control to hide
        /// </param>
        /// <returns>
        /// True if the control is hidden; otherwise, false
        /// </returns>
        /// <remarks>
        /// An off screen or blocked element is not technically hidden
        /// </remarks>
        bool IsHidden(int? wait = null);

        /// <summary>
        /// Returns true if the element is clickable
        /// </summary>
        /// <param name="wait">
        /// [Optional] Time to wait for the control to become clickable
        /// </param>
        /// <returns>
        /// True if the control is clickable; otherwise, false
        /// </returns>
        /// <remarks>
        /// Any element that has a clickable point on the screen can be clicked
        /// regardless of whether that click causes an action to occur.  This is
        /// especially important for buttons or other elements that can be
        /// disabled; a disabled button can still be clicked, but the
        /// click will not raise the click handler of the button.
        /// 
        /// Some controls do not logically take up space in the UI.
        /// For instance, a table does not have a clickable point; the rows
        /// and cells in the table are clickable.
        /// </remarks>
        bool IsClickable(int? wait = null);

        /// <summary>
        /// Returns true if the element is not clickable
        /// </summary>
        /// <param name="wait">
        /// [Optional] Time to wait for the control to become not clickable
        /// </param>
        /// <returns>
        /// True if the element is not clickable; otherwise, false
        /// </returns>
        bool IsNotClickable(int? wait = null);

        /// <summary>
        /// Returns true if the control is Actionable (both
        /// clickable and enabled)
        /// </summary>
        /// <param name="wait">
        /// [Optional] Time to wait for the control to become actionable
        /// </param>
        /// <returns>
        /// True if the control is Actionable (both clickable and enabled);
        /// otherwise, false
        /// </returns>
        /// <remarks>
        /// Because some controls are not clickable <see cref="IsClickable"/>,
        /// those controls are also not actionable.
        /// </remarks>
        bool IsActionable(int? wait = null);

        /// <summary>
        /// Returns true if the control is not Actionable (not clickable, not
        /// enabled, or both)
        /// </summary>
        /// <param name="wait">
        /// [Optional] Time to wait for the control to become not Actionable
        /// </param>
        /// <returns>
        /// True if the control is not Actionable (not clickable, not enabled,
        /// or both)
        /// </returns>
        bool IsNotActionable(int? wait = null);
    }
}