using System;
using CaptainPav.Testing.UI.PageModeling;
using Lib.Tests.PageModeling.PageModels;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Tests.PageModeling
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

		private ISimpleHtmlControlsPageModel model;

		[TestInitialize]
		public void NavigateToSimpleHtmlControlExamplesPage()
		{
			//BrowserWindow.CurrentBrowser = "Chrome";
			this.model = new SimpleHtmlControlsPageModel(BrowserWindow.Launch("http://codeduiexamples.com/Examples/Example1"));
		}

		[TestMethod]
		public void ManipulateTextInput()
		{
			Assert.IsTrue(String.IsNullOrWhiteSpace(model.UserName.Value));
			model.UserName.SetValue("MyUserName");
			Assert.IsTrue(StringComparer.Ordinal.Equals(model.UserName.Value, "MyUserName"));
		}

		[TestMethod]
		public void TestHiddenInput()
		{
			Assert.IsTrue(model.HiddenTextbox.CanFind(), "Cannot find hidden text box.");
			Assert.IsTrue(model.HiddenTextbox.IsNotRendered(), "Hidden text box should not be rendered.");
			Assert.IsTrue(model.HiddenTextbox.IsNotClickable(), "Hidden input should not be clickable.");
		}

		[TestMethod]
		public void TestDisabledInput()
		{
			Assert.IsTrue(model.DisabledTextbox.CanFind(), "Disabled text box should be able to be found.");
			Assert.IsTrue(model.DisabledTextbox.IsRendered(), "Disabled text box should be rendered.");
			Assert.IsTrue(model.DisabledTextbox.IsClickable(), "There should be a clickable point for the disabled textbox.");
			Assert.IsTrue(model.DisabledTextbox.IsNotActionable(), "Disabled textbox should not be actionable.");

			Assert.IsTrue(StringComparer.OrdinalIgnoreCase.Equals("testValue", model.DisabledTextbox.Value));

			try
			{
				model.DisabledTextbox.SetValue("Other Value");
				Assert.Fail("Attempting to set text of a disabled input should throw an exception.");
			}
			catch (ActionNotSupportedOnDisabledControlException)
			{
			}

			Assert.IsTrue(StringComparer.OrdinalIgnoreCase.Equals("testValue", model.DisabledTextbox.Value));
		}

		[TestMethod]
		public void PasswordTests()
		{
			Assert.IsTrue(model.Password.IsActionable());

			model.Password.SetValue("myPassword");
		}

		[TestMethod]
		public void BadPasswordModelTests()
		{
			Assert.IsTrue(model.Password.IsActionable());

			model.PasswordBadModel.SetValue("myPassword");
			try
			{
				var pwd = model.PasswordBadModel.Value;
				Assert.Fail("Should not be able to get password value.");
			}
			catch(NotSupportedException)
			{
			}
		}

		[TestMethod]
		public void CheckTests()
		{
			var initialState = model.Check.IsSelected;
			model.Check.SetSelected(!initialState);
			Assert.IsTrue(model.Check.IsSelected != initialState);
		}

		[TestMethod]
		public void UnboundedNumberTests()
		{
			model.FavoriteNumber.SetValue(100);
			Assert.IsTrue(model.FavoriteNumber.Value == 100);
			Assert.IsTrue(StringComparer.Ordinal.Equals(model.FavoriteNumber.ValueText, 100.ToString()));

			model.FavoriteNumber.SetValueText(500.ToString());
			Assert.IsTrue(model.FavoriteNumber.Value == 500);
			Assert.IsTrue(StringComparer.Ordinal.Equals(model.FavoriteNumber.ValueText, 500.ToString()));

			try
			{
				model.FavoriteNumber.SetValueText("abc");
				Assert.Fail("Should not be able to set value text to non number.");
			}
			catch (PlaybackFailureException)
			{
			}
		}

		[TestMethod]
		public void BoundedNumberTests()
		{
			
		}
	}
}