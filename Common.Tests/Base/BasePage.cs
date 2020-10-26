using Common.Tests.WebElements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Tests.Base {
    public class BasePage : TestProperies {
        public IWebDriver Driver;
        string url;
        private readonly bool realyReload;
        WebElement Page {
            get {
                return new WebElement(this, () => Driver.FindElement(By.CssSelector("body")));
            }
        }
        public BasePage(IWebDriver driver, By pageIndicator, bool realyReload = true, bool checkExistsElement = true) : base(checkExistsElement)
        {
            Driver = driver;
            url = Driver.Url;
            Driver.WaitAjax();
            Driver.WaitForReady();
            testElements();
            Executor.SpinWait(() => Page.FindElements(pageIndicator).Count > 0, TimeSpan.FromMinutes(4), TimeSpan.FromMilliseconds(200));
        }
        public void TestUrl() {
            if (realyReload) {
                Executor.SpinWait(() => {
                    try {
                        Assert.AreNotEqual(Driver.Url, url);
                        return true;
                    } catch (Exception) {
                        return false;
                    }
                }, TimeSpan.FromMinutes(4), TimeSpan.FromMilliseconds(200));
            }
        }
        public List<WebElement> TryGetElements(By locator) {
            return Page.FindElements(locator).Select(iw => WebElementExtensions.ToWebElement(() => iw, this)).ToList();
        }
        public WebElement TryGetElement(By locator) {
            WebElement element = WebElementExtensions.ToWebElement(() => Page.FindElement(locator), this);
            Executor.SpinWait(() => element.Exist, TimeSpan.FromMinutes(4), TimeSpan.FromMilliseconds(200));
            return element;
        }
    }
}
