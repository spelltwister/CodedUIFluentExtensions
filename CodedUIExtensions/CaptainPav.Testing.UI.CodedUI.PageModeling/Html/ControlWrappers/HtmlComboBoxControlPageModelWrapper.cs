using System;
using System.Collections.Generic;
using System.Linq;
using CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Html.ControlWrappers
{
    public class HtmlComboBoxControlPageModelWrapper<TValue, TNextModel> : TextValuableControlPageModelWrapperBase<HtmlComboBox, TValue, TNextModel>, ISelectionPageModel<TValue, TNextModel>, ITextValueablePageModel<TValue, TNextModel> where TNextModel : IPageModel
    {
        public HtmlComboBoxControlPageModelWrapper(HtmlComboBox toWrap, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc)
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

        public IEnumerable<INamedSelectablePageModel<TNextModel>> Items
        {
            get
            {
                return this.Me.Items
                              .OfType<HtmlListItem>()
                              .Select(x => new HtmlComboBoxItemControlPageModelWrapper<TNextModel>(x, this.Me, this.NextModel));
            }
        }
    }

    public class HtmlComboBoxItemControlPageModelWrapper<TNextModel> : NamedSelectableControlPageModelWrapper<HtmlListItem, TNextModel>
        where TNextModel : IPageModel
    {
        protected readonly HtmlComboBox Container;
        public HtmlComboBoxItemControlPageModelWrapper(HtmlListItem control, HtmlComboBox comboBox, TNextModel nextModel) : base(control, nextModel)
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
}