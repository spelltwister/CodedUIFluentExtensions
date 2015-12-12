namespace CaptainPav.Testing.UI.PageModeling.DialogPageModels
{
    /// <summary>
    /// Specialized page model that represents a dialog which can only
    /// be acknowledged
    /// </summary>
    public interface IAlertPageModel<out T> : IDialogPageModel where T : IPageModel
    {
        /// <summary>
        /// Acknowledges the alert and returns the next model
        /// </summary>
        /// <returns></returns>
        T Acknowledge();
    }
}