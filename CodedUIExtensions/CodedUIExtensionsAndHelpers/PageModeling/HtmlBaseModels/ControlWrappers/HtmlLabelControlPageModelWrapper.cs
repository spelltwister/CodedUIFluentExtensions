using System;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class HtmlLabelControlPageModelWrapper<TValue> : TextValuedControlPageModelWrapper<HtmlLabel, TValue>
    {
        public HtmlLabelControlPageModelWrapper(HtmlLabel cell, Func<string, TValue> stringToValueFunc, Func<HtmlLabel, string> cellToStringFunc)
            : base(cell, stringToValueFunc, cellToStringFunc)
        {
        }

        public HtmlLabelControlPageModelWrapper(HtmlLabel cell, Func<string, TValue> stringToValueFunc)
            : this(cell, stringToValueFunc, x => x.DisplayText)
        {
        }
    }
}