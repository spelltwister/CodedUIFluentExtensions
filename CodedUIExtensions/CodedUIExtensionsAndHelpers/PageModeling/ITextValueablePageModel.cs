namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Interface describing page models which have a textual representation
    /// that is displayed to the user
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value stored in the model
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// Type of model returned after setting the value of this model
    /// </typeparam>
    public interface ITextValueablePageModel<TValue, out TNextModel> : IValueablePageModel<TValue, TNextModel> where TNextModel : IPageModel
    {
        /// <summary>
        /// Gets the value text displayed to the user
        /// </summary>
        /// <remarks>
        /// This string representation can be used to validate formatting of
        /// the value type stored in this page model
        /// </remarks>
        string ValueText { get; }

        TNextModel SetValueText(string valueText);
    }
}