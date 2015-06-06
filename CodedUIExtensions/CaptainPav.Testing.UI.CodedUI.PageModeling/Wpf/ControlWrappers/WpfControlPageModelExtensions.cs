using System;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf.ControlWrappers
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

        #region Selectable Extensions
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
        #endregion

        #region Selection Extensions
        public static ISelectionPageModel<TValue, TNextModel> AsPageModel<TNextModel, TValue>(this WpfComboBox combobox, TNextModel nextModel, Func<string, TValue> stringToValue, Func<TValue, string> valueToString) where TNextModel : IPageModel
        {
            return new WpfComboBoxControlPageModelWrapper<TValue, TNextModel>(combobox, nextModel, stringToValue, valueToString);
        }

        public static ISelectionPageModel<string, TNextModel> AsPageModel<TNextModel>(this WpfComboBox comboBox, TNextModel nextModel) where TNextModel : IPageModel
        {
            return comboBox.AsPageModel(nextModel, StandardFunctionProvider.StringReturnSelf, StandardFunctionProvider.StringReturnSelf);
        }
        #endregion

        #region Text Valuable Extensions
        public static ITextValueablePageModel<DateTime?, TNextModel> AsPageModel<TNextModel>(this WpfDatePicker datePicker, TNextModel nextModel, Func<string, DateTime?> stringToValueFunc, Func<DateTime?, string> valueToStringFunc) where TNextModel : IPageModel
        {
            return new WpfDatePickerControlPageModelWrapper<TNextModel>(datePicker, nextModel, stringToValueFunc, valueToStringFunc);
        }

        public static ITextValueablePageModel<TValue, TNextModel> AsPageModel<TNextModel, TValue>(this WpfEdit textBox, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc) where TNextModel : IPageModel
        {
            return new WpfTextboxControlPageModelWrapper<TValue, TNextModel>(textBox, nextModel, stringToValueFunc, valueToStringFunc);
        }

        public static ITextValueablePageModel<string, TNextModel> AsPageModel<TNextModel>(this WpfEdit textBox, TNextModel nextModel) where TNextModel : IPageModel
        {
            return textBox.AsPageModel(nextModel, StandardFunctionProvider.StringReturnSelf, StandardFunctionProvider.StringReturnSelf);
        }
        #endregion

        public static IValueablePageModel<double, TNextModel> AsPageModel<TNextModel>(WpfSlider slider, TNextModel nextModel) where TNextModel : IPageModel
        {
            return new WpfSliderControlPageModelWrapper<TNextModel>(slider, nextModel);
        }

        public static IValuedPageModel<double> AsPageModel(this WpfProgressBar progressBar)
        {
            return new WpfProgressBarControlPageModelWrapper(progressBar);
        }

        #region Valued Extensions
        public static ITextValuedPageModel<TValue> AsPageModel<TValue>(this WpfCell cell, Func<string, TValue> stringToValueFunc, Func<WpfCell, string> cellToStringFunc)
        {
            return new WpfCellControlPageModelWrapper<TValue>(cell, stringToValueFunc, cellToStringFunc);
        }

        public static ITextValuedPageModel<TValue> AsPageModel<TValue>(this WpfCell cell, Func<string, TValue> stringToValueFunc)
        {
            return new WpfCellControlPageModelWrapper<TValue>(cell, stringToValueFunc);
        }

        public static ITextValuedPageModel<string> AsPageModel(this WpfCell cell, Func<WpfCell, string> cellToStringFunc)
        {
            return cell.AsPageModel(StandardFunctionProvider.StringReturnSelf, cellToStringFunc);
        }

        public static ITextValuedPageModel<string> AsPageModel(this WpfCell cell)
        {
            return cell.AsPageModel(StandardFunctionProvider.StringReturnSelf);
        }

        public static ITextValuedPageModel<TValue> AsPageModel<TValue>(this WpfText label, Func<string, TValue> stringToValueFunc)
        {
            return new WpfTextControlPageModelWrapper<TValue>(label, stringToValueFunc);
        }

        public static ITextValuedPageModel<string> AsPageModel(this WpfText label)
        {
            return label.AsPageModel(StandardFunctionProvider.StringReturnSelf);
        }

        public static ITextValuedPageModel<string> AsPageModel(this WpfTitleBar titleBar, Func<string, string> stringToValueFunc)
        {
            return new WpfTitleBarControlPageModelWrapper(titleBar, stringToValueFunc);
        }

        public static ITextValuedPageModel<string> AsPageModel(this WpfTitleBar titleBar)
        {
            return titleBar.AsPageModel(StandardFunctionProvider.StringReturnSelf);
        } 
        #endregion
    }
}