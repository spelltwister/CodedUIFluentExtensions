using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Tests.CUIT
{
	/// <summary>
	/// Summary description for CodedUITest1
	/// </summary>
	[CodedUITest]
	public class SimpleHtmlControlsTests
	{
		public SimpleHtmlControlsTests()
		{
		}

		private BrowserWindow window;

		[TestInitialize]
		public void NavigateToSimpleHtmlControlExamplesPage()
		{
			this.window = BrowserWindow.Launch("http://codeduiexamples.com/Examples/Example1");
		}

		[TestMethod]
		public void ManipulateTextInput()
		{
			HtmlDiv bodyContainerDiv = new HtmlDiv(this.window);
			bodyContainerDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "layoutBodyContainer");

			// no fieldset available
			HtmlControl fieldset = new HtmlCustom(bodyContainerDiv);
			fieldset.SearchProperties.Add(HtmlControl.PropertyNames.TagName, "fieldset");

			Assert.IsTrue(fieldset.TryFind());

			HtmlEdit userNameEdit = new HtmlEdit(fieldset);
			userNameEdit.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "usernameInput");

			Assert.IsTrue(string.IsNullOrWhiteSpace(userNameEdit.Text));
			userNameEdit.Text = "MyUserName";
			Assert.IsTrue(StringComparer.Ordinal.Equals(userNameEdit.Text, "MyUserName"));
		}

        [TestMethod]
        public void TestHiddenInput()
        {
            HtmlDiv bodyContainerDiv = new HtmlDiv(this.window);
            bodyContainerDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "layoutBodyContainer");

            // no fieldset available
            HtmlControl fieldset = new HtmlCustom(bodyContainerDiv);
            fieldset.SearchProperties.Add(HtmlControl.PropertyNames.TagName, "fieldset");

            HtmlEdit hiddenEdit = new HtmlEdit(fieldset);
            hiddenEdit.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "hiddenTextInput");

            Assert.IsTrue(hiddenEdit.TryFind(), "Should be able to find the hidden input since it is in the markup.");

            Point p;
            Assert.IsFalse(hiddenEdit.TryGetClickablePoint(out p), "Should not be able to click on a hidden input.");
        }

        [TestMethod]
        public void TestDisabledInput()
        {
            HtmlDiv bodyContainerDiv = new HtmlDiv(this.window);
            bodyContainerDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "layoutBodyContainer");

            // no fieldset available
            HtmlControl fieldset = new HtmlCustom(bodyContainerDiv);
            fieldset.SearchProperties.Add(HtmlControl.PropertyNames.TagName, "fieldset");

            HtmlEdit disabledInput = new HtmlEdit(fieldset);
            disabledInput.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "disabledInput");

            Assert.IsTrue(disabledInput.TryFind(), "Disabled text box should be able to be found.");

            try
            {
                disabledInput.EnsureClickable();
            }
            catch { }

            Point p;
            Assert.IsTrue(disabledInput.TryGetClickablePoint(out p), "There should be a point on screen for the disabled input.");

            Assert.IsFalse(disabledInput.Enabled);

            Assert.IsTrue(StringComparer.OrdinalIgnoreCase.Equals("testValue", disabledInput.Text));

            try
            {
                disabledInput.Text = "Other Value";
                Assert.Fail("Attempting to set text of a disabled input should throw an exception.");
            }
            catch (ActionNotSupportedOnDisabledControlException)
            {
            }

            Assert.IsTrue(StringComparer.OrdinalIgnoreCase.Equals("testValue", disabledInput.Text));
        }

        [TestMethod]
        public void PasswordTests()
        {
            HtmlDiv bodyContainerDiv = new HtmlDiv(this.window);
            bodyContainerDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "layoutBodyContainer");

            // no fieldset available
            HtmlControl fieldset = new HtmlCustom(bodyContainerDiv);
            fieldset.SearchProperties.Add(HtmlControl.PropertyNames.TagName, "fieldset");

            HtmlEdit passwordInput = new HtmlEdit(fieldset);
            passwordInput.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "passwordInput");

            Assert.IsTrue(passwordInput.TryFind());

            try
            {
                passwordInput.EnsureClickable();
            }
            catch { }

            Point p;
            Assert.IsTrue(passwordInput.TryGetClickablePoint(out p), "There should be a point on screen for the disabled input.");


            passwordInput.Text = "myPassword";
        }
    }
}