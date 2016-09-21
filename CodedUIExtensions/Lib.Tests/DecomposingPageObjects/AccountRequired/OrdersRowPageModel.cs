using CaptainPav.Testing.UI.CodedUI;
using CaptainPav.Testing.UI.CodedUI.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html;
using CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Lib.Tests.DecomposingPageObjects.AccountRequired
{
    public interface IOrdersRowPageModel : IPageModel
    {
        IValuedPageModel<string> OrderId { get; }
        IValuedPageModel<string> Name { get; }

        ITextValuedPageModel<int> Quantity { get; }
        ITextValuedPageModel<decimal> Price { get; }

        IClickablePageModel<IOrdersPageModel> Remove { get; }
    }

    public class OrdersRowPageModel : HtmlChildPageModelBase<HtmlReadonlyListItem>, IOrdersRowPageModel
    {
        protected readonly IOrdersPageModel ordersPageParent;

        public OrdersRowPageModel(BrowserWindow bw, HtmlReadonlyListItem me, IOrdersPageModel ordersPageModel) : base(bw, me)
        {
            this.ordersPageParent = ordersPageModel;
        }

        public IValuedPageModel<string> OrderId 
            => this.Me
                .Find<HtmlSpan>(HtmlSpan.PropertyNames.ControlDefinition, "orderId", PropertyExpressionOperator.Contains)
                .AsValuedPageModel(x => x.DisplayText);

        public IValuedPageModel<string> Name
            => this.Me
                .Find<HtmlSpan>(HtmlSpan.PropertyNames.ControlDefinition, "name", PropertyExpressionOperator.Contains)
                .AsValuedPageModel(x => x.DisplayText);

        public ITextValuedPageModel<int> Quantity
            => this.Me
                .Find<HtmlSpan>(HtmlSpan.PropertyNames.ControlDefinition, "quantity", PropertyExpressionOperator.Contains)
                .AsTextValuedPageModel(int.Parse);

        public ITextValuedPageModel<decimal> Price
            => this.Me
                .Find<HtmlSpan>(HtmlSpan.PropertyNames.ControlDefinition, "price", PropertyExpressionOperator.Contains)
                .AsTextValuedPageModel(decimal.Parse);

        public IClickablePageModel<IOrdersPageModel> Remove
            => this.Me
                .Find<HtmlButton>(HtmlButton.PropertyNames.InnerText, "Delete", PropertyExpressionOperator.EqualTo)
                .AsPageModel(this.ordersPageParent);
    }
}