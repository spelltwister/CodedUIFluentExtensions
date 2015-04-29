namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Interface describing page models which can both observe a value and
    /// have a behavior for setting a value
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value observable in the model
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// Type of model returned after setting the value of this page model
    /// </typeparam>
    public interface IValueablePageModel<TValue, out TNextModel> : IValuedPageModel<TValue> where TNextModel : IPageModel
    {
        TNextModel SetValue(TValue toValue);
    }
}