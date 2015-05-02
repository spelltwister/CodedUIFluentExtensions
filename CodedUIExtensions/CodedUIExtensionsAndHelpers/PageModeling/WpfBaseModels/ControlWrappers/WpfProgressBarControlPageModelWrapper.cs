using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class WpfProgressBarControlPageModelWrapper : UIControlPageModelWrapper<WpfProgressBar>, IValuedPageModel<double>
    {
        public WpfProgressBarControlPageModelWrapper(WpfProgressBar control)
            : base(control)
        {
        }

        public double Value
        {
            get { return this.Me.Position; }
        }
    }
}