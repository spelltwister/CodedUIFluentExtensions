using System;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers
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