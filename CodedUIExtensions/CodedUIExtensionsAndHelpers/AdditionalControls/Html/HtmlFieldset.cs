using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlFieldset : HtmlCustomTag
    {
        public static readonly string FieldsetTag = "fieldset";

        public HtmlFieldset() : base(FieldsetTag) { }
        public HtmlFieldset(UITestControl parent) : base(parent, FieldsetTag) { }

        public HtmlLegend Legend { get { throw new System.NotImplementedException(); } }
    }

    public class HtmlLegend : HtmlCustomTag
    {
        public static readonly string LegendTag = "legend";

        public HtmlLegend() : base(LegendTag) { }
        public HtmlLegend(UITestControl parent) : base(parent, LegendTag) { }
    }
}