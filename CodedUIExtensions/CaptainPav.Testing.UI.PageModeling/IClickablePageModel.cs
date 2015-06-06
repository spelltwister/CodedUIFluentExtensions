namespace CaptainPav.Testing.UI.PageModeling
{
    /// <summary>
    /// Interface for page model which have a logical click action assoricated
    /// </summary>
    /// <typeparam name="TNextModel"></typeparam>
    public interface IClickablePageModel<out TNextModel> : IPageModel where TNextModel : IPageModel
    {
        TNextModel Click();
    }
}