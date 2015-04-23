namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Interface for page model which can be considered seleted or not
    /// </summary>
    /// <typeparam name="TNextModel"></typeparam>
    public interface ISelectablePageModel<out TNextModel> : IValueablePageModel<bool, TNextModel> where TNextModel : IPageModel
    {
        bool IsSelected { get; }

        TNextModel SetSelected(bool selectionState);
    }
}