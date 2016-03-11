using System;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CaptainPav.Testing.UI.CodedUI.Html
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

        public string Form => this.GetPropertyOrDefault("form", null);

	    public double Value => Double.Parse(this.ValueAttribute);

	    public double? Min => GetNullableProperty(MinAttributeName);

	    public double? Max => GetNullableProperty(MaxAttributeName);

	    public double? Low => GetNullableProperty(LowAttributeName);

	    public double? High => GetNullableProperty(HighAttributeName);

	    public double? Optimum => GetNullableProperty(OptimumAttributeName);

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