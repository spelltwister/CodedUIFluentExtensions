using System.Collections.Generic;

namespace CaptainPav.Testing.UI.PageModeling
{
    public interface ISelectionPageModel<TValue, out TNextModel> : ITextValueablePageModel<TValue, TNextModel> where TNextModel : IPageModel
    {
        INamedSelectablePageModel<TNextModel> SelectedItem { get; }

        IEnumerable<INamedSelectablePageModel<TNextModel>> Items { get; }
    }
}