namespace CaptainPav.Testing.UI.PageModeling
{
    /// <summary>
    /// Interface describing page models which have a behavior for
    /// both getting and setting a value
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value observable in the model
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// Type of model returned after setting the value of this page model
    /// </typeparam>
    /// <remarks>
    /// Most writable models will also have read semantics.
    /// </remarks>
    public interface IReadWriteValuePageModel<TValue, out TNextModel> : IValuedPageModel<TValue>, IValueablePageModel<TValue, TNextModel>
        where TNextModel : IPageModel
    {
    }
}
