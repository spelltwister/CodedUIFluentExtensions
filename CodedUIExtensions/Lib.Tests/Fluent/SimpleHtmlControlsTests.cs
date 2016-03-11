using System;
using CaptainPav.Testing.UI.CodedUI;
using CaptainPav.Testing.UI.CodedUI.Html;
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
			this.window = BrowserWindow.Launch("http://localhost:7104/Examples/Example1");
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
	}
}