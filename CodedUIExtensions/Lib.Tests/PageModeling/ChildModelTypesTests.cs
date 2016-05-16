using System.Linq;
using Lib.Tests.PageModeling.PageModels;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Tests.PageModeling
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class ChildModelTypesTests
    {
        private ICustomerNewsPage model;
        public ChildModelTypesTests()
        {
        }

        [TestInitialize]
        public void NavigateToSimpleHtmlControlExamplesPage()
        {
            //BrowserWindow.CurrentBrowser = "Chrome";
            this.model = new CustomerNewsPage(BrowserWindow.Launch("http://codeduiexamples.com/Examples/Example2"));
        }

        [TestMethod]
        public void WhenFilteringByName_ThenAllResultsContainThatName()
        {
            var goodCustomers = this.model.GoodCustomers;
            goodCustomers.SearchCriteria
                         .CustomerName.SetValue("J")
                         .Search.Click();

            if (!goodCustomers.SearchResults.Customers.Any())
            {
                Assert.Inconclusive();
            }

            Assert.IsTrue(goodCustomers.SearchResults.Customers.All(x => x.Name.Contains("J")));
        }
    }
}