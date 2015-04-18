using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Convenience extensions to create standard page model adapters
    /// for standard WPF elements
    /// </summary>
    /// <remarks>
    /// The goal of these extensions is to provide page model wrappers
    /// which provide access to the semantics of the underlying
    /// WPF control
    /// </remarks>
    public static class WpfControlPageModelExtensions
    {
        public static IClickablePageModel<TNextModel> AsPageModel<TNextModel>(this WpfButton button, TNextModel nextModel) where TNextModel : IPageModel
        {
            return button.AsClickablePageModel(nextModel);
        }

        public static IClickablePageModel<TNextModel> AsPageModel<TNextModel>(this WpfHyperlink link, TNextModel nextModel) where TNextModel : IPageModel
        {
            return link.AsClickablePageModel(nextModel);
        }

        public static IClickablePageModel<TNextModel> AsPageModel<TNextModel>(this WpfToggleButton button, TNextModel nextModel) where TNextModel : IPageModel
        {
            return button.AsClickablePageModel(nextModel);
        }
        
        public static ISelectablePageModel<TNextModel> AsPageModel<TNextModel>(this WpfCheckBox checkbox, TNextModel nextModel) where TNextModel : IPageModel
        {
            return new WpfCheckboxControlPageModelWrapper<TNextModel>(checkbox, nextModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TNextModel"></typeparam>
        /// <param name="radioButton"></param>
        /// <param name="nextModel"></param>
        /// <returns></returns>
        /// <remarks>
        /// WPF Radio button is an ISelectablePageModel because you can
        /// set the selection state to false explicitly
        /// </remarks>
        public static ISelectablePageModel<TNextModel> AsPageModel<TNextModel>(this WpfRadioButton radioButton, TNextModel nextModel) 
            where TNextModel : IPageModel
        {
            return new WpfRadioButtonControlPageModelWrapper<TNextModel>(radioButton, nextModel);
        }
    }
}