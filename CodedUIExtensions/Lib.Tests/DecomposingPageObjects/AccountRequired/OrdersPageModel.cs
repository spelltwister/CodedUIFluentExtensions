using System.Collections.Generic;
using System.Linq;
using CaptainPav.Testing.UI.CodedUI;
using CaptainPav.Testing.UI.CodedUI.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Lib.Tests.DecomposingPageObjects.AccountRequired
{
    public interface IOrdersPageModel : ILayoutPageModel
    {
        IClickablePageModel<IOrdersPageModel> AddButton { get; }
        IClickablePageModel<IOrdersPageModel> CancelButton { get; }

        IReadWriteValuePageModel<string, IOrdersPageModel> OrderId { get; }
        IReadWriteValuePageModel<string, IOrdersPageModel> Name { get; }

        IReadWriteTextValuePageModel<int?, IOrdersPageModel> Quantity { get; }
        IReadWriteTextValuePageModel<decimal?, IOrdersPageModel> Price { get; }

        IClickablePageModel<IOrdersPageModel> Save { get; }

        IEnumerable<IOrdersRowPageModel> OrdersList { get; }
    }

    public class OrdersPageModel : HtmlPageModelBase<HtmlDiv>, IOrdersPageModel
    {
        public OrdersPageModel(BrowserWindow bw) : base(bw)
        {
        }

        protected override HtmlDiv Me => this.parent.Find<HtmlDiv>("ordersControl");

        public IClickablePageModel<IOrdersPageModel> AddButton 
            => this.Me
                .Find<HtmlButton>(HtmlButton.PropertyNames.InnerText, "Add", PropertyExpressionOperator.EqualTo)
                .AsPageModel(this);

        public IClickablePageModel<IOrdersPageModel> CancelButton
            => this.Me
                .Find<HtmlButton>(HtmlButton.PropertyNames.InnerText, "Cancel", PropertyExpressionOperator.EqualTo)
                .AsPageModel(this);

        public IReadWriteValuePageModel<string, IOrdersPageModel> OrderId
            => this.Me
                .Find<HtmlEdit>(HtmlEdit.PropertyNames.ControlDefinition, "orderId", PropertyExpressionOperator.Contains)
                .AsPageModel(this);

        public IReadWriteValuePageModel<string, IOrdersPageModel> Name
            => this.Me
                .Find<HtmlEdit>(HtmlEdit.PropertyNames.ControlDefinition, "name", PropertyExpressionOperator.Contains)
                .AsPageModel(this);

        public IReadWriteTextValuePageModel<int?, IOrdersPageModel> Quantity
            => this.Me
                .Find<HtmlEdit>(HtmlEdit.PropertyNames.ControlDefinition, "quantity", PropertyExpressionOperator.Contains)
                .AsPageModel(this, s => { int q;
                                            if (!int.TryParse(s, out q)) return null;
                                            return (int?)q;
                }, i => i.HasValue ? i.Value.ToString("D") : "");

        public IReadWriteTextValuePageModel<decimal?, IOrdersPageModel> Price
            => this.Me
                .Find<HtmlEdit>(HtmlEdit.PropertyNames.ControlDefinition, "price", PropertyExpressionOperator.Contains)
                .AsPageModel(this, s => {
                                            decimal q;
                                            if (!decimal.TryParse(s, out q)) return null;
                                            return (decimal?)q;
                }, i => i.HasValue ? i.Value.ToString("N2") : "");

        public IClickablePageModel<IOrdersPageModel> Save
            => this.Me
                .Find<HtmlButton>(HtmlButton.PropertyNames.DisplayText, "Save", PropertyExpressionOperator.EqualTo)
                .AsPageModel(this);

        public IEnumerable<IOrdersRowPageModel> OrdersList
            => this.Me
                .FindAll<HtmlReadonlyListItem>()
                .Select(x => new OrdersRowPageModel(this.parent, x, this));

        public INavPageModel Nav => new NavPageModel(this.parent, this.Me.Find<HtmlNavigation>());
    }
}