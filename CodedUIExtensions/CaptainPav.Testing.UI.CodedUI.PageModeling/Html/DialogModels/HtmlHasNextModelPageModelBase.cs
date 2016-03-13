using System;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.DialogModels
{
    public abstract class HtmlHasNextModelPageModelBase<TUIType, TNextModel1> : HtmlPageModelBase<TUIType>
        where TUIType : HtmlControl
        where TNextModel1 : IPageModel
    {
        protected TNextModel1 NextModel1 { get; }

        protected HtmlHasNextModelPageModelBase(BrowserWindow bw, TNextModel1 nextModel1) : base(bw)
        {
            if (null == nextModel1)
            {
                throw new ArgumentNullException(nameof(nextModel1));
            }

            this.NextModel1 = nextModel1;
        }
    }

    public abstract class HtmlHasNextModelPageModelBase<TUIType, TNextModel1, TNextModel2> : HtmlHasNextModelPageModelBase<TUIType, TNextModel1>
        where TUIType : HtmlControl
        where TNextModel1 : IPageModel
        where TNextModel2 : IPageModel
    {
        protected TNextModel2 NextModel2 { get; }

        protected HtmlHasNextModelPageModelBase(BrowserWindow bw, TNextModel1 nextModel1, TNextModel2 nextModel2)
            : base(bw, nextModel1)
        {
            if (null == nextModel2)
            {
                throw new ArgumentNullException(nameof(nextModel2));
            }

            this.NextModel2 = nextModel2;
        }
    }

    public abstract class HtmlHasNextModelPageModelBase<TUIType, TNextModel1, TNextModel2, TNextModel3> : HtmlHasNextModelPageModelBase<TUIType, TNextModel1, TNextModel2>
        where TUIType : HtmlControl
        where TNextModel1 : IPageModel
        where TNextModel2 : IPageModel
        where TNextModel3 : IPageModel
    {
        protected TNextModel3 NextModel3 { get; }

        protected HtmlHasNextModelPageModelBase(BrowserWindow bw, TNextModel1 nextModel1, TNextModel2 nextModel2, TNextModel3 nextModel3)
            : base(bw, nextModel1, nextModel2)
        {
            if (null == nextModel3)
            {
                throw new ArgumentNullException(nameof(nextModel3));
            }

            this.NextModel3 = nextModel3;
        }
    }
}