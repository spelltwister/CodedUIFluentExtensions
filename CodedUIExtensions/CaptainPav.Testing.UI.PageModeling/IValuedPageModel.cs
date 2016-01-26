namespace CaptainPav.Testing.UI.PageModeling
{
    /// <summary>
    /// Interface describing page models which have an observable value
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value observable in the model
    /// </typeparam>
    /// <remarks>
    /// This interface provides a means of reading a value from the page model
    /// </remarks>
    public interface IValuedPageModel<out TValue> : IPageModel
    {
        /// <summary>
        /// Gets the value of this page model converted to its value type
        /// </summary>
        TValue Value { get; }
    }
}