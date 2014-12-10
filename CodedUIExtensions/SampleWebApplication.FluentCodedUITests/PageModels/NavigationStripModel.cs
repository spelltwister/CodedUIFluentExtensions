using CodedUIExtensionsAndHelpers.AdditionalControls.Html;
using CodedUIExtensionsAndHelpers.Fluent;
using CodedUIExtensionsAndHelpers.PageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System.Collections.Generic;
using System.Linq;

namespace SampleWebApplication.FluentCodedUITests.PageModels
{
    public class NavigationStripBaseModel : HtmlPageModelBase<HtmlDiv>
    {
        public NavigationStripBaseModel(BrowserWindow bw) : base(bw) { }
        protected override HtmlDiv Me
        {
            get
            {
                return this.DocumentWindow
                           .Find<HtmlDiv>(HtmlControl.PropertyNames.Class, "navbar", PropertyExpressionOperator.Contains);
            }
        }

        protected HtmlHyperlink ApplicationNameLink
        {
            get
            {
                return this.Me
                           .Find<HtmlHyperlink>(HtmlControl.PropertyNames.Class, "navbar-brand", PropertyExpressionOperator.Contains);
            }
        }

        protected HtmlDiv CollapseDiv
        {
            get
            {
                return this.Me
                           .Find<HtmlDiv>(HtmlControl.PropertyNames.Class, "navbar-collapse", PropertyExpressionOperator.Contains);
            }
        }

        protected HtmlUnorderedList LeftNavBar
        {
            get
            {
                return this.CollapseDiv
                           .FindAll<HtmlUnorderedList>()
                           .First(x => !x.Class.Contains("navbar-right"));
            }
        }

        protected IEnumerable<HtmlHyperlink> LeftNavBarLinks
        {
            get
            {
                return this.LeftNavBar.FindAll<HtmlHyperlink>();
            }
        }

        protected HtmlHyperlink HomeLink
        {
            get
            {
                return this.LeftNavBar
                           .Find<HtmlHyperlink>(HtmlControl.PropertyNames.InnerText, "Home", PropertyExpressionOperator.EqualTo);

                // also...
                //return this.LeftNavBarLinks.First();
            }
        }

        protected HtmlHyperlink ApiLink
        {
            get
            {
                return this.LeftNavBar
                           .Find<HtmlHyperlink>(HtmlControl.PropertyNames.InnerText, "Api", PropertyExpressionOperator.EqualTo);

                // also...
                //return this.LeftNavBarLinks.Skip(1).First();
            }
        }

        protected HtmlUnorderedList RightNavBar
        {
            get
            {
                return this.CollapseDiv
                           .Find<HtmlUnorderedList>(HtmlControl.PropertyNames.Class, "navbar-right", PropertyExpressionOperator.Contains);
            }
        }

        protected IEnumerable<HtmlHyperlink> RightNavBarLinks
        {
            get
            {
                return this.RightNavBar.FindAll<HtmlHyperlink>();
            }
        }

        protected HtmlHyperlink LoginLink
        {
            get
            {
                return this.RightNavBar.Find<HtmlHyperlink>("loginLink");

                // also...
                //return this.RightNavBarLinks.Skip(1).First();
            }
        }

        protected HtmlHyperlink LogOffLink
        {
            get
            {
                return this.RightNavBar
                           .Find<HtmlHyperlink>(HtmlControl.PropertyNames.InnerText, "Log off", PropertyExpressionOperator.EqualTo);

                // also...
                //return this.RightNavBarLinks.Skip(1).First();
            }
        }

        public LoginPageModel LoginOrLogoff()
        {
            Mouse.Click(this.RightNavBarLinks.Last());
            return new LoginPageModel(this.parent);
        }
    }

    public class LoggedOffNavigationStripModel : NavigationStripBaseModel
    {
        public LoggedOffNavigationStripModel(BrowserWindow bw) : base(bw) { }        

        protected HtmlHyperlink RegisterLink
        {
            get
            {
                return this.RightNavBar.Find<HtmlHyperlink>("registerLink");
            }
        }

        public RegisterPageModel ClickRegisterLink()
        {
            Mouse.Click(this.RegisterLink);
            return new RegisterPageModel(this.parent);
        }

        public LoginPageModel ClickLoginLink()
        {
            Mouse.Click(this.LoginLink);
            return new LoginPageModel(this.parent);
        }
    }

    public class LoggedOnNavigationStripModel : NavigationStripBaseModel
    {
        public LoggedOnNavigationStripModel(BrowserWindow bw) : base(bw) { }

        protected HtmlHyperlink ManageUserLink
        {
            get
            {
                return this.RightNavBar.Find<HtmlHyperlink>(HtmlControl.PropertyNames.Title, "Manage", PropertyExpressionOperator.EqualTo);

                // also...
                //return this.RightNavBarLinks.First();
            }
        }

        public IPageModel ClickManageUserLink()
        {
            Mouse.Click(this.ManageUserLink);
            throw new System.NotImplementedException();
        }

        public LoginPageModel ClickLogOffLink()
        {
            Mouse.Click(this.LogOffLink);
            return new LoginPageModel(this.parent);
        }
    }
}