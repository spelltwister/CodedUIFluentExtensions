using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public abstract class HtmlHasNextModelPageModelBase<TUIType, TNextModel1> : HtmlPageModelBase<TUIType>
        where TUIType : HtmlControl
        where TNextModel1 : IPageModel
    {
        protected readonly TNextModel1 NextModel1;

        protected HtmlHasNextModelPageModelBase(BrowserWindow bw, TNextModel1 nextModel1) : base(bw)
        {
            this.NextModel1 = nextModel1;
        }
    }

    public abstract class HtmlHasNextModelPageModelBase<TUIType, TNextModel1, TNextModel2> : HtmlHasNextModelPageModelBase<TUIType, TNextModel1>
        where TUIType : HtmlControl
        where TNextModel1 : IPageModel
        where TNextModel2 : IPageModel
    {
        protected readonly TNextModel2 NextModel2;

        protected HtmlHasNextModelPageModelBase(BrowserWindow bw, TNextModel1 nextModel1, TNextModel2 nextModel2)
            : base(bw, nextModel1)
        {
            this.NextModel2 = nextModel2;
        }
    }

    public abstract class HtmlHasNextModelPageModelBase<TUIType, TNextModel1, TNextModel2, TNextModel3> : HtmlHasNextModelPageModelBase<TUIType, TNextModel1, TNextModel2>
        where TUIType : HtmlControl
        where TNextModel1 : IPageModel
        where TNextModel2 : IPageModel
        where TNextModel3 : IPageModel
    {
        protected readonly TNextModel3 NextModel3;

        protected HtmlHasNextModelPageModelBase(BrowserWindow bw, TNextModel1 nextModel1, TNextModel2 nextModel2, TNextModel3 nextModel3)
            : base(bw, nextModel1, nextModel2)
        {
            this.NextModel3 = nextModel3;
        }
    }
}