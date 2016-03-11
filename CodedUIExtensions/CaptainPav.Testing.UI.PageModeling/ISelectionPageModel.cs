using System.Collections.Generic;

namespace CaptainPav.Testing.UI.PageModeling
{
    /// <summary>
    /// Interface describing a list of items for selection
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value represented by the list items
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// The most likely next model the user will interact with after making
    /// a selection
    /// </typeparam>
    /// <typeparam name="TListItem">
    /// Type of PageModel item in the list
    /// </typeparam>
    /// <remarks>
    /// This interface is best used to describe selection lists which may
    /// not contain textual representation of each item to the user and/or does
    /// not use a standard list item type given the platform.
    /// 
    /// Eg, a list of colors where each item simply shows the color to select.
    /// Eg, a list comprised of HtmlDivs where clicking a div performs the
    ///     selection and selection is tracked by (possibly) data-* attribute(s).
    /// </remarks>
    public interface ISelectionPageModel<out TValue, out TNextModel, out TListItem> : IPageModel // TODO: THIS IS NOT DONE
        where TNextModel : IPageModel
        where TListItem : ISelectablePageModel<TNextModel>, IValuedPageModel<TValue>
    {
        /// <summary>
        /// Gets the selected item or null if no selection is made
        /// </summary>
        TListItem SelectedItem { get; }

        /// <summary>
        /// Gets the collection of items in the selection list
        /// </summary>
        IEnumerable<TListItem> Items { get; }
    }

    /// <summary>
    /// Default selection model that uses <see cref="ISelectionItemPageModel{TValue,TNextModel}"/> as the list item type
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value represented by the list items
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// The most likely next model the user will interact with after making
    /// a selection
    /// </typeparam>
    /// <remarks>
    /// This simplification is used when the selection list contains standard
    /// list items, but those items do not have a textual representation
    /// displayed to the user.
    /// 
    /// Eg, a list of colors where each item simply shows the color to select.
    /// </remarks>
    public interface ISelectionPageModel<out TValue, out TNextModel> : ISelectionPageModel<TValue, TNextModel, ISelectionItemPageModel<TValue, TNextModel>>
        where TNextModel : IPageModel
    {
    }

    /// <summary>
    /// Interface describing an item in a list that can be selected
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value stored in this list item
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// The most likely next model the user will interact with after selecting
    /// this item
    /// </typeparam>
    public interface ISelectionItemPageModel<out TValue, out TNextModel> : ISelectablePageModel<TNextModel>, IValuedPageModel<TValue>
        where TNextModel : IPageModel
    {
    }

    /// <summary>
    /// Interface describing a list of items available for selection
    /// which have a textual representation shown to the user
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value represented by the list items
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// The most likely next model the user will interact with after making
    /// a selection
    /// </typeparam>
    /// <typeparam name="TListItem">
    /// Type of PageModel item in the list
    /// </typeparam>
    /// <remarks>
    /// This interface further constrains the list item type to require a name
    /// for each item in the list.  The name is the textual representation shown
    /// to the user.
    /// 
    /// This interface would be used when the item type is not a standard list
    /// item type.
    /// </remarks>
    public interface INamedSelectionPageModel<out TValue, out TNextModel, out TListItem> : ISelectionPageModel<TValue, TNextModel, TListItem>, INamedPageModel
        where TNextModel : IPageModel
        where TListItem : ISelectablePageModel<TNextModel>, IValuedPageModel<TValue>, INamedPageModel
    {
    }

    /// <summary>
    /// Default named selection model that uses <see cref="INamedSelectionItemPageModel{TValue,TNextModel}"/> as the list item type
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value represented by the list items
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// The most likely next model the user will interact with after making
    /// a selection
    /// </typeparam>
    /// <remarks>
    /// This is likely the most common type of selection model where each item
    /// has a Name value displayed to the user and a backing value that is
    /// actually used when the item is selected.
    /// </remarks>
    public interface INamedSelectionPageModel<out TValue, out TNextModel> : INamedSelectionPageModel<TValue, TNextModel, INamedSelectionItemPageModel<TValue, TNextModel>>
        where TNextModel : IPageModel
    {
    }

    /// <summary>
    /// Interface describing an item in a list that can be selected which has a
    /// Name that can be displayed to the user
    /// </summary>
    /// <typeparam name="TValue">
    /// Type of value stored in this list item
    /// </typeparam>
    /// <typeparam name="TNextModel">
    /// The most likely next model the user will interact with after selecting
    /// this item
    /// </typeparam>
    public interface INamedSelectionItemPageModel<out TValue, out TNextModel> : ISelectionItemPageModel<TValue, TNextModel>, ISelectablePageModel<TNextModel>, IValuedPageModel<TValue>, INamedPageModel
        where TNextModel : IPageModel
    {
    }
}