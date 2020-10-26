using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.WebElements {
    public class AddSchemaDropMenu : WebElement {
        public AddSchemaDropMenu(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
        List<A> menuItems;
        public List<A> MenuItems {
            get {
                if (menuItems == null) {
                    menuItems = Element.FindElements(By.CssSelector("a.x-menu-item"))
                        .Select(we => we.ToLinkMapper(Page)).ToList();
                }
                return menuItems;
            }
        }
    }
}
