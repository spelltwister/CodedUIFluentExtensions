using System;
using System.Globalization;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers
{
    public static class StandardFunctionProvider
    {
        public static Func<string, string> StringReturnSelf = s => s;

        public static Func<string, DateTime?> StringToNullableDate(string formatString, IFormatProvider formatProvider)
        {
            return x => String.IsNullOrWhiteSpace(x)
                ? null
                : (DateTime?)DateTime.ParseExact(x, formatString, formatProvider);
        }

        public static Func<DateTime?, string> NullableDateToString(string formatString, IFormatProvider formatProvider)
        {
            return x => x.HasValue ? x.Value.ToString(formatString, formatProvider) : null;
        }

        public static Func<string, DateTime> StringToDate(string formatString, IFormatProvider formatProvider)
        {
            return x => DateTime.ParseExact(x, formatString, formatProvider);
        }

        public static Func<DateTime, string> DateToString(string formatString, IFormatProvider formatProvider)
        {
            return x => x.ToString(formatString, formatProvider);
        }

        public static Func<TimeZoneInfo, string> TimeZoneInfoToString()
        {
            return x => x.ToSerializedString();
        }

        public static Func<string, TimeZoneInfo> StingToTimeZoneInfo()
        {
            return TimeZoneInfo.FromSerializedString;
        }

        public static Func<decimal, string> CurrencyToString()
        {
            return x => x.ToString("C");
        }

        public static Func<string, decimal> StringToCurrency()
        {
            return x => Decimal.Parse(x, NumberStyles.Currency);
        } 
    }
}