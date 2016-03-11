using CaptainPav.Testing.UI.PageModeling;
using CaptainPav.Testing.UI.PageModeling.DialogPageModels;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf.DialogModels
{
    public abstract class WpfAlertPageModelBase<TUIType, TUIClickElement, TNextModel> : WpfHasNextModelPageModelBase<TUIType, TNextModel>, IAlertPageModel<TNextModel>
        where TNextModel : IPageModel
        where TUIType : WpfControl
        where TUIClickElement : WpfControl
    {
        protected WpfAlertPageModelBase(WpfWindow bw, TNextModel nextModel) : base(bw, nextModel)
        {
        }

        abstract protected TUIClickElement ClickToAcknowledge { get; }
        abstract public string Message { get; }

        public IClickablePageModel<TNextModel> AcknowledgeModel => this.ClickToAcknowledge.AsClickablePageModel(this.NextModel1);

	    public TNextModel Acknowledge()
        {
            return this.AcknowledgeModel.Click();
        }
    }
}