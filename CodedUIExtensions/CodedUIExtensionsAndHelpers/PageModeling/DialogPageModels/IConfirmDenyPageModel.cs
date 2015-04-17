namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Specialized page model that represents a dialog that asks the
    /// user a yes/no type of question
    /// </summary>
    public interface IConfirmDenyPageModel : IPageModel
    {
        /// <summary>
        /// Confirms the dialog and returns the next model
        /// </summary>
        /// <returns></returns>
        IPageModel Confirm();

        /// <summary>
        /// Denies the dialog and returns the next model
        /// </summary>
        /// <returns></returns>
        IPageModel Deny();
    }
}