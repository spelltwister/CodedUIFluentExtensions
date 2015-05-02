using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    internal class WpfTabListControlPageModelWrapper<TNextModel> : TextControlPageModelWrapperBase<WpfTabList, string, TNextModel>, ISelectionPageModel<string, TNextModel>
        where TNextModel : IPageModel
    {
        public WpfTabListControlPageModelWrapper(WpfTabList control, TNextModel nextModel)
            : base(control, nextModel, StandardFunctionProvider.StringReturnSelf, StandardFunctionProvider.StringReturnSelf)
        {
        }

        public override string ValueText
        {
            get { throw new NotImplementedException(); }
        }

        public override TNextModel SetValueText(string toValue)
        {
            throw new NotImplementedException();
        }

        public INamedSelectablePageModel<TNextModel> SelectedItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<INamedSelectablePageModel<TNextModel>> Items
        {
            get { throw new NotImplementedException(); }
        }
    }
}