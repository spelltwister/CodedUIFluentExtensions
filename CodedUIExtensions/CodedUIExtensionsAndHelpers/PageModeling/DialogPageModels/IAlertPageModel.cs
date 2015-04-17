namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Specialized page model that represents a dialog which can only
    /// be acknowledged
    /// </summary>
    public interface IAlertPageModel : IPageModel
    {
        /// <summary>
        /// Acknowledges the alert and returns the next model
        /// </summary>
        /// <returns></returns>
        IPageModel Acknowledge();
    }
}