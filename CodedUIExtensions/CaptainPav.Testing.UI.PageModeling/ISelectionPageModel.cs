using System.Collections.Generic;

namespace CaptainPav.Testing.UI.PageModeling
{
    public interface ISelectionPageModel<out TValue, out TNextModel, out TListItem> : IPageModel // TODO: THIS IS NOT DONE
        where TNextModel : IPageModel
        where TListItem : ISelectablePageModel<TNextModel>, IValuedPageModel<TValue>
    {
        TListItem SelectedItem { get; }
        IEnumerable<TListItem> Items { get; }
    }

    public interface INameSelectionPageModel<out TValue, out TNextModel, out TListItem> : ISelectionPageModel<TValue, TNextModel, TListItem>, INamedPageModel
        where TNextModel : IPageModel
        where TListItem : ISelectablePageModel<TNextModel>, IValuedPageModel<TValue>, INamedPageModel
    {
    }
}