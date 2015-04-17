using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public abstract class HtmlAlertPageModelBase<TNextModel, TUIType, TUIClickElement> : AlertPageModelBase<TNextModel, TUIType>
        where TNextModel : IPageModel
        where TUIType : HtmlControl
        where TUIClickElement : HtmlControl
    {
        protected readonly TNextModel NextModel;
        protected HtmlAlertPageModelBase(TNextModel nextModel) 
        {
            if (null == nextModel)
            {
                throw new ArgumentNullException("nextModel");
            }
            this.NextModel = nextModel;
        }

        abstract protected TUIClickElement ClickToAcknowledge { get; }

        public override TNextModel Acknowledge()
        {
            Mouse.Click(ClickToAcknowledge);
            return this.NextModel;
        }
    }
}