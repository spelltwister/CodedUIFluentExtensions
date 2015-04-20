using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public abstract class WpfHasNextModelPageModelBase<TUIType, TNextModel1> : WpfPageModelBase<TUIType>
        where TUIType : WpfControl
        where TNextModel1 : IPageModel
    {
        protected readonly TNextModel1 NextModel1;

        protected WpfHasNextModelPageModelBase(WpfWindow bw, TNextModel1 nextModel1) : base(bw)
        {
            this.NextModel1 = nextModel1;
        }
    }

    public abstract class WpfHasNextModelPageModelBase<TUIType, TNextModel1, TNextModel2> : WpfHasNextModelPageModelBase<TUIType, TNextModel1>
        where TUIType : WpfControl
        where TNextModel1 : IPageModel
        where TNextModel2 : IPageModel
    {
        protected readonly TNextModel2 NextModel2;

        protected WpfHasNextModelPageModelBase(WpfWindow bw, TNextModel1 nextModel1, TNextModel2 nextModel2)
            : base(bw, nextModel1)
        {
            this.NextModel2 = nextModel2;
        }
    }

    public abstract class WpfHasNextModelPageModelBase<TUIType, TNextModel1, TNextModel2, TNextModel3> : WpfHasNextModelPageModelBase<TUIType, TNextModel1, TNextModel2>
        where TUIType : WpfControl
        where TNextModel1 : IPageModel
        where TNextModel2 : IPageModel
        where TNextModel3 : IPageModel
    {
        protected readonly TNextModel3 NextModel3;

        protected WpfHasNextModelPageModelBase(WpfWindow bw, TNextModel1 nextModel1, TNextModel2 nextModel2, TNextModel3 nextModel3)
            : base(bw, nextModel1, nextModel2)
        {
            this.NextModel3 = nextModel3;
        }
    }
}