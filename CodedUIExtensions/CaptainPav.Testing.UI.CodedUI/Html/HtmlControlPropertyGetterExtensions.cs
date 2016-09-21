using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CaptainPav.Testing.UI.CodedUI.Html
{
    public static class HtmlControlPropertyGetterExtensions
    {
        public static bool TryGetProperty(this HtmlControl control, string propertyName, out string propertyValue)
        {
            return control.TryGetProperty<string>(propertyName, out propertyValue);
        }

	    public static bool TryGetProperty<T>(this HtmlControl control, string propertyName, Func<string, T> transformFunc, out T propertyValue)
	    {
		    string propertyString;
		    if (!control.TryGetProperty(propertyName, out propertyString))
		    {
			    propertyValue = default(T);
			    return false;
		    }

		    try
		    {
			    propertyValue = transformFunc(propertyString);
		    }
		    catch
		    {
			    propertyValue = default(T);
			    return false;
		    }

		    return true;
	    }

        public static string GetPropertyOrDefault(this HtmlControl control, string propertyName, string defaultValue)
        {
            string ret;
            control.GetPropertyOrDefault(propertyName, defaultValue, out ret);
            return ret;
        }

        // TODO: ensure that properties without values return true (eg, &lt;details open&gt;)
        public static bool HasProperty(this HtmlControl control, string propertyName)
        {
            object obj;
            return control.TryGetProperty(propertyName, out obj);
        }

	    internal static IDictionary<string, string> GetDataAttributes(this HtmlControl control)
	    {
			throw new NotImplementedException();
			// examples...
			// <div data-attribute="value" />   => [<div, data-attribute="value", />]
			// <div data-attribute ="value" />  => [<div, data-attribute, ="value", />]
			// <div data-attribute />           => [<div, data-attribute, />]
			// <div data-attribute = "value" /> => [<div, data-attribute, =, "value" />]
			// <div data-attribute= "value" />  => [<div, data-attribute=, "value", />]
			// <div data-attribute="value">     => [<div, data-attribute=, "value">]

			Dictionary<string, string> ret = new Dictionary<string, string>();

			// TODO: fill dictionary

		    return ret;
	    } 
    }
}