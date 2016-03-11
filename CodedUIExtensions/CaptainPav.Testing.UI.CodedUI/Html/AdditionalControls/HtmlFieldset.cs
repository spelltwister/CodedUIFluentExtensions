using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    public class HtmlFieldset : HtmlCustomTag
    {
        public static readonly string FieldsetTag = "fieldset";

        public HtmlFieldset() : base(FieldsetTag) { }
        public HtmlFieldset(UITestControl parent) : base(parent, FieldsetTag) { }

        /// <summary>
        /// Gets the legend associated with this fieldset
        /// </summary>
        public HtmlLegend Legend => this.Find<HtmlLegend>();

		public class HtmlLegend : HtmlCustomTag
		{
			public static readonly string LegendTag = "legend";

			public HtmlLegend() : base(LegendTag) { }
			public HtmlLegend(UITestControl parent) : base(parent, LegendTag) { }
		}
	}
}