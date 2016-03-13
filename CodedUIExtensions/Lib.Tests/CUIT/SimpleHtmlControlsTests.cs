using System;
using System.Drawing;
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
			this.window = BrowserWindow.Launch("http://localhost:7104/Examples/Example1");
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
    }
}