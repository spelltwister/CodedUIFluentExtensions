using System;
using System.Linq;
using CodedUIExtensionsAndHelpers.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Tests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class HtmlSemanticPageModelTests
    {
        readonly Lazy<BrowserWindow> _lazyWindow = new Lazy<BrowserWindow>(() => BrowserWindow.Locate("Semantic Page Model Tests"));
        BrowserWindow Window { get { return this._lazyWindow.Value; } }
        
        [TestMethod]
        public void ButtonIsClickable()
        {
            new SemanticTestPageModel(this.Window).Button.Click();
        }

        [TestMethod]
        public void HyperlinkIsClickable()
        {
            new SemanticTestPageModel(this.Window).Hyperlink.Click();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }

        [TestMethod]
        public void InputButtonIsClickable()
        {
            new SemanticTestPageModel(this.Window).InputButton.Click();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }

        [TestMethod]
        public void CheckboxCanToggle()
        {
            Assert.IsTrue(new SemanticTestPageModel(this.Window).Checkbox.SetSelected(true).Checkbox.IsSelected);
            Assert.IsFalse(new SemanticTestPageModel(this.Window).Checkbox.SetSelected(false).Checkbox.IsSelected);
        }

        [TestMethod]
        public void EditableDivCanSetText()
        {
            const string testString = "Some Text";
            Assert.IsTrue(new SemanticTestPageModel(this.Window).EditableDiv.SetValue(testString).EditableDiv.Value == testString);
        }

        [TestMethod]
        public void EditableSpanCanSetText()
        {
            const string testString = "Some Text";
            Assert.IsTrue(new SemanticTestPageModel(this.Window).EditableSpan.SetValue(testString).EditableSpan.Value == testString);
        }

        [TestMethod]
        public void EditBoxCanSetText()
        {
            const string testString = "Some Text";
            Assert.IsTrue(new SemanticTestPageModel(this.Window).Edit.SetValue(testString).Edit.Value == testString);
        }

        [TestMethod]
        public void TextAreaCanSetText()
        {
            const string testString = "Some Text";
            Assert.IsTrue(new SemanticTestPageModel(this.Window).TextArea.SetValue(testString).TextArea.Value == testString);
        }

        [TestMethod]
        public void ComboboxCanSelectItem()
        {
            const string testString = "More text";
            var page = new SemanticTestPageModel(this.Window);
            ISelectionPageModel_StandardTests(page.Combobox);
        }

        private static void ISelectionPageModel_StandardTests<T, U>(ISelectionPageModel<T, U> selection)
            where U : IPageModel
        {
            if (!selection.Items.Any())
            {
                Assert.Inconclusive();
            }

            AssertValidState(selection);

            if (selection.SelectedItem != null)
            {
                selection.SelectedItem.SetSelected(false);
                AssertValidState(selection);
            }

            selection.Items.First().SetSelected(true);
            AssertValidState(selection);

            if (selection.Items.Skip(1).Any())
            {
                selection.Items.Skip(1).First().SetSelected(true);
                AssertValidState(selection);
            }

            if (selection.Items.Skip(2).Any())
            {
                selection.Items.Last().SetSelected(true);
                AssertValidState(selection);
            }
        }

        private static void AssertNothingSelected<T, U>(ISelectionPageModel<T, U> selection)
            where U : IPageModel
        {
            Assert.IsTrue(selection.Items.All(x => !x.IsSelected));
        }

        private static void AssertSingleSelection<T, U>(ISelectionPageModel<T, U> selection)
            where U : IPageModel
        {
            Assert.IsTrue(selection.Items.SkipWhile(x => !x.IsSelected).Skip(1).All(x => !x.IsSelected));
        }

        private static void AssertValidState<T, U>(ISelectionPageModel<T, U> selection)
            where U : IPageModel
        {
            if (selection.SelectedItem == null)
            {
                AssertNothingSelected(selection);
            }
            else
            {
                AssertSingleSelection(selection);
                Assert.IsTrue(selection.SelectedItem.IsSelected);
            }
        }
    }
}