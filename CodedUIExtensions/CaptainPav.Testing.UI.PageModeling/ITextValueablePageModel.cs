namespace CaptainPav.Testing.UI.PageModeling
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
    public interface ITextValueablePageModel<TValue, out TNextModel> : ITextValuedPageModel<TValue>, IValueablePageModel<TValue, TNextModel> where TNextModel : IPageModel
    {
        TNextModel SetValueText(string valueText);
    }
}