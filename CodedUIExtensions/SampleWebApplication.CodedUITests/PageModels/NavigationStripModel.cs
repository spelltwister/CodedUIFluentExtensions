using CodedUIAdditionalControls.Html;
using CodedUIPageModeling;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System.Collections.Generic;
using System.Linq;

namespace SampleWebApplication.CodedUITests.PageModels
{
    public class NavigationStripBaseModel : HtmlPageModelBase<HtmlDiv>
    {
        public NavigationStripBaseModel(BrowserWindow bw) : base(bw) { }
        protected override HtmlDiv Me
        {
            get
            {
                HtmlDiv ret = new HtmlDiv(this.DocumentWindow);
                ret.SearchProperties.Add(HtmlControl.PropertyNames.Class, "navbar", PropertyExpressionOperator.Contains);
                return ret;
            }
        }

        protected HtmlHyperlink ApplicationNameLink
        {
            get
            {
                HtmlHyperlink link = new HtmlHyperlink(this.Me);
                link.SearchProperties.Add(HtmlControl.PropertyNames.Class, "navbar-brand", PropertyExpressionOperator.Contains);
                return link;
            }
        }

        protected HtmlDiv CollapseDiv
        {
            get
            {
                HtmlDiv ret = new HtmlDiv(this.Me);
                ret.SearchProperties.Add(HtmlControl.PropertyNames.Class, "navbar-collapse", PropertyExpressionOperator.Contains);
                return ret;
            }
        }

        protected HtmlUnorderedList LeftNavBar
        {
            get
            {
                HtmlUnorderedList leftLinks = new HtmlUnorderedList(this.CollapseDiv);
                return leftLinks.FindMatchingControls()
                                .OfType<HtmlUnorderedList>()
                                .First(x => !x.Class.Contains("navbar-right"));
            }
        }

        protected IEnumerable<HtmlHyperlink> LeftNavBarLinks
        {
            get
            {
                return new HtmlHyperlink(this.LeftNavBar).FindMatchingControls()
                                                         .OfType<HtmlHyperlink>();
            }
        }

        protected HtmlHyperlink HomeLink
        {
            get
            {
                HtmlHyperlink ret = new HtmlHyperlink(this.LeftNavBar);
                ret.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, "Home", PropertyExpressionOperator.EqualTo);
                return ret;

                // also...
                //return this.LeftNavBarLinks.First();
            }
        }

        protected HtmlHyperlink ApiLink
        {
            get
            {
                HtmlHyperlink ret = new HtmlHyperlink(this.LeftNavBar);
                ret.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, "Api", PropertyExpressionOperator.EqualTo);
                return ret;

                // also...
                //return this.LeftNavBarLinks.Skip(1).First();
            }
        }

        protected HtmlUnorderedList RightNavBar
        {
            get
            {
                HtmlUnorderedList right = new HtmlUnorderedList(this.CollapseDiv);
                right.SearchProperties.Add(HtmlControl.PropertyNames.Class, "navbar-right", PropertyExpressionOperator.Contains);
                return right;
            }
        }

        protected IEnumerable<HtmlHyperlink> RightNavBarLinks
        {
            get
            {
                return new HtmlHyperlink(this.RightNavBar).FindMatchingControls()
                                                          .OfType<HtmlHyperlink>();
            }
        }

        protected HtmlHyperlink LoginLink
        {
            get
            {
                HtmlHyperlink loginLink = new HtmlHyperlink(this.RightNavBar);
                loginLink.SearchProperties.Add(HtmlControl.PropertyNames.Id, "loginLink", PropertyExpressionOperator.EqualTo);
                return loginLink;

                // also...
                //return this.RightNavBarLinks.Skip(1).First();
            }
        }

        protected HtmlHyperlink LogOffLink
        {
            get
            {
                HtmlHyperlink logOff = new HtmlHyperlink(this.RightNavBar);
                logOff.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, "Log off", PropertyExpressionOperator.EqualTo);
                return logOff;

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
                HtmlHyperlink registerLink = new HtmlHyperlink(this.RightNavBar);
                registerLink.SearchProperties.Add(HtmlControl.PropertyNames.Id, "registerLink", PropertyExpressionOperator.EqualTo);
                return registerLink;
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
                HtmlHyperlink manageLink = new HtmlHyperlink(this.RightNavBar);
                manageLink.SearchProperties.Add(HtmlControl.PropertyNames.Title, "Manage", PropertyExpressionOperator.EqualTo);
                return manageLink;

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