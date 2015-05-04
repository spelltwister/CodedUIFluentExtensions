using System;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class HtmlSpanControlPageModelWrapper<TValue> : TextValuedControlPageModelWrapper<HtmlSpan, TValue>
    {
        public HtmlSpanControlPageModelWrapper(HtmlSpan span, Func<string, TValue> stringToValueFunc, Func<HtmlSpan, string> spanToStringFunc)
            : base(span, stringToValueFunc, spanToStringFunc)
        {
        }

        public HtmlSpanControlPageModelWrapper(HtmlSpan span, Func<string, TValue> stringToValueFunc)
            : this(span, stringToValueFunc, s => s.DisplayText)
        {
        }
    }
}