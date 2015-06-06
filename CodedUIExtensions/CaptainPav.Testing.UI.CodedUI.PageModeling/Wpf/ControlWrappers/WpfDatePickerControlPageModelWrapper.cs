using System;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf.ControlWrappers
{
    public class WpfDatePickerControlPageModelWrapper<TNextModel> : TextValuableControlPageModelWrapperBase<WpfDatePicker, DateTime?, TNextModel>
        where TNextModel : IPageModel
    {
        public WpfDatePickerControlPageModelWrapper(WpfDatePicker datePicker, TNextModel nextModel, Func<string, DateTime?> stringToDateFunc, Func<DateTime?, string> dateFormatFunction)
            : base(datePicker, nextModel, stringToDateFunc, dateFormatFunction)
        {
        }

        public WpfDatePickerControlPageModelWrapper(WpfDatePicker datePicker, TNextModel nextModel, string formatString, IFormatProvider formatProvider)
            : this(datePicker,
                nextModel,
                StandardFunctionProvider.StringToNullableDate(formatString, formatProvider),
                StandardFunctionProvider.NullableDateToString(formatString, formatProvider))
        {
        }

        public override string ValueText
        {
            get { return this.Me.DateAsString; }
        }

        public override TNextModel SetValueText(string toValue)
        {
            this.Me.DateAsString = toValue;
            return this.NextModel;
        }
    }
}