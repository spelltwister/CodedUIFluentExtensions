using System.Collections.Generic;
using System.Linq;
using CaptainPav.Testing.UI.CodedUI;
using CaptainPav.Testing.UI.CodedUI.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Lib.Tests.PageModeling.PageModels
{
    public interface ICustomerNewsPage : IPageModel
    {
        ICustomerSearch GoodCustomers { get; }
        ICustomerSearch SuckeyCustomers { get; }
        IPageModel NewsArea { get; }
    }

    public class CustomerNewsPage : HtmlDocumentPageModelBase, ICustomerNewsPage
    {
        public CustomerNewsPage(BrowserWindow bw) : base(bw)
        {
        }

        public ICustomerSearch GoodCustomers => new CustomerSearch(this.parent, this.Me.Find<HtmlDiv>("customerSearchContainer"));
        public ICustomerSearch SuckeyCustomers => new CustomerSearch(this.parent, this.Me.Find<HtmlDiv>("suckyCustomers"));
        public IPageModel NewsArea => this.Me.Find<HtmlDiv>("newsArea").AsPageModel();
    }

    public interface ICustomerSearch : IPageModel
    {
        ICustomerSearchCriteria SearchCriteria { get; }
        ICustomerSearchResults SearchResults { get; }
    }

    public class CustomerSearch : HtmlChildPageModelBase<HtmlDiv>, ICustomerSearch
    {
        public CustomerSearch(BrowserWindow bw, HtmlDiv me) : base(bw, me)
        {
        }

        public ICustomerSearchCriteria SearchCriteria => new CustomerSearchCriteria(this.parent, this);
        public ICustomerSearchResults SearchResults => new CustomerSearchResults(this.parent, this);
    }

    public interface ICustomerSearchCriteria : IPageModel
    {
        IValueablePageModel<string, ICustomerSearchCriteria> CustomerName { get; }
        IValueablePageModel<string, ICustomerSearchCriteria> CustomerId { get; }
        IClickablePageModel<ICustomerSearch> Search { get; } 
    }

    public class CustomerSearchCriteria : HtmlStaticChildPageModelBase<HtmlDiv, CustomerSearch, HtmlDiv>, ICustomerSearchCriteria
    {
        public IValueablePageModel<string, ICustomerSearchCriteria> CustomerName => this.Me.Find<HtmlEdit>().WithDataAttribute("criteria", "name").AsPageModel(this);

        public IValueablePageModel<string, ICustomerSearchCriteria> CustomerId => this.Me.Find<HtmlEdit>().WithDataAttribute("criteria", "id").AsPageModel(this);
        public IClickablePageModel<ICustomerSearch> Search => this.Me.Find<HtmlButton>().AsPageModel(this.parentModel);

        public CustomerSearchCriteria(BrowserWindow bw, CustomerSearch parentModel) : base(bw, parentModel)
        {
        }

        protected override HtmlDiv Me => this.ParentScope.Find<HtmlDiv>().WithDataAttribute("control-type", "customerSearchCriteria");
    }

    public interface ICustomerSearchResults : IPageModel
    {
        IEnumerable<ICustomerRow> Customers { get; } 
    }

    public class CustomerSearchResults : HtmlStaticChildPageModelBase<HtmlDiv, CustomerSearch, HtmlDiv>, ICustomerSearchResults
    {
        public CustomerSearchResults(BrowserWindow bw, CustomerSearch parentModel) : base(bw, parentModel)
        {
        }

        protected override HtmlDiv Me => this.ParentScope.Find<HtmlDiv>().WithDataAttribute("control-type", "resultArea");
        public IEnumerable<ICustomerRow> Customers => this.Me.Find<HtmlUnorderedList>()
                                                             .Items
                                                             .Select(x => new CustomerRow(this.parent, x));
    }

    public interface ICustomerRow
    {
        string Name { get; }
        string State { get; }
    }

    public class CustomerRow : HtmlChildPageModelBase<HtmlReadonlyListItem>, ICustomerRow
    {
        public CustomerRow(BrowserWindow bw, HtmlReadonlyListItem me) : base(bw, me)
        {
        }

        public string Name => this.Me.Find<HtmlSpan>().WithDataAttribute("id", "name").DisplayText;
        public string State => this.Me.Find<HtmlSpan>().WithDataAttribute("id", "state").DisplayText;
    }
}