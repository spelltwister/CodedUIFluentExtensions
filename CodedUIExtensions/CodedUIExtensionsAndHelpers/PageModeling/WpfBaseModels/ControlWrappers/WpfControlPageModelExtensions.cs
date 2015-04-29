using System;
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
        public static readonly Func<string, string> StringReturnSelfFunc = (inString) => inString;

        #region Clickable Extensions
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
        #endregion

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
        public static ISelectablePageModel<TNextModel> AsPageModel<TNextModel>(this WpfRadioButton radioButton, TNextModel nextModel) where TNextModel : IPageModel
        {
            return new WpfRadioButtonControlPageModelWrapper<TNextModel>(radioButton, nextModel);
        }

        #region Text Valuable Extensions
        public static ITextValueablePageModel<TValue, TNextModel> AsPageModel<TNextModel, TValue>(this WpfEdit textBox, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc) where TNextModel : IPageModel
        {
            return new WpfTextboxControlPageModelWrapper<TValue, TNextModel>(textBox, nextModel, stringToValueFunc, valueToStringFunc);
        }

        public static ITextValueablePageModel<string, TNextModel> AsPageModel<TNextModel>(this WpfEdit textBox, TNextModel nextModel) where TNextModel : IPageModel
        {
            return textBox.AsPageModel(nextModel, StringReturnSelfFunc, StringReturnSelfFunc);
        }
        #endregion

        public static ISelectionPageModel<TValue, TNextModel> AsPageModel<TNextModel, TValue>(this WpfComboBox combobox, TNextModel nextModel, Func<string, TValue> stringToValue, Func<TValue, string> valueToString) where TNextModel : IPageModel
        {
            return new WpfComboBoxControlPageModelWrapper<TValue, TNextModel>(combobox, nextModel, stringToValue, valueToString);
        }

        public static ISelectionPageModel<string, TNextModel> AsPageModel<TNextModel>(this WpfComboBox comboBox, TNextModel nextModel) where TNextModel : IPageModel
        {
            return comboBox.AsPageModel(nextModel, StringReturnSelfFunc, StringReturnSelfFunc);
        } 
    }
}