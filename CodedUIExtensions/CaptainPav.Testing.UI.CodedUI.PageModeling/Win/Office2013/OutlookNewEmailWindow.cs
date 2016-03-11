using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Win.Office2013
{
    /// <summary>
    /// Represents a new Outlook 2013 email window
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OutlookNewEmailWindow<T> : PageModelBase<WinWindow>
    {
        /// <summary>
        /// The title of this email window
        /// </summary>
        protected readonly string _emailWindowName;

        internal protected override WinWindow Me => new WinWindow().Extend(WinWindow.PropertyNames.Name, _emailWindowName, PropertyExpressionOperator.Contains);

	    protected WinButton CloseButton => this.Me.Find<WinWindow>(WinWindow.PropertyNames.AccessibleName, "Ribbon",       PropertyExpressionOperator.EqualTo)
		    .Find<UITestControl>(UITestControl.PropertyNames.Name,   "Ribbon",       PropertyExpressionOperator.EqualTo)
		    .Extend(WinWindow.PropertyNames.ControlType,             "PropertyPage", PropertyExpressionOperator.EqualTo)
		    .Find<WinButton>(WinButton.PropertyNames.Name,           "Close",        PropertyExpressionOperator.EqualTo);

	    protected WinEdit ToField => this.Me.Find<WinWindow>(WinWindow.PropertyNames.AccessibleName, "To", PropertyExpressionOperator.EqualTo)
	        .Find<WinEdit>(WinEdit.PropertyNames.Name, "To", PropertyExpressionOperator.EqualTo);

	    /// <summary>
        /// The next model to use when finished with this email window
        /// </summary>
        internal readonly T NextModel;

        public OutlookNewEmailWindow(T nextModel, string emailWindowName)
        {
            this.NextModel = nextModel;
            this._emailWindowName = emailWindowName;
        }

        public OutlookSavePendingChangesAlert<T> ClickClose()
        {
            Mouse.Click(this.CloseButton);
            return new OutlookSavePendingChangesAlert<T>(this);
        }

        public string To => this.ToField.Text;
    }
}