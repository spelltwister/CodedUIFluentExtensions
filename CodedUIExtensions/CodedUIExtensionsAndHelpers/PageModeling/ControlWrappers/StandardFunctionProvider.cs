using System;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public static class StandardFunctionProvider
    {
        public static Func<string, string> StringReturnSelf = s => s;

        public static Func<string, DateTime?> StringToDate(string formatString, IFormatProvider formatProvider)
        {
            return x => String.IsNullOrWhiteSpace(x)
                ? null
                : (DateTime?)DateTime.ParseExact(x, formatString, formatProvider);
        }

        public static Func<DateTime?, string> DateToString(string formatString, IFormatProvider formatProvider)
        {
            return x => x.HasValue ? x.Value.ToString(formatString, formatProvider) : null;
        }
    }
}