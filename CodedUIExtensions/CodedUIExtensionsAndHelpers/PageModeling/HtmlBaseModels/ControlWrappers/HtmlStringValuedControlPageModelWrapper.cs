using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class HtmlStringValuedControlPageModelWrapper<T> : UIControlPageModelWrapper<T>, IValuedPageModel<string> where T : HtmlControl
    {
        public HtmlStringValuedControlPageModelWrapper(T control) : base(control)
        {
        }

        public string Value { get { return this.Me.InnerText; } }
    }
}