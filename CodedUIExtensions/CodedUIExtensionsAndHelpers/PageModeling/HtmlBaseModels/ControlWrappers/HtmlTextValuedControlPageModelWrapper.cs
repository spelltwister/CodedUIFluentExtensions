using System;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class HtmlTextValuedControlPageModelWrapper<TControl, TValue> : TextValuedControlPageModelWrapper<TControl, TValue> where TControl : HtmlControl
    {
        public HtmlTextValuedControlPageModelWrapper(TControl cell, Func<string, TValue> stringToValueFunc, Func<TControl, string> cellToStringFunc)
            : base(cell, stringToValueFunc, cellToStringFunc)
        {
        }

        public HtmlTextValuedControlPageModelWrapper(TControl cell, Func<string, TValue> stringToValueFunc)
            : this(cell, stringToValueFunc, x => x.InnerText)
        {
        }
    }
}