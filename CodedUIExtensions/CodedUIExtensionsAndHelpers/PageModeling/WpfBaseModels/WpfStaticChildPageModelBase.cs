using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    /// <summary>
    /// Base type for models which can find themselves given some parent model
    /// </summary>
    /// <typeparam name="T">
    /// Type of HtmlControl that implements this model
    /// </typeparam>
    /// <typeparam name="TParent">
    /// Type of parent page model
    /// </typeparam>
    /// <typeparam name="TParentType">
    /// Type of UIControl that implements the parent page model
    /// </typeparam>
    public abstract class WpfStaticChildPageModelBase<T, TParent, TParentType> : WpfPageModelBase<T> where T : WpfControl
                                                                                                     where TParent : PageModelBase<TParentType>
                                                                                                     where TParentType : UITestControl
    {
        protected readonly TParent parentModel;

        protected WpfStaticChildPageModelBase(WpfWindow bw, TParent parentModel) : base(bw)
        {
            if (null == parentModel)
            {
                throw new ArgumentNullException("parentModel");
            }
            this.parentModel = parentModel;
        }

        protected TParentType ParentScope { get { return this.parentModel.Me; } }
    }
}