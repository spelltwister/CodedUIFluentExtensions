namespace CaptainPav.Testing.UI.PageModeling.DialogPageModels
{
    /// <summary>
    /// Interface for page models which represent dialogs
    /// </summary>
    /// <typeparam name="TNextModel">
    /// The most likely model with which the user will interact after
    /// dismissing the dialog
    /// </typeparam>
    /// <remarks>
    /// The dialog being modeled here is a control which presents the user
    /// with some message
    /// </remarks>
    public interface IDialogPageModel : IPageModel
    {
        /// <summary>
        /// Gets the dialogs message to the user
        /// </summary>
        string Message { get; }

        ///// <summary>
        ///// Dismisses the dialog, if possible.  Dismissing the dialog should not
        ///// have a side effect.
        ///// </summary>
        ///// <returns>
        ///// The most likely model with which the user will interact after
        ///// dismissing the dialog
        ///// </returns>
        //TNextModel Dismiss();
    }
}
