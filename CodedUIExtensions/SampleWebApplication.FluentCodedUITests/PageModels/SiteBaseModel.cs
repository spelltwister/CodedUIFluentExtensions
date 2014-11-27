using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodedUIPageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace SampleWebApplication.FluentCodedUITests.PageModels
{
    public class SiteBaseModel : HtmlDocumentPageModelBase
    {
        public SiteBaseModel(BrowserWindow bw) : base(bw) { }

        public NavigationStripBaseModel NavStrip
        {
            get { return new NavigationStripBaseModel(this.parent); }
        }
    }
}