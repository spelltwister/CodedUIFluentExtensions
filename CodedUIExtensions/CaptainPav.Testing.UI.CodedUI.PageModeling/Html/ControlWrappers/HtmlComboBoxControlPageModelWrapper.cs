using System;
using System.Collections.Generic;
using System.Linq;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers
{
    public class HtmlComboBoxControlPageModelWrapper<TValue, TNextModel> : ComboboxControlPageModelWrapper<HtmlComboBox, TValue, TNextModel, HtmlComboBoxItemControlPageModelWrapper<TValue, TNextModel>>
        where TNextModel : IPageModel
    {
        public HtmlComboBoxControlPageModelWrapper(HtmlComboBox toWrap, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc)
            : base(toWrap, nextModel, stringToValueFunc, valueToStringFunc)
        {
        }

        public override IEnumerable<HtmlComboBoxItemControlPageModelWrapper<TValue, TNextModel>> Items
        {
            get
            {
                return this.Me.Items
                              .OfType<HtmlListItem>()
                              .Select(x => new HtmlComboBoxItemControlPageModelWrapper<TValue, TNextModel>(x, this.Me, this.NextModel, this.StringToValueFunc));
            }
        }
    }

    public class HtmlComboBoxControlPageModelWrapper<TNextModel> : ComboboxControlPageModelWrapper<HtmlComboBox, string, TNextModel, HtmlComboBoxItemControlPageModelWrapper<TNextModel>>
        where TNextModel : IPageModel
    {
        public HtmlComboBoxControlPageModelWrapper(HtmlComboBox toWrap, TNextModel nextModel, Func<string, string> stringToValueFunc, Func<string, string> valueToStringFunc)
            : base(toWrap, nextModel, stringToValueFunc, valueToStringFunc)
        {
        }

        public override IEnumerable<HtmlComboBoxItemControlPageModelWrapper<TNextModel>> Items
        {
            get
            {
                return this.Me.Items
                              .OfType<HtmlListItem>()
                              .Select(x => new HtmlComboBoxItemControlPageModelWrapper<TNextModel>(x, this.Me, this.NextModel));
            }
        }
    }


    public class HtmlComboBoxItemControlPageModelWrapper<TValue, TNextModel> : ComboboxItemControlPageModelWrapper<HtmlListItem, HtmlComboBox, TValue, TNextModel>
        where TNextModel : IPageModel
    {
        public HtmlComboBoxItemControlPageModelWrapper(HtmlListItem control, HtmlComboBox comboBox, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<HtmlListItem, string> itemToStringFunc) : base(control, comboBox, nextModel, stringToValueFunc, itemToStringFunc)
        {
        }
        public HtmlComboBoxItemControlPageModelWrapper(HtmlListItem control, HtmlComboBox comboBox, TNextModel nextModel, Func<string, TValue> stringToValueFunc) : this(control, comboBox, nextModel, stringToValueFunc, x => x.Name)
        {
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
                BrowserWindow parentWindow = this._control.TopParent as BrowserWindow;
                if (parentWindow != null && parentWindow.Process.ProcessName == "iexplore")
                {
                    dynamic test = this.Container.NativeElement;
                    test.selectedIndex = -1;
                }
                else
                {
                    throw new NotSupportedException("Deselecting an item in a combobox is only supported in IE.");
                }
            }
            return this.NextModel;
        }
    }

    public class HtmlComboBoxItemControlPageModelWrapper<TNextModel> : HtmlComboBoxItemControlPageModelWrapper<string, TNextModel>
        where TNextModel : IPageModel
    {
        public HtmlComboBoxItemControlPageModelWrapper(HtmlListItem control, HtmlComboBox comboBox, TNextModel nextModel) : base(control, comboBox, nextModel, x => x)
        {
        }
    }
}