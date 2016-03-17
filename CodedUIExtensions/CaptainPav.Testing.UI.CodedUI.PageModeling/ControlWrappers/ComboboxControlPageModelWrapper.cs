using System;
using System.Linq;
using CaptainPav.Testing.UI.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.PageModeling.ControlWrappers
{
    public abstract class ComboboxControlPageModelWrapper<TUIType, TValue, TNextModel, TSelectionType> : TextValuableControlPageModelWrapperBase<TUIType, TValue, TNextModel>,
        ISelectionPageModel<TValue, TNextModel, TSelectionType>, ITextValueablePageModel<TValue, TNextModel>,
        INamedSelectionPageModel<TValue, TNextModel, TSelectionType>
        where TUIType : UITestControl
        where TNextModel : IPageModel
        where TSelectionType : ISelectablePageModel<TNextModel>, IValuedPageModel<TValue>, INamedPageModel
    {
        protected ComboboxControlPageModelWrapper(TUIType control, TNextModel nextModel, Func<string, TValue> stringToValueFunc, Func<TValue, string> valueToStringFunc) : base(control, nextModel, stringToValueFunc, valueToStringFunc)
        {
        }

        public override string ValueText => null != this.SelectedItem ? this.SelectedItem.Name : null;

	    public override TNextModel SetValueText(string toValue)
        {
            return this.Items.Single(x => StringComparer.Ordinal.Equals(toValue, (string) x.Name)).SetSelected(true);

            // TODO: compare with
            //Me.SelectedItem = toValue;
            //return NextModel;
        }

        public TSelectionType SelectedItem
        {
            get { return this.Items.SingleOrDefault(x => x.IsSelected); }
        }

        abstract public System.Collections.Generic.IEnumerable<TSelectionType> Items { get; }
    }

    public abstract class ComboboxItemControlPageModelWrapper<TUIType, TUIParentType, TValue, TNextModel> :
        NamedSelectableControlPageModelWrapper<TUIType, TNextModel>, ITextValuedPageModel<TValue>
        where TUIType : UITestControl
        where TUIParentType : UITestControl
        where TNextModel : IPageModel
    {
        protected readonly TUIParentType Container;
        private readonly TextValuedControlPageModelWrapper<TUIType, TValue> TextValuedHelper;
 
        protected ComboboxItemControlPageModelWrapper(TUIType itemControl, TUIParentType parentControl, TNextModel nextModel,
            Func<string, TValue> stringToValueFunc, Func<TUIType, string> itemToStringFunc) : base(itemControl, nextModel)
        {
            this.Container = parentControl;
            this.TextValuedHelper = new TextValuedControlPageModelWrapper<TUIType, TValue>(itemControl, stringToValueFunc, itemToStringFunc);
        }

        public string ValueText => this.TextValuedHelper.ValueText;

	    public TValue Value => this.TextValuedHelper.Value;
    }
}