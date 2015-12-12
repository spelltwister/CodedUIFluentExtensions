namespace CaptainPav.Testing.UI.PageModeling.DialogPageModels
{
    /// <summary>
    /// Specialized 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IProgressDialogPageModel<out T> : ICancellablePageModel<T> where T : IPageModel
    {
        /// <summary>
        /// Gets the value of the progress bar as a decimal from 0 to 1.
        /// </summary>
        double Progress { get; }
    }
}