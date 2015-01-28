using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class Html5GlobalAttributes
    {
        public static readonly string ContentEditableAttributeName = "contenteditable";
        public static readonly string ContextMenuAttributeName = "contextmenu";
        public static readonly string DraggableAttributeName = "draggable";
    }

    public class HtmlAbbreviation : HtmlCustomTag
    {
        public static readonly string AbbreviationTag = "abbr";
        public static readonly string TitleAttributeName = "title";

        public HtmlAbbreviation() : base(AbbreviationTag) { }
        public HtmlAbbreviation(UITestControl parent) : base(parent, AbbreviationTag) { }

        public string Title
        {
            get
            {
                return this.GetPropertyOrDefault(MethodAttributeName, null);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// The Address element does not (typically) represent a postal address,
    /// but rather contact information about the author of an article or page
    /// </remarks>
    public class HtmlAddress : HtmlCustomTag
    {
        public static readonly string AddressTag = "address";

        public HtmlAddress() : base(AddressTag) { }
        public HtmlAddress(UITestControl parent) : base(parent, AddressTag) { }
    }

    public class HtmlArticle : HtmlCustomTag
    {
        public static readonly string ArticleTag = "article";

        public HtmlArticle() : base(ArticleTag) { }
        public HtmlArticle(UITestControl parent) : base(parent, ArticleTag) { }
    }

    public class HtmlAside : HtmlCustomTag
    {
        public static readonly string AsideTag = "aside";

        public HtmlAside() : base(AsideTag) { }
        public HtmlAside(UITestControl parent) : base(parent, AsideTag) { }
    }

    public class HtmlCanvas : HtmlCustomTag
    {
        public static readonly string CanvasTag = "canvas";

        public HtmlCanvas() : base(CanvasTag) { }
        public HtmlCanvas(UITestControl parent) : base(parent, CanvasTag) { }
    }

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

    public class HtmlDetails : HtmlCustom
    {
        public static readonly string DetailsTag = "details";

        public HtmlDetails() : base(DetailsTag) { }
        public HtmlDetails(UITestControl parent) : base(parent, DetailsTag) { }

        public string Summary
        {
            get
            {
                return this.Find<HtmlSummary>().InnerText;
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

        protected class HtmlSummary : HtmlCustom
        {
            public static readonly string SummaryTag = "summary";

            public HtmlSummary(HtmlDetails parent) : base(parent, SummaryTag) { }
        }
    }

    public class HtmlDialog : HtmlCustom
    {
        public static readonly string DialogTag = "dialog";

        public HtmlDialog() : base(DialogTag) { }
        public HtmlDialog(UITestControl parent) : base(parent, DialogTag) { }

        public bool IsOpen
        {
            get
            {
                return this.HasProperty("open");
            }
        }
    }

    public class HtmlFigure : HtmlCustom
    {
        public static readonly string FigureTag = "figure";

        public HtmlFigure() : base(FigureTag) { }
        public HtmlFigure(UITestControl parent) : base(parent, FigureTag) { }

        public string Caption
        {
            get
            {
                return this.Find<HtmlFigureCaption>().InnerText;
            }
        }

        protected class HtmlFigureCaption : HtmlCustom
        {
            public static readonly string FigureCaptionTag = "figcaption";

            public HtmlFigureCaption(HtmlFigure parent) : base(parent, FigureCaptionTag) { }
        }
    }

    public class HtmlHeader : HtmlCustom
    {
        public static readonly string HeaderTag = "header";

        public HtmlHeader() : base(HeaderTag) { }
        public HtmlHeader(UITestControl parent) : base(parent, HeaderTag) { }
    }

    public class HtmlFooter : HtmlCustom
    {
        public static readonly string FooterTag = "footer";

        public HtmlFooter() : base(FooterTag) { }
        public HtmlFooter(UITestControl parent) : base(parent, FooterTag) { }
    }

    public class HtmlMain : HtmlCustom
    {
        public static readonly string MainTag = "main";

        public HtmlMain() : base(MainTag) { }
        public HtmlMain(UITestControl parent) : base(parent, MainTag) { }
    }

    public class HtmlMark : HtmlCustom
    {
        public static readonly string MarkTag = "mark";

        public HtmlMark() : base(MarkTag) { }
        public HtmlMark(UITestControl parent) : base(parent, MarkTag) { }
    }

    public class HtmlMeter : HtmlCustom
    {
        public static readonly string MeterTag = "meter";
        public static readonly string FormAttributeName = "form";
        public static readonly string MinAttributeName = "min";
        public static readonly string MaxAttributeName = "max";
        public static readonly string LowAttributeName = "low";
        public static readonly string HighAttributeName = "high";
        public static readonly string OptimumAttributeName = "optimum";

        public HtmlMeter() : base(MeterTag) { }
        public HtmlMeter(UITestControl parent) : base(parent, MeterTag) { }

        public string Form
        {
            get
            {
                return this.TryGetPropertyOrDefault("form", null);
            }
        }

        public double Value
        {
            get
            {
                return Double.Parse(this.ValueAttribute);
            }
        }

        public double? Min
        {
            get
            {
                return GetNullableProperty(MinAttributeName);
            }
        }

        public double? Max
        {
            get
            {
                return GetNullableProperty(MaxAttributeName);
            }
        }

        public double? Low
        {
            get
            {
                return GetNullableProperty(LowAttributeName);
            }
        }

        public double? High
        {
            get
            {
                return GetNullableProperty(HighAttributeName);
            }
        }

        public double? Optimum
        {
            get
            {
                return GetNullableProperty(OptimumAttributeName);
            }
        }

        protected double? GetNullableProperty(string propertyName)
        {
            string valueString;
            if (!this.TryGetProperty(propertyName, out valueString))
            {
                return null;
            }
            return Double.Parse(valueString);
        }
    }

    public class HtmlNavigation : HtmlCustom
    {
        public static readonly string NavigationTag = "nav";

        public HtmlNavigation() : base(NavigationTag) { }
        public HtmlNavigation(UITestControl parent) : base(parent, NavigationTag) { }
    }

    /// <summary>
    /// Used to find HTML elements which were not included in the
    /// Microsoft UITesting Html Controls
    /// </summary>
    public class HtmlCustomTag : HtmlCustom
    {
        private void Init()
        {
            this.SearchProperties.Add(HtmlControl.PropertyNames.TagName, this._tagName, this._expressionOperator);
        }

        /// <summary>
        /// The expression operator used when comparing tag names
        /// </summary>
        protected readonly PropertyExpressionOperator _expressionOperator;

        /// <summary>
        /// The tag name this control represents
        /// </summary>
        protected readonly string _tagName;

        /// <summary>
        /// Gets a search control that is able to find Html tags when the
        /// specified tag name
        /// </summary>
        /// <param name="tagName">
        /// The tag name this control represents
        /// </param>
        /// <param name="expressionOperator">
        /// The expression operator used when comparing tag names
        /// </param>
        public HtmlCustomTag(string tagName, PropertyExpressionOperator expressionOperator = PropertyExpressionOperator.EqualTo) : base()
        {
            if (String.IsNullOrWhiteSpace(tagName))
            {
                throw new ArgumentException("Tag name cannot be null, empty, or white space.", "tagName");
            }

            this._tagName = tagName;
            this._expressionOperator = expressionOperator;

            Init();
        }

        /// <summary>
        /// Gets a search control that is able to find Html tags when the
        /// specified tag name
        /// </summary>
        /// <param name="parent">
        /// The parent control from which to start searching
        /// </param>
        /// <param name="tagName">
        /// The tag name this control represents
        /// </param>
        /// <param name="expressionOperator">
        /// The expression operator used when comparing tag names
        /// </param>
        public HtmlCustomTag(UITestControl parent, string tagName, PropertyExpressionOperator expressionOperator = PropertyExpressionOperator.EqualTo) : base(parent)
        {
            if (String.IsNullOrWhiteSpace(tagName))
            {
                throw new ArgumentException("Tag name cannot be null, empty, or white space.", "tagName");
            }

            this._tagName = tagName;
            this._expressionOperator = expressionOperator;

            Init();
        }
    }
}