using System;
using System.Drawing;
using CaptainPav.Testing.UI.CodedUI;
using CaptainPav.Testing.UI.CodedUI.Html;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Tests.Fluent
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
			var usernameEdit =
			this.window.Find<HtmlDiv>("layoutBodyContainer")
					   .Find<HtmlFieldset>()
					   .Find<HtmlEdit>("usernameInput");
			
			Assert.IsTrue(string.IsNullOrWhiteSpace(usernameEdit.Text));
			usernameEdit.Text = "MyUserName";
			Assert.IsTrue(StringComparer.Ordinal.Equals(usernameEdit.Text, "MyUserName"));
		}

        [TestMethod]
        public void TestHiddenInput()
        {
            var hiddenEdit =
            this.window.Find<HtmlDiv>("layoutBodyContainer")
                       .Find<HtmlFieldset>()
                       .Find<HtmlEdit>("hiddenTextInput");

            Assert.IsTrue(hiddenEdit.TryFind(), "Should be able to find the hidden input since it is in the markup.");

            System.Drawing.Point p;
            Assert.IsFalse(hiddenEdit.TryGetClickablePoint(out p), "Should not be able to click on a hidden input.");
        }

        [TestMethod]
        public void TestDisabledInput()
        {
            var disabledInput =
            this.window.Find<HtmlDiv>("layoutBodyContainer")
                       .Find<HtmlFieldset>()
                       .Find<HtmlEdit>("disabledInput");

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
            var passwordInput =
            this.window.Find<HtmlDiv>("layoutBodyContainer")
                       .Find<HtmlFieldset>()
                       .Find<HtmlEdit>("passwordInput");

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

        [TestMethod]
        public void BadPasswordModelTests()
        {
            var passwordInput =
            this.window.Find<HtmlDiv>("layoutBodyContainer")
                       .Find<HtmlFieldset>()
                       .Find<HtmlEdit>("passwordInput");

            Assert.IsTrue(passwordInput.TryFind());

            try
            {
                passwordInput.EnsureClickable();
            }
            catch { }

            Point p;
            Assert.IsTrue(passwordInput.TryGetClickablePoint(out p), "There should be a point on screen for the disabled input.");

            passwordInput.Text = "myPassword";

            try
            {
                var pwd = passwordInput.Text;
                Assert.Fail("Should not be able to get password value.");
            }
            catch (NotSupportedException)
            {
            }
        }
    }
}