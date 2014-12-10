using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleWebApplication.CodedUITests.PageModels;

namespace SampleWebApplication.CodedUITests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class RegisterAndLoginTests
    {
        private static readonly string CodedUIExamplesWebsiteHome = "http://codeduiexamples.azurewebsites.net/Home/Index";
        private static readonly string LocalhostWebsiteHome = "http://localhost:49355/Home/Index";
        private static Random r = new Random(DateTime.Now.Second);
        private Lazy<BrowserWindow> _window = new Lazy<BrowserWindow>(() =>
            {
                //BrowserWindow.CurrentBrowser = "Chrome";
                return BrowserWindow.Launch(LocalhostWebsiteHome);
            });
        private BrowserWindow Window { get { return this._window.Value; } }

        public RegisterAndLoginTests()
        {
        }

        [TestMethod]
        public void RegistrationTest()
        {
            var registerModel = new SiteBaseModel(this.Window).NavStrip
                                                              .LoginOrLogoff()
                                                              .ClickRegisterLink();
            Func<List<Action<RegisterPageModel>>, HomePageModel> testingFunction = x =>
            {
                foreach (var t in x)
                {
                    t(registerModel);
                }
                return registerModel.ClickRegisterButton();
            };
            List<Action<RegisterPageModel>> actionList = new List<Action<RegisterPageModel>>(5);

            var homePageModel = testingFunction(actionList);
            Assert.IsTrue(registerModel.IsVisible(), "Registration should have failed.");

            string emailString = String.Format("e{0}@email.com", r.Next(int.MaxValue - 1));
            actionList.Add(x => x.SetEmail(emailString));
            homePageModel = testingFunction(actionList);
            Assert.IsTrue(registerModel.IsVisible(), "Registration should have failed.");

            actionList.Add(x => x.SetHometown("My Hometown"));
            homePageModel = testingFunction(actionList);
            Assert.IsTrue(registerModel.IsVisible(), "Registration should have failed.");

            actionList.Add(x => x.SetPassword("aA!234"));
            homePageModel = testingFunction(actionList);
            Assert.IsTrue(registerModel.IsVisible(), "Registration should have failed.");

            actionList.Add(x => x.SetConfirmPassword("abc123"));
            homePageModel = testingFunction(actionList);
            Assert.IsTrue(registerModel.IsVisible(), "Registration should have failed.");

            actionList.Add(x => x.SetConfirmPassword("aA!234"));
            homePageModel = testingFunction(actionList);
            Assert.IsTrue(homePageModel.IsVisible(), "Registration should have succeeded.");
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}