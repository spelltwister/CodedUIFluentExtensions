using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUIExtensionsAndHelpers.PageModeling
{
    public class WpfComboBoxControlPageModelWrapper<TValue, TNextModel> : TextControlPageModelWrapperBase<WpfComboBox, TValue, TNextModel>, ISelectionPageModel<TValue, TNextModel>
        where TNextModel : IPageModel
    {
        public  WpfComboBoxControlPageModelWrapper(WpfComboBox toWrap, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc)
            : base(toWrap, nextModel, stringToValueFunc, valueToStringFunc)
        {
        }

        public override string ValueText
        {
            get { return null != this.SelectedItem ? this.SelectedItem.Name : null; }
        }

        public override TNextModel SetValueText(string toValue)
        {
            return this.Items.Single(x => StringComparer.Ordinal.Equals(toValue, x.Name)).SetSelected(true);

            // TODO: compare with
            //Me.SelectedItem = toValue;
            //return NextModel;
        }

        public INamedSelectablePageModel<TNextModel> SelectedItem
        {
            get { return this.Items.SingleOrDefault(x => x.IsSelected); }
        }

        public System.Collections.Generic.IEnumerable<INamedSelectablePageModel<TNextModel>> Items
        {
            get
            {
                return this.Me.Items
                              .OfType<WpfListItem>()
                              .Select(x => new WpfComboBoxItemControlPageModelWrapper<TNextModel>(x, this.Me, this.NextModel));
            }
        }
    }

    public class WpfComboBoxItemControlPageModelWrapper<TNextModel> : NamedSelectableControlPageModelWrapper<WpfListItem, TNextModel>
        where TNextModel : IPageModel
    {
        protected readonly WpfComboBox Container;
        public WpfComboBoxItemControlPageModelWrapper(WpfListItem control, WpfComboBox comboBox, TNextModel nextModel) : base(control, nextModel)
        {
            this.Container = comboBox;
        }

        public override string Name
        {
            get { return Me.DisplayText; }
        }

        public override bool IsSelected
        {
            get { return Me.Selected; }
        }

        public override TNextModel SetSelected(bool selectionState)
        {
            if (selectionState && !this.IsSelected)
            {
                Me.Select();
            }

            if (!selectionState && this.IsSelected)
            {
                this.Container.SelectedIndex = -1;
            }
            return this.NextModel;
        }
    }
}