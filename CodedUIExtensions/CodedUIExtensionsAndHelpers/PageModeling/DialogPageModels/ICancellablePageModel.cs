namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Specialized page model that represents a dialog that asks the
    /// user if they would like to cancel and action
    /// </summary>
    public interface ICancellablePageModel<out T> : IPageModel where T : IPageModel
    {
        /// <summary>
        /// Cancels the action and returns the next model
        /// </summary>
        /// <returns></returns>
        T Cancel();
    }
}