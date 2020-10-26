using Common.Tests.Base;
using OpenQA.Selenium;
using System;

namespace Common.Tests.WebElements {
    public class CustomFilterItem : WebElement {
        public CustomFilterItem(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
        public WebElement DeleteIvoiceFilterButton {
            get {
                return WebElementExtensions.ToWebElement(
                    () => Element.FindElement(By.ClassName("filter-remove-button")), Page);
            }
        }
    }
}
