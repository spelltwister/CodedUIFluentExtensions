using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.Wpf
{
    public class WpfDataItem : WpfCustom
    {
        public WpfDataItem() : this(null)
        {
        }

        public WpfDataItem(UITestControl parentControl) : base(parentControl)
        {
            this.SearchProperties.Add(WpfCustom.PropertyNames.ControlType, "DataItem", PropertyExpressionOperator.Contains);
        }
    }
}