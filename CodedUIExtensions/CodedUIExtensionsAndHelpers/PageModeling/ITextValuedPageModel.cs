namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Interface describing page models which have an observable value
    /// which is also displayed to the user as text
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value observable in the model
    /// </typeparam>
    public interface ITextValuedPageModel<out TValue> : IValuedPageModel<TValue>
    {
        /// <summary>
        /// Gets the value text displayed to the user
        /// </summary>
        /// <remarks>
        /// This string representation can be used to validate formatting of
        /// the value type stored in this page model
        /// </remarks>

        string ValueText { get; }
    }
}