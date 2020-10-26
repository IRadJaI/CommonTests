using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace Common.Tests.WebElements {
    public class SchemaPropertiesControlItem : WebElement {
        public SchemaPropertiesControlItem(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
        public WebElement Label { get {
                return WebElementExtensions.ToWebElement(() => this.WaitUntilElementExistsAndVisible(By.TagName("label")), Page);
            }
        }
        public WebElement Input {
            get {
                return WebElementExtensions.ToWebElement(() => FindElements(By.TagName("input"))
                    .Single(wi => wi.GetAttribute("type").Equals("text")), Page);
            }
        }
    }
}
