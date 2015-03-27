using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using CodedUIExtensionsAndHelpers.Fluent;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlDetails : HtmlCustomTag
    {
        public static readonly string DetailsTag = "details";

        public HtmlDetails() : base(DetailsTag) { }
        public HtmlDetails(UITestControl parent) : base(parent, DetailsTag) { }

        public string Summary
        {
            get
            {
                return new HtmlSummary(this).InnerText;
            }
        }

        public string ExpanderText
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Returns true if the expander's attribute indicates it should be
        /// open; otherwise, false
        /// </summary>
        /// <remarks>
        /// Regardless of the value of this attribute, if it is present, the
        /// expander should be rendered in the opened state
        /// </remarks>
        public bool IsExpanderOpen
        {
            get
            {
                return this.HasProperty("open");
            }
        }

        protected class HtmlSummary : HtmlCustomTag
        {
            public static readonly string SummaryTag = "summary";

            public HtmlSummary(HtmlDetails parent) : base(parent, SummaryTag) { }
        }
    }
}