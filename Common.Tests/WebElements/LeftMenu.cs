using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.WebElements {
    public class LeftMenu : WebElement {
        public LeftMenu(BasePage page, Func<IWebElement> getRoot) : base(page, getRoot) { }
        [SkipElement]
        public List<WebElement> MenuItems {
            get {
                return this.WaitUntilElementExistsAndVisible(By.ClassName("ts-sidebar-list"))
                    .FindElements(By.TagName("li")).Where(mi => mi.Displayed)
                    .Select(iw => WebElementExtensions.ToWebElement(() => iw, Page)).ToList();
            }
        }
        public WebElement GetLeftMenuItem(string text) {
            long maxScroll = (long)Page.Driver.ExecuteJavaScript("return document.getElementById('leftPanelContent').scrollHeight");
            long steepScroll = (long)Page.Driver.ExecuteJavaScript("return document.getElementById('leftPanelContent').clientHeight");
            long scrollIterator = 0;
            while (MenuItems.Where(mi => mi.Text == text).ToList().Count == 0 && scrollIterator <= maxScroll) {
                scrollIterator += steepScroll;
                Page.Driver.ExecuteJavaScript($"document.getElementById('leftPanelContent').scrollTop = {scrollIterator}");
            }
            return WebElementExtensions.ToWebElement(() => MenuItems.Single(mi => mi.Text == text), Page);
        }
    }

}
