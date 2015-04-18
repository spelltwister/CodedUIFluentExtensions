using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Convenience extensions to create standard page model adapters
    /// for standard HTML elements
    /// </summary>
    /// <remarks>
    /// The goal of these extensions is to provide page model wrappers
    /// which provide access to the semantics of the underlying
    /// HTML control
    /// </remarks>
    public static class HtmlControlPageModelExtensions
    {
        public static IClickablePageModel<TNextModel> AsPageModel<TNextModel>(this HtmlAreaHyperlink link, TNextModel nextModel) where TNextModel : IPageModel
        {
            return link.AsClickablePageModel(nextModel);
        }

        public static IClickablePageModel<TNextModel> AsPageModel<TNextModel>(this HtmlButton button, TNextModel nextModel) where TNextModel : IPageModel
        {
            return button.AsClickablePageModel(nextModel);
        }

        public static IClickablePageModel<TNextModel> AsPageModel<TNextModel>(this HtmlHyperlink link, TNextModel nextModel) where TNextModel : IPageModel
        {
            return link.AsClickablePageModel(nextModel);
        }

        public static IClickablePageModel<TNextModel> AsPageModel<TNextModel>(this HtmlInputButton button, TNextModel nextModel) where TNextModel : IPageModel
        {
            return button.AsClickablePageModel(nextModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TNextModel"></typeparam>
        /// <param name="radioButton"></param>
        /// <param name="nextModel"></param>
        /// <returns></returns>
        /// <remarks>
        /// Radio button is not an ISelectablePageModel because you cannot
        /// set the selection state to false explicitly
        /// </remarks>
        public static IClickablePageModel<TNextModel> AsPageModel<TNextModel>(this HtmlRadioButton radioButton, TNextModel nextModel) where TNextModel : IPageModel
        {
            return radioButton.AsClickablePageModel(nextModel);
        }

        public static ISelectablePageModel<TNextModel> AsPageModel<TNextModel>(this HtmlCheckBox checkbox, TNextModel nextModel) where TNextModel : IPageModel
        {
            return new HtmlCheckboxControlPageModelWrapper<TNextModel>(checkbox, nextModel);
        }
    }
}