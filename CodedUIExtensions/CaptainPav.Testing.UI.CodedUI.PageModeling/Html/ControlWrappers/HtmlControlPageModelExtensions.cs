using System;
using CaptainPav.Testing.UI.CodedUI.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers
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

        public static IValuedPageModel<string> AsStringValuedPageModel<T>(this T htmlControl) where T : HtmlControl
        {
            return new HtmlStringValuedControlPageModelWrapper<T>(htmlControl);
        }

        public static ITextValuedPageModel<TValue> AsTextValuedPageModel<T, TValue>(this T htmlControl, Func<string, TValue> stringToValueFunc, Func<T, string> controlToStringFunc) where T : HtmlControl
        {
            return new HtmlTextValuedControlPageModelWrapper<T, TValue>(htmlControl, stringToValueFunc, controlToStringFunc);
        }

        public static ITextValuedPageModel<TValue> AsTextValuedPageModel<T, TValue>(this T htmlControl, Func<string, TValue> stringToValueFunc) where T : HtmlControl
        {
            return new HtmlTextValuedControlPageModelWrapper<T, TValue>(htmlControl, stringToValueFunc);
        }

        #region Read Write Text Value Extensions
        public static IReadWriteTextValuePageModel<TValue, TNextModel> AsPageModel<TNextModel, TValue>(this HtmlEdit textBox, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc) where TNextModel : IPageModel
        {
            return new HtmlTextboxControlPageModelWrapper<TValue, TNextModel>(textBox, nextModel, stringToValueFunc, valueToStringFunc);
        }

        public static IReadWriteTextValuePageModel<string, TNextModel> AsPageModel<TNextModel>(this HtmlEdit textBox, TNextModel nextModel) where TNextModel : IPageModel
        {
            return textBox.AsPageModel(nextModel, StandardFunctionProvider.StringReturnSelf, StandardFunctionProvider.StringReturnSelf);
        }

        public static IReadWriteTextValuePageModel<TValue, TNextModel> AsPageModel<TNextModel, TValue>(this HtmlEditableDiv div, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc) where TNextModel : IPageModel
        {
            return new HtmlEditableDivControlPageModelWrapper<TValue, TNextModel>(div, nextModel, stringToValueFunc, valueToStringFunc);
        }

        public static IReadWriteTextValuePageModel<string, TNextModel> AsPageModel<TNextModel>(this HtmlEditableDiv div, TNextModel nextModel) where TNextModel : IPageModel
        {
            return div.AsPageModel(nextModel, StandardFunctionProvider.StringReturnSelf, StandardFunctionProvider.StringReturnSelf);
        }

        public static IReadWriteTextValuePageModel<TValue, TNextModel> AsPageModel<TNextModel, TValue>(this HtmlEditableSpan span, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc) where TNextModel : IPageModel
        {
            return new HtmlEditableSpanControlPageModelWrapper<TValue, TNextModel>(span, nextModel, stringToValueFunc, valueToStringFunc);
        }

        public static IReadWriteTextValuePageModel<string, TNextModel> AsPageModel<TNextModel>(this HtmlEditableSpan span, TNextModel nextModel) where TNextModel : IPageModel
        {
            return span.AsPageModel(nextModel, StandardFunctionProvider.StringReturnSelf, StandardFunctionProvider.StringReturnSelf);
        }

        public static IReadWriteTextValuePageModel<TValue, TNextModel> AsPageModel<TNextModel, TValue>(this HtmlTextArea textArea, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc) where TNextModel : IPageModel
        {
            return new HtmlTextAreaControlPageModelWrapper<TValue, TNextModel>(textArea, nextModel, stringToValueFunc, valueToStringFunc);
        }

        public static IReadWriteTextValuePageModel<string, TNextModel> AsPageModel<TNextModel>(this HtmlTextArea textArea, TNextModel nextModel) where TNextModel : IPageModel
        {
            return textArea.AsPageModel(nextModel, StandardFunctionProvider.StringReturnSelf, StandardFunctionProvider.StringReturnSelf);
        }
        #endregion

        public static ITextValuedPageModel<string> AsPageModel(this HtmlAbbreviation abbreviation)
        {
            return new HtmlAbbreviationControlPageModelWrapper(abbreviation);
        }

        public static ITextValuedPageModel<TValue> AsPageModel<TValue>(this HtmlCell cell, Func<string, TValue> stringToValueFunc, Func<HtmlCell, string> cellToStringFunc)
        {
            return new HtmlCellControlPageModelWrapper<TValue>(cell, stringToValueFunc, cellToStringFunc);
        }

        public static ITextValuedPageModel<TValue> AsPageModel<TValue>(this HtmlCell cell, Func<string, TValue> stringToValueFunc)
        {
            return new HtmlCellControlPageModelWrapper<TValue>(cell, stringToValueFunc);
        }

        public static ITextValuedPageModel<string> AsPageModel(this HtmlCell cell,  Func<HtmlCell, string> cellToStringFunc)
        {
            return cell.AsPageModel(StandardFunctionProvider.StringReturnSelf, cellToStringFunc);
        }

        public static ITextValuedPageModel<string> AsPageModel(this HtmlCell cell)
        {
            // NOTE: do not return AsStringValuedPageModel since
            // the cell has a property specifically for the value text
            return cell.AsPageModel(StandardFunctionProvider.StringReturnSelf);
        } 

        public static ISelectionPageModel<TValue, TNextModel, HtmlComboBoxItemControlPageModelWrapper<TValue, TNextModel>> AsPageModel<TNextModel, TValue>(this HtmlComboBox comboBox, TNextModel nextModel, Func<string, TValue> stringToValue, Func<TValue, string> valueToString) where TNextModel : IPageModel
        {
            return new HtmlComboBoxControlPageModelWrapper<TValue, TNextModel>(comboBox, nextModel, stringToValue, valueToString);
        }

        public static ISelectionPageModel<string, TNextModel, HtmlComboBoxItemControlPageModelWrapper<TNextModel>> AsPageModel<TNextModel>(this HtmlComboBox comboBox, TNextModel nextModel) where TNextModel : IPageModel
        {
            return new HtmlComboBoxControlPageModelWrapper<TNextModel>(comboBox, nextModel, StandardFunctionProvider.StringReturnSelf, StandardFunctionProvider.StringReturnSelf);
        }
    }
}