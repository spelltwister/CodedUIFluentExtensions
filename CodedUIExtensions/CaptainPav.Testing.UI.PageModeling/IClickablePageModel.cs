namespace CaptainPav.Testing.UI.PageModeling
{
    /// <summary>
    /// Interface for page model which have a logical click action assoricated
    /// </summary>
    /// <typeparam name="TNextModel">
    /// The most likely model with which the user will interact as a result of
    /// clicking this page model
    /// </typeparam>
    public interface IClickablePageModel<out TNextModel> : IPageModel where TNextModel : IPageModel
    {
        /// <summary>
        /// Performs a click action against the page model
        /// </summary>
        /// <returns>
        /// The most like model with which the user will interact after the
        /// click action is performed
        /// </returns>
        TNextModel Click();
    }
}