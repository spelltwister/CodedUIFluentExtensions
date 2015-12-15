using System.Collections.Generic;

namespace CaptainPav.Testing.UI.PageModeling
{
    /// <summary>
    /// Interface for page model which present a list of options to the user
    /// for selection
    /// </summary>
    /// <typeparam name="TValue">
    /// The type of the values in the list
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// The most likely page model with which the user will interact after
    /// setting the selected values of this page model.
    /// </typeparam>
    public interface ISelectionPageModel<TValue, out TNextModel> : ITextValueablePageModel<TValue, TNextModel> where TNextModel : IPageModel
    {
        INamedSelectablePageModel<TNextModel> SelectedItem { get; }

        /// <summary>
        /// Gets the list of selectable items contained in this page model
        /// </summary>
        IEnumerable<INamedSelectablePageModel<TNextModel>> Items { get; }
    }
}