using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf.ControlWrappers
{
    public class WpfSliderControlPageModelWrapper<TNextModel> : HasNextModelUIControlPageModelWrapperBase<WpfSlider, TNextModel>, IReadWriteValuePageModel<double, TNextModel>
        where TNextModel : IPageModel
    {
        public WpfSliderControlPageModelWrapper(WpfSlider control, TNextModel nextModel) : base(control, nextModel) { }

        public double Value => this.Me.Position;

	    public TNextModel SetValue(double toValue)
        {
            this.Me.Position = toValue;
            return this.NextModel;
        }
    }
}