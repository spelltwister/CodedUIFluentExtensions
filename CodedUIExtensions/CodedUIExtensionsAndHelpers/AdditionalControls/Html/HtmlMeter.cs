using System;
using CodedUIExtensionsAndHelpers.Fluent;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIExtensionsAndHelpers.AdditionalControls.Html
{
    public class HtmlMeter : HtmlCustomTag
    {
        public static readonly string MeterTag = "meter";
        public static readonly string FormAttributeName = "form";
        public static readonly string MinAttributeName = "min";
        public static readonly string MaxAttributeName = "max";
        public static readonly string LowAttributeName = "low";
        public static readonly string HighAttributeName = "high";
        public static readonly string OptimumAttributeName = "optimum";

        public HtmlMeter() : base(MeterTag) { }
        public HtmlMeter(UITestControl parent) : base(parent, MeterTag) { }

        public string Form
        {
            get
            {
                return this.GetPropertyOrDefault("form", null);
            }
        }

        public double Value
        {
            get
            {
                return Double.Parse(this.ValueAttribute);
            }
        }

        public double? Min
        {
            get
            {
                return GetNullableProperty(MinAttributeName);
            }
        }

        public double? Max
        {
            get
            {
                return GetNullableProperty(MaxAttributeName);
            }
        }

        public double? Low
        {
            get
            {
                return GetNullableProperty(LowAttributeName);
            }
        }

        public double? High
        {
            get
            {
                return GetNullableProperty(HighAttributeName);
            }
        }

        public double? Optimum
        {
            get
            {
                return GetNullableProperty(OptimumAttributeName);
            }
        }

        protected double? GetNullableProperty(string propertyName)
        {
            string valueString;
            if (!this.TryGetProperty(propertyName, out valueString))
            {
                return null;
            }
            return Double.Parse(valueString);
        }
    }
}