using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf.ControlWrappers
{
    public class WpfProgressBarControlPageModelWrapper : UIControlPageModelWrapper<WpfProgressBar>, IValuedPageModel<double>
    {
        public WpfProgressBarControlPageModelWrapper(WpfProgressBar control) : base(control) { }

        public double Value => this.Me.Position;
    }
}