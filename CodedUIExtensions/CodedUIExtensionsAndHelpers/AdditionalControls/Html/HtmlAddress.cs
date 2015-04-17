using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
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
}