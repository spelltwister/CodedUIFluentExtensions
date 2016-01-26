using System;
using System.Collections.Generic;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf.ControlWrappers
{
    internal class WpfTabListControlPageModelWrapper<TNextModel, TSelectionType> : TextValuableControlPageModelWrapperBase<WpfTabList, string, TNextModel>, ISelectionPageModel<string, TNextModel, TSelectionType>
        where TSelectionType : ISelectablePageModel<TNextModel>, IValuedPageModel<string>
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

        public TSelectionType SelectedItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<TSelectionType> Items
        {
            get { throw new NotImplementedException(); }
        }
    }
}