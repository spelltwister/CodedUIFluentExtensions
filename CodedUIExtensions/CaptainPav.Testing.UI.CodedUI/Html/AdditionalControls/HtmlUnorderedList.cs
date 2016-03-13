using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    /// <summary>
    /// Base class used to provide an Items property for list-type elements
    /// </summary>
    public abstract class HtmlListBase : HtmlCustomTag
    {
        internal HtmlListBase(string tagName) : base(tagName) { }
        internal HtmlListBase(UITestControl parent, string tagName) : base(parent, tagName) { }

        // TODO: Make sure only the first level children are included and not nested list child items
        /// <summary>
        /// Gets the Items in the list
        /// </summary>
        public IEnumerable<HtmlReadonlyListItem> Items => this.FindAll<HtmlReadonlyListItem>();
    }

    public class HtmlUnorderedList : HtmlListBase
    {
        public static readonly string UnorderedListTag = "ul";

        public HtmlUnorderedList() : base(UnorderedListTag) { }
        public HtmlUnorderedList(UITestControl parent) : base(parent, UnorderedListTag) { }
    }

    public class HtmlOrderedList : HtmlListBase
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