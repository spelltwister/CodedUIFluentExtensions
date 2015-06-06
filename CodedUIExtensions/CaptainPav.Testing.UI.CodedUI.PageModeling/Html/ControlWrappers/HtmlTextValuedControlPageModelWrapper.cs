using System;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers
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