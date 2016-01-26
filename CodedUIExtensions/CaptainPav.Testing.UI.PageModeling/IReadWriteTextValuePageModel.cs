namespace CaptainPav.Testing.UI.PageModeling
{
    /// <summary>
    /// Interface describing page models which have a text formatted
    /// representation that the user may use to set the value text
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value stored in the model
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// Type of model returned after setting the value of this model
    /// using the text formatted representation
    /// </typeparam>
    public interface IReadWriteTextValuePageModel<TValue, out TNextModel> : ITextValuedPageModel<TValue>, ITextValueablePageModel<TValue, TNextModel>
        where TNextModel : IPageModel
    {
    }
}