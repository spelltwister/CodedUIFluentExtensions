using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class WpfTitleBarControlPageModelWrapper : UIControlPageModelWrapper<WpfTitleBar>, IValuedPageModel<string>
    {
        public WpfTitleBarControlPageModelWrapper(WpfTitleBar control)
            : base(control)
        {
        }

        public string Value { get { return this.Me.DisplayText; } }
    }
}