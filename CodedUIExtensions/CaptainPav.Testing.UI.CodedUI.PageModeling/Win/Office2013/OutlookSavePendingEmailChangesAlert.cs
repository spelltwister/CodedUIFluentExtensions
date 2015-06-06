using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Win.Office2013
{
    public class OutlookSavePendingChangesAlert<T> : PageModelBase<WinWindow>
    {
        protected const string EmailWindowName = "Microsoft Outlook";

        internal protected override WinWindow Me
        {
            get
            {
                return new WinWindow().Extend(WinWindow.PropertyNames.Name, EmailWindowName, PropertyExpressionOperator.EqualTo);
            }
        }

        protected WinButton YesButton
        {
            get
            {
                return this.Me.Find<WinButton>(WinButton.PropertyNames.Name, "Yes", PropertyExpressionOperator.EqualTo);
            }
        }

        protected WinButton NoButton
        {
            get
            {
                return this.Me.Find<WinButton>(WinButton.PropertyNames.Name, "No", PropertyExpressionOperator.EqualTo);
            }
        }

        protected WinButton CancelButton
        {
            get
            {
                return this.Me.Find<WinButton>(WinButton.PropertyNames.Name, "Cancel", PropertyExpressionOperator.EqualTo);
            }
        }

        protected readonly OutlookNewEmailWindow<T> _nextModel;
        public OutlookSavePendingChangesAlert(OutlookNewEmailWindow<T> nextWindow)
        {
            this._nextModel = nextWindow;
        }

        /// <summary>
        /// Clicking No results is the window closing
        /// </summary>
        /// <returns>
        /// The next model
        /// </returns>
        public T ClickNo()
        {
            Mouse.Click(this.NoButton);
            return _nextModel.NextModel;
        }
        /// <summary>
        /// Clicking Yes results in a Draft message being created
        /// and the window closing
        /// </summary>
        /// <returns>
        /// The next model
        /// </returns>
        public T ClickYes()
        {
            Mouse.Click(this.YesButton);
            return _nextModel.NextModel;
        }

        /// <summary>
        /// Clicking Cancel results in the window remaining open with focus
        /// </summary>
        /// <returns>
        /// The email with pending changes
        /// </returns>
        public OutlookNewEmailWindow<T> ClickCancel()
        {
            Mouse.Click(this.CancelButton);
            return _nextModel;
        }
    }
}