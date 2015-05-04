using System;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class HtmlCellControlPageModelWrapper<TValue> : TextValuedControlPageModelWrapper<HtmlCell, TValue>
    {
        public HtmlCellControlPageModelWrapper(HtmlCell cell, Func<string, TValue> stringToValueFunc, Func<HtmlCell, string> cellToStringFunc) : base(cell, stringToValueFunc, cellToStringFunc)
        {
        }

        public HtmlCellControlPageModelWrapper(HtmlCell cell, Func<string, TValue> stringToValueFunc) : this(cell, stringToValueFunc, x => x.Value)
        {
        }
    }
}