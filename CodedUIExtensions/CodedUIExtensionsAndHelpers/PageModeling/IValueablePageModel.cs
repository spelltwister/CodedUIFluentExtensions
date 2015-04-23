namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Interface describing page models which have values displyed
    /// to the user
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value stored in the model
    /// </typeparam>
    public interface IValuedPageModel<out TValue>
    {
        /// <summary>
        /// Gets the value of this page model converted to its value type
        /// </summary>
        TValue Value { get; }
    }

    /// <summary>
    /// Interface describing page models which can read or write a value
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value stored in the model
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// Type of model returned after setting the value of this page model
    /// </typeparam>
    public interface IValueablePageModel<TValue, out TNextModel> : IValuedPageModel<TValue> where TNextModel : IPageModel
    {
        TNextModel SetValue(TValue toValue);
    }

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