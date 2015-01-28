using Microsoft.VisualStudio.TestTools.UITesting;
using CodedUIExtensionsAndHelpers.Fluent;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlFieldset : HtmlCustomTag
    {
        public static readonly string FieldsetTag = "fieldset";

        public HtmlFieldset() : base(FieldsetTag) { }
        public HtmlFieldset(UITestControl parent) : base(parent, FieldsetTag) { }

        /// <summary>
        /// Gets the legend associated with this fieldset
        /// </summary>
        public HtmlLegend Legend
        {
            get { return this.Find<HtmlLegend>(); }
        }
    }

    public class HtmlLegend : HtmlCustomTag
    {
        public static readonly string LegendTag = "legend";

        public HtmlLegend() : base(LegendTag) { }
        public HtmlLegend(UITestControl parent) : base(parent, LegendTag) { }
    }
}