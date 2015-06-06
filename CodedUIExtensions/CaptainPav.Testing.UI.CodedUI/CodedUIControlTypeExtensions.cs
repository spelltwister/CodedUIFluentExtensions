using System;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI
{
    internal static class CodedUIControlTypeExtensions
    {
        internal static readonly Type HtmlType = typeof(HtmlControl);
        internal static readonly Type WinType = typeof(WinControl);
        internal static readonly Type WpfType = typeof(WpfControl);

        internal static bool IsHtmlControl(this Type type)
        {
            return type.IsSubclassOf(HtmlType) || type == HtmlType;
        }

        internal static bool IsWpfControl(this Type type)
        {
            return type.IsSubclassOf(WpfType) || type == WpfType;
        }

        internal static bool IsWinControl(this Type type)
        {
            return type.IsSubclassOf(WinType) || type == WinType;
        }
    }
}