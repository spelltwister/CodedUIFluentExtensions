using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    public class HtmlHeading1 : HtmlCustomTag
    {
        public static readonly string Heading1Tag = "h1";

        public HtmlHeading1() : base(Heading1Tag) { }
        public HtmlHeading1(UITestControl parent) : base(parent, Heading1Tag) { }
    }

    public class HtmlHeading2 : HtmlCustomTag
    {
        public static readonly string Heading2Tag = "h2";

        public HtmlHeading2() : base(Heading2Tag) { }
        public HtmlHeading2(UITestControl parent) : base(parent, Heading2Tag) { }
    }

    public class HtmlHeading3 : HtmlCustomTag
    {
        public static readonly string Heading3Tag = "h3";

        public HtmlHeading3() : base(Heading3Tag) { }
        public HtmlHeading3(UITestControl parent) : base(parent, Heading3Tag) { }
    }

    public class HtmlHeading4 : HtmlCustomTag
    {
        public static readonly string Heading4Tag = "h4";

        public HtmlHeading4() : base(Heading4Tag) { }
        public HtmlHeading4(UITestControl parent) : base(parent, Heading4Tag) { }
    }

    public class HtmlHeading5 : HtmlCustomTag
    {
        public static readonly string Heading5Tag = "h5";

        public HtmlHeading5() : base(Heading5Tag) { }
        public HtmlHeading5(UITestControl parent) : base(parent, Heading5Tag) { }
    }

    public class HtmlHeading6 : HtmlCustomTag
    {
        public static readonly string Heading6Tag = "h6";

        public HtmlHeading6() : base(Heading6Tag) { }
        public HtmlHeading6(UITestControl parent) : base(parent, Heading6Tag) { }
    }
}