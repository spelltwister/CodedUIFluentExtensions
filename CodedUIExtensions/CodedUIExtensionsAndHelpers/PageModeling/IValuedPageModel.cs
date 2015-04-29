namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Interface describing page models which have an observable value
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value observable in the model
    /// </typeparam>
    public interface IValuedPageModel<out TValue> : IPageModel
    {
        /// <summary>
        /// Gets the value of this page model converted to its value type
        /// </summary>
        TValue Value { get; }
    }
}