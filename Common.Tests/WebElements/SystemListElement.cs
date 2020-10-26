using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.WebElements {
    public class SystemListElement : WebElement {
       public WebElement SystemName {
            get {
                return new WebElement(Page, () => Element.FindElement(By.CssSelector("[data-item-marker^=NotificationSubjectCaption]")));
            }
        }
        public SystemListElement(BasePage page, Func<IWebElement> getElement) :base(page, getElement) {
        }
    }

}
