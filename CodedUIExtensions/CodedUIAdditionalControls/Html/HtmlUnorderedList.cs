using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIAdditionalControls.Html
{
    public class HtmlUnorderedList : HtmlCustomTag
    {
        public static readonly string UnorderedListTag = "ul";

        public HtmlUnorderedList() : base(UnorderedListTag) { }
        public HtmlUnorderedList(UITestControl parent) : base(parent, UnorderedListTag) { }
    }

    public class HtmlOrderedList : HtmlCustomTag
    {
        public static readonly string OrderedListTag = "ol";

        public HtmlOrderedList() : base(OrderedListTag) { }
        public HtmlOrderedList(UITestControl parent) : base(parent, OrderedListTag) { }
    }

    public class HtmlReadonlyListItem : HtmlCustomTag
    {
        public static readonly string ReadonlyListItemTag = "li";

        public HtmlReadonlyListItem() : base(ReadonlyListItemTag) { }
        public HtmlReadonlyListItem(UITestControl parent) : base(parent, ReadonlyListItemTag) { }
    }
}