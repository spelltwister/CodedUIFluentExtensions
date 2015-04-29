using System;
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
        public static readonly Func<string, string> StringReturnSelfFunc = (inString) => inString;

        #region Clickable Extensions
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
        #endregion

        public static ISelectablePageModel<TNextModel> AsPageModel<TNextModel>(this HtmlCheckBox checkbox, TNextModel nextModel) where TNextModel : IPageModel
        {
            return new HtmlCheckboxControlPageModelWrapper<TNextModel>(checkbox, nextModel);
        }

        #region Text Valuable Extensions
        public static ITextValueablePageModel<TValue, TNextModel> AsPageModel<TNextModel, TValue>(this HtmlEdit textBox, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc) where TNextModel : IPageModel
        {
            return new HtmlTextboxControlPageModelWrapper<TValue, TNextModel>(textBox, nextModel, stringToValueFunc, valueToStringFunc);
        }

        public static ITextValueablePageModel<string, TNextModel> AsPageModel<TNextModel>(this HtmlEdit textBox, TNextModel nextModel) where TNextModel : IPageModel
        {
            return textBox.AsPageModel(nextModel, StringReturnSelfFunc, StringReturnSelfFunc);
        }

        public static ITextValueablePageModel<TValue, TNextModel> AsPageModel<TNextModel, TValue>(this HtmlEditableDiv div, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc) where TNextModel : IPageModel
        {
            return new HtmlEditableDivControlPageModelWrapper<TValue, TNextModel>(div, nextModel, stringToValueFunc, valueToStringFunc);
        }

        public static ITextValueablePageModel<string, TNextModel> AsPageModel<TNextModel>(this HtmlEditableDiv div, TNextModel nextModel) where TNextModel : IPageModel
        {
            return div.AsPageModel(nextModel, StringReturnSelfFunc, StringReturnSelfFunc);
        }

        public static ITextValueablePageModel<TValue, TNextModel> AsPageModel<TNextModel, TValue>(this HtmlEditableSpan span, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc) where TNextModel : IPageModel
        {
            return new HtmlEditableSpanControlPageModelWrapper<TValue, TNextModel>(span, nextModel, stringToValueFunc, valueToStringFunc);
        }

        public static ITextValueablePageModel<string, TNextModel> AsPageModel<TNextModel>(this HtmlEditableSpan span, TNextModel nextModel) where TNextModel : IPageModel
        {
            return span.AsPageModel(nextModel, StringReturnSelfFunc, StringReturnSelfFunc);
        }

        public static ITextValueablePageModel<TValue, TNextModel> AsPageModel<TNextModel, TValue>(this HtmlTextArea textArea, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc) where TNextModel : IPageModel
        {
            return new HtmlTextAreaControlPageModelWrapper<TValue, TNextModel>(textArea, nextModel, stringToValueFunc, valueToStringFunc);
        }

        public static ITextValueablePageModel<string, TNextModel> AsPageModel<TNextModel>(this HtmlTextArea textArea, TNextModel nextModel) where TNextModel : IPageModel
        {
            return textArea.AsPageModel(nextModel, StringReturnSelfFunc, StringReturnSelfFunc);
        }
        #endregion

        public static ISelectionPageModel<TValue, TNextModel> AsPageModel<TNextModel, TValue>(this HtmlComboBox comboBox, TNextModel nextModel, Func<string, TValue> stringToValue, Func<TValue, string> valueToString) where TNextModel : IPageModel
        {
            return new HtmlComboBoxControlPageModelWrapper<TValue, TNextModel>(comboBox, nextModel, stringToValue, valueToString);
        }

        public static ISelectionPageModel<string, TNextModel> AsPageModel<TNextModel>(this HtmlComboBox comboBox, TNextModel nextModel) where TNextModel : IPageModel
        {
            return new HtmlComboBoxControlPageModelWrapper<string, TNextModel>(comboBox, nextModel, StringReturnSelfFunc, StringReturnSelfFunc);
        }
    }
}