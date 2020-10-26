using Common.Tests.Base;
using OpenQA.Selenium;
using System;

namespace Common.Tests.WebElements {
    public class EsnNotificationMessageListElement : WebElement {
        public WebElement SetReadMessage {
            get {
                return WebElementExtensions.ToWebElement(() => Element.FindElement(By.ClassName("message-set-read")), Page);
            }
        }
        public bool IsReadClass {
            get {
                return Element.GetAttribute("class").Contains("read");
            }
        }
        public EsnNotificationMessageListElement(BasePage page, Func<IWebElement> getElement) : base(page, getElement) {
        }
    }

}
