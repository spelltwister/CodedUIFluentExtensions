using CaptainPav.Testing.UI.CodedUI;
using CaptainPav.Testing.UI.CodedUI.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Lib.Tests.PageModeling.PageModels
{
	public interface ISimpleHtmlControlsPageModel : IPageModel
	{
		IReadWriteValuePageModel<string, ISimpleHtmlControlsPageModel> UserName { get; }
		IReadWriteValuePageModel<string, ISimpleHtmlControlsPageModel> HiddenTextbox { get; }
		IReadWriteValuePageModel<string, ISimpleHtmlControlsPageModel> DisabledTextbox { get; }
		IValueablePageModel<string, ISimpleHtmlControlsPageModel> Password { get; }
		IReadWriteValuePageModel<string, ISimpleHtmlControlsPageModel> PasswordBadModel { get; }
		ISelectablePageModel<ISimpleHtmlControlsPageModel> Check { get; }
		IReadWriteTextValuePageModel<double?, ISimpleHtmlControlsPageModel> FavoriteNumber { get; }
		IReadWriteTextValuePageModel<double?, ISimpleHtmlControlsPageModel> Age { get; }
	}

	public class SimpleHtmlControlsPageModel : HtmlPageModelBase<HtmlFieldset>, ISimpleHtmlControlsPageModel
	{
		public SimpleHtmlControlsPageModel(BrowserWindow bw) : base(bw) { }

		protected override HtmlFieldset Me => this.DocumentWindow.Find<HtmlDiv>("layoutBodyContainer")
			                                                     .Find<HtmlFieldset>();

		public IReadWriteValuePageModel<string, ISimpleHtmlControlsPageModel> UserName => this.Me.Find<HtmlEdit>("usernameInput").AsPageModel(this);
		public IReadWriteValuePageModel<string, ISimpleHtmlControlsPageModel> HiddenTextbox => this.Me.Find<HtmlEdit>("hiddenTextInput").AsPageModel(this);
		public IReadWriteValuePageModel<string, ISimpleHtmlControlsPageModel> DisabledTextbox => this.Me.Find<HtmlEdit>("disabledInput").AsPageModel(this);
		public IValueablePageModel<string, ISimpleHtmlControlsPageModel> Password => this.Me.Find<HtmlPasswordInput>("passwordInput").AsPageModel(this);
		public IReadWriteValuePageModel<string, ISimpleHtmlControlsPageModel> PasswordBadModel => this.Me.Find<HtmlEdit>("passwordInput").AsPageModel(this);
		public ISelectablePageModel<ISimpleHtmlControlsPageModel> Check => this.Me.Find<HtmlCheckBox>("checkboxInput").AsPageModel(this);
		public IReadWriteTextValuePageModel<double?, ISimpleHtmlControlsPageModel> FavoriteNumber => this.Me.Find<HtmlNumberInput>("numberInput").AsPageModel(this);
		public IReadWriteTextValuePageModel<double?, ISimpleHtmlControlsPageModel> Age => this.Me.Find<HtmlNumberInput>("ageInput").AsPageModel(this);
	}
}
