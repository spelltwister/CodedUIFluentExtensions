using System;
using System.Collections.Generic;
using System.Linq;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Wpf.ControlWrappers
{
    public class WpfComboBoxControlPageModelWrapper<TValue, TNextModel> : ComboboxControlPageModelWrapper<WpfComboBox, TValue, TNextModel, WpfComboBoxItemControlPageModelWrapper<TValue, TNextModel>>
        where TNextModel : IPageModel
    {
        public  WpfComboBoxControlPageModelWrapper(WpfComboBox toWrap, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc)
            : base(toWrap, nextModel, stringToValueFunc, valueToStringFunc)
        {
        }

        public override IEnumerable<WpfComboBoxItemControlPageModelWrapper<TValue, TNextModel>> Items
        {
            get
            {
                return this.Me.Items
                              .OfType<WpfListItem>()
                              .Select(x => new WpfComboBoxItemControlPageModelWrapper<TValue, TNextModel>(x, this.Me, this.NextModel, this.StringToValueFunc));
            }
        }
    }

    public class WpfComboBoxControlPageModelWrapper<TNextModel> : ComboboxControlPageModelWrapper<WpfComboBox, string, TNextModel, WpfComboBoxItemControlPageModelWrapper<TNextModel>>
        where TNextModel : IPageModel
    {
        public WpfComboBoxControlPageModelWrapper(WpfComboBox toWrap, TNextModel nextModel, Func<string, string> stringToValueFunc, Func<string, string> valueToStringFunc)
            : base(toWrap, nextModel, stringToValueFunc, valueToStringFunc)
        {
        }

        public override IEnumerable<WpfComboBoxItemControlPageModelWrapper<TNextModel>> Items
        {
            get
            {
                return this.Me.Items
                            .OfType<WpfListItem>()
                            .Select(x => new WpfComboBoxItemControlPageModelWrapper<TNextModel>(x, this.Me, this.NextModel));
            }
        }
    }

    public class WpfComboBoxItemControlPageModelWrapper<TValue, TNextModel> : ComboboxItemControlPageModelWrapper<WpfListItem, WpfComboBox, TValue, TNextModel>
        where TNextModel : IPageModel
    {
        public WpfComboBoxItemControlPageModelWrapper(WpfListItem control, WpfComboBox comboBox, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<WpfListItem, string> itemToStringFunc)
            : base(control, comboBox, nextModel, stringToValueFunc, itemToStringFunc)
        {
        }
        public WpfComboBoxItemControlPageModelWrapper(WpfListItem control, WpfComboBox comboBox, TNextModel nextModel, Func<string, TValue> stringToValueFunc)
            : this(control, comboBox, nextModel, stringToValueFunc, x => x.Name)
        {
        }

        public override string Name => Me.DisplayText;

	    public override bool IsSelected => Me.Selected;

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

    public class WpfComboBoxItemControlPageModelWrapper<TNextModel> : WpfComboBoxItemControlPageModelWrapper<string, TNextModel>
        where TNextModel : IPageModel
    {
        public WpfComboBoxItemControlPageModelWrapper(WpfListItem control, WpfComboBox comboBox, TNextModel nextModel)
            : base(control, comboBox, nextModel, x => x)
        {
        }
    }
}