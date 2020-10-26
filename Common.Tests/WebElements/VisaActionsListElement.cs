using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.WebElements {
    public class VisaActionsListElement : WebElement {
        public List<WebElement> VisaActionItems {
            get {
                return Element.FindElements(By.ClassName("menu-item"))
                    .Select(iw => new WebElement(Page, () => iw))
                    .ToList();
            }
        }
        public VisaActionsListElement(BasePage page, Func<IWebElement> getElement) : base(page, getElement) {
        }
    }
}
