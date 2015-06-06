namespace CaptainPav.Testing.UI.PageModeling.DialogPageModels
{
    /// <summary>
    /// Specialized page model that represents a dialog that asks the
    /// user a yes/no type of question
    /// </summary>
    public interface IConfirmDenyPageModel<out TConfirm, out TDeny> : IPageModel where TConfirm : IPageModel where TDeny : IPageModel
    {
        /// <summary>
        /// Confirms the dialog and returns the next model
        /// </summary>
        /// <returns></returns>
        TConfirm Confirm();

        /// <summary>
        /// Denies the dialog and returns the next model
        /// </summary>
        /// <returns></returns>
        TDeny Deny();
    }
}