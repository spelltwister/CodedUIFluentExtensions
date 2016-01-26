namespace CaptainPav.Testing.UI.PageModeling
{
    /// <summary>
    /// Interface describing page models which have a behavior for
    /// setting a value
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value observable in the model
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// Type of model returned after setting the value of this page model
    /// </typeparam>
    /// <remarks>
    /// This interface provides a means of writing a value to the page model.
    /// Most writable models will also have read semantics.
    /// 
    /// A password input could be an example of a write only input.  While the
    /// system may be able to read the password value, the user would not be
    /// able as the text would be obscured.
    /// </remarks>
    public interface IValueablePageModel<in TValue, out TNextModel> : IPageModel where TNextModel : IPageModel
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