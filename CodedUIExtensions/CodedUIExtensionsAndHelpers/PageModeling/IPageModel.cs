namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Interface for interacting with page models
    /// </summary>
    public interface IPageModel
    {
        bool CanFind(int? wait = null);
        bool CanNotFind(int? wait = null);
        bool IsVisible(int? wait = null);
        bool IsHidden(int? wait = null);
        bool IsClickable(int? wait = null);
        bool IsNotClickable(int? wait = null);
        bool IsActionable(int? wait = null);
        bool IsNotActionable(int? wait = null);
    }
}