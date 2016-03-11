using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    public class HtmlForm : HtmlCustomTag
    {
        public static readonly string FormTag = "form";
        public static readonly string MethodAttributeName = "method";
        public static readonly string ActionAttributeName = "action";

        public HtmlForm() : base(FormTag) { }
        public HtmlForm(UITestControl parent) : base(parent, FormTag) { }

        /// <summary>
        /// Gets the method used to submit the form; if not method attribute
        /// is present, GET is returned
        /// </summary>
        /// <remarks>
        /// GET is the default method so if the attribute is not present,
        /// GET is still returned.  To determine if the Attribute is present,
        /// use the HasProperty extension
        /// </remarks>
        public string Method => this.GetPropertyOrDefault(MethodAttributeName, "GET");

	    /// <summary>
        /// Gets the action called when the form is posted or null if the
        /// action is not specified
        /// </summary>
        public string Action => this.GetPropertyOrDefault(ActionAttributeName, null);
    }
}