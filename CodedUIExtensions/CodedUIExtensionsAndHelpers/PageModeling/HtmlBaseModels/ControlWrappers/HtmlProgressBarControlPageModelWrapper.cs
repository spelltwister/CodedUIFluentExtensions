using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class HtmlProgressBarControlPageModelWrapper : UIControlPageModelWrapper<HtmlProgressBar>, IValuedPageModel<float>
    {
        public HtmlProgressBarControlPageModelWrapper(HtmlProgressBar cell):base(cell)
        {
        }

        public float Value
        {
            get { return this.Me.Value; }
        }
    }
}