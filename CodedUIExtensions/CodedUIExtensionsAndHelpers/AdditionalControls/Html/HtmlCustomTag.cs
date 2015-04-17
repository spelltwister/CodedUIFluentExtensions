using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{    
    /// <summary>
    /// Used to find HTML elements which were not included in the
    /// Microsoft UITesting Html Controls
    /// </summary>
    public class HtmlCustomTag : HtmlCustom
    {
        private void Init()
        {
            this.SearchProperties.Add(PropertyNames.TagName, this._tagName, this._expressionOperator);
        }

        /// <summary>
        /// The expression operator used when comparing tag names
        /// </summary>
        protected readonly PropertyExpressionOperator _expressionOperator;

        /// <summary>
        /// The tag name this control represents
        /// </summary>
        protected readonly string _tagName;

        /// <summary>
        /// Gets a search control that is able to find Html tags when the
        /// specified tag name
        /// </summary>
        /// <param name="tagName">
        /// The tag name this control represents
        /// </param>
        /// <param name="expressionOperator">
        /// The expression operator used when comparing tag names
        /// </param>
        public HtmlCustomTag(string tagName, PropertyExpressionOperator expressionOperator = PropertyExpressionOperator.EqualTo) : base()
        {
            if (String.IsNullOrWhiteSpace(tagName))
            {
                throw new ArgumentException("Tag name cannot be null, empty, or white space.", "tagName");
            }

            this._tagName = tagName;
            this._expressionOperator = expressionOperator;

            Init();
        }

        /// <summary>
        /// Gets a search control that is able to find Html tags when the
        /// specified tag name
        /// </summary>
        /// <param name="parent">
        /// The parent control from which to start searching
        /// </param>
        /// <param name="tagName">
        /// The tag name this control represents
        /// </param>
        /// <param name="expressionOperator">
        /// The expression operator used when comparing tag names
        /// </param>
        public HtmlCustomTag(UITestControl parent, string tagName, PropertyExpressionOperator expressionOperator = PropertyExpressionOperator.EqualTo) : base(parent)
        {
            if (String.IsNullOrWhiteSpace(tagName))
            {
                throw new ArgumentException("Tag name cannot be null, empty, or white space.", "tagName");
            }

            this._tagName = tagName;
            this._expressionOperator = expressionOperator;

            Init();
        }
    }
}