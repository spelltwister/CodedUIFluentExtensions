using System.Collections.Generic;
using CaptainPav.Testing.UI.CodedUI.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace Lib.Tests.PageModeling.PageModels
{
	public interface IDataAttributesPageModel : IPageModel
	{
		ITestingContainerPageModel TestingContainer { get; }
	}

	public interface ITestingContainerPageModel : IPageModel
	{
		IEnumerable<IListItem> CustomerResults { get; }
		IEnumerable<IListItem> ProductResults { get; }
		IEnumerable<IListItem> CustomerRecommendations { get; }
		IEnumerable<IListItem> ProductRecommendations { get; }
	}

	public interface IListItem : IPageModel
	{
		int Id { get; }
		string Name { get; }
		string StatusText { get; }
		string Description { get; }
	}

	public class ListItem : HtmlChildPageModelBase<HtmlReadonlyListItem>, IListItem
	{
		public ListItem(BrowserWindow bw, HtmlReadonlyListItem me) : base(bw, me)
		{
			//this.DataAttributes = 
		}

		protected readonly Dictionary<string, string> DataAttributes;

		public int Id { get; }
		public string Name { get; }
		public string StatusText { get; }
		public string Description { get; }
	}
}