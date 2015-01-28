using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using CodedUIExtensionsAndHelpers.Fluent;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlDataList : HtmlCustomTag
    {
        public static readonly string DataListTag = "datalist";

        public HtmlDataList() : base(DataListTag) { }
        public HtmlDataList(UITestControl parent) : base(parent, DataListTag) { }

        public IEnumerable<HtmlDataListOption> Options
        {
            get
            {
                return this.FindAll<HtmlDataListOption>();
            }
        }

        public class HtmlDataListOption : HtmlCustomTag
        {
            public static readonly string DataListOptionTagName = "option";

            public HtmlDataListOption(HtmlDataList parent) : base(parent, DataListOptionTagName) { }

            public string Value { get { return this.ValueAttribute; } }
        }
    }
}