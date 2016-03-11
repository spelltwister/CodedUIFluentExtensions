using System;
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
	}
}