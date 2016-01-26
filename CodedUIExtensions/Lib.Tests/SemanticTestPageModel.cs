using CaptainPav.Testing.UI.CodedUI;
using CaptainPav.Testing.UI.CodedUI.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Lib.Tests
{
    public class SemanticTestPageModel : HtmlDocumentPageModelBase
    {
        public SemanticTestPageModel(BrowserWindow window) : base(window)
        {
        }

        public IClickablePageModel<SemanticTestPageModel> Hyperlink
        {
            get { return DocumentWindow.Find<HtmlHyperlink>().AsPageModel(this); }
        }

        public IClickablePageModel<SemanticTestPageModel> HyperlinkArea
        {
            get { return DocumentWindow.Find<HtmlAreaHyperlink>().AsPageModel(this); }
        }

        public IClickablePageModel<SemanticTestPageModel> Button
        {
            get { return DocumentWindow.Find<HtmlButton>().AsPageModel(this); }
        }

        public IReadWriteTextValuePageModel<string, SemanticTestPageModel> EditableDiv
        {
            get { return DocumentWindow.Find<HtmlEditableDiv>().AsPageModel(this); }
        }

        public IClickablePageModel<SemanticTestPageModel> InputButton
        {
            get { return DocumentWindow.Find<HtmlInputButton>().AsPageModel(this); }
        }

        public ISelectablePageModel<SemanticTestPageModel> Checkbox
        {
            get { return this.DocumentWindow.Find<HtmlCheckBox>().AsPageModel(this); }
        }

        //public ISelectablePageModel<SemanticTestPageModel> RadioButtonYes
        //{
        //    get { return this.DocumentWindow.FindAll<HtmlRadioButton>().First().AsPageModel(this); }
        //}

        //public ISelectablePageModel<SemanticTestPageModel> RadioButtonNo
        //{
        //    get { return this.DocumentWindow.FindAll<HtmlRadioButton>().Skip(1).First().AsPageModel(this); }
        //}

        public IReadWriteTextValuePageModel<string, SemanticTestPageModel> Edit
        {
            get { return this.DocumentWindow.Find<HtmlEdit>().AsPageModel(this); }
        }

        public ISelectionPageModel<string, SemanticTestPageModel, HtmlComboBoxItemControlPageModelWrapper<SemanticTestPageModel>> Combobox
        {
            get { return this.DocumentWindow.Find<HtmlComboBox>().AsPageModel(this); }
        }

        public IReadWriteTextValuePageModel<string, SemanticTestPageModel> EditableSpan
        {
            get { return this.DocumentWindow.Find<HtmlEditableSpan>().AsPageModel(this); }
        }

        public IReadWriteTextValuePageModel<string, SemanticTestPageModel> TextArea
        {
            get { return this.DocumentWindow.Find<HtmlTextArea>().AsPageModel(this); }
        }

        public ITextValuedPageModel<string> AFAIK
        {
            get { return this.DocumentWindow.Find<HtmlAbbreviation>().AsPageModel(); }
        } 
    }
}