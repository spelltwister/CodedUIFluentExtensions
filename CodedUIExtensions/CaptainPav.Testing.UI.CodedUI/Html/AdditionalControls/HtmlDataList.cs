using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    public class HtmlDataList : HtmlCustomTag
    {
        public static readonly string DataListTag = "datalist";

        public HtmlDataList() : base(DataListTag) { }
        public HtmlDataList(UITestControl parent) : base(parent, DataListTag) { }

        public IEnumerable<HtmlDataListOption> Options => this.FindAll<HtmlDataListOption>();

	    public class HtmlDataListOption : HtmlCustomTag
        {
            public static readonly string DataListOptionTagName = "option";

            public HtmlDataListOption() : base(DataListOptionTagName) { }
            public HtmlDataListOption(UITestControl parent) : base(parent, DataListOptionTagName) { }
            public HtmlDataListOption(HtmlDataList parent) : base(parent, DataListOptionTagName) { }

            public string Value => this.ValueAttribute;
        }
    }
}