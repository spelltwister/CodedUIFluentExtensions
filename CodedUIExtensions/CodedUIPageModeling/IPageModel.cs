namespace CodedUIPageModeling
{
    /// <summary>
    /// Interface for interacting with page models
    /// </summary>
    public interface IPageModel
    {
        bool IsVisible(int? wait = null);
        bool IsHidden(int? wait = null);
        bool IsClickable(int? wait = null);
        bool IsNotClickable(int? wait = null);
    }
}