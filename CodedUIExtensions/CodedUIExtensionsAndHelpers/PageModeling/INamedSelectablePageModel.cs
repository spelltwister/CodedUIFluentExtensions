namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public interface INamedSelectablePageModel<out TNextModel> : ISelectablePageModel<TNextModel> where TNextModel : IPageModel
    {
        string Name { get; }
    }
}