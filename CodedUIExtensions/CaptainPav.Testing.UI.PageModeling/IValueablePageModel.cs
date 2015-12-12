namespace CaptainPav.Testing.UI.PageModeling
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
        /// <summary>
        /// Sets the values of this page model, if possible
        /// </summary>
        /// <param name="toValue">
        /// The value to set into this page model
        /// </param>
        /// <returns>
        /// The most likely model with which the user will interact after
        /// setting this models value.
        /// </returns>
        TNextModel SetValue(TValue toValue);
    }
}