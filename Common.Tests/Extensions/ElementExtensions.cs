using Common.Tests.WebElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests {
    public static class ElementExtensions {
        const int TIMEOUT = 240;
        public static List<IWebElement> WaitUntilElementsVisible(this WebElement element, By elementLocator, int timeout = TIMEOUT) {
            return element.Page.Driver.waitUntilElement(elementLocator, timeout, wait => {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(elementLocator)).ToList();
            });
        }
        public static IWebElement WaitUntilElementExists(this WebElement element, By elementLocator, int timeout = TIMEOUT) {            
            return element.Page.Driver.waitUntilElement(elementLocator, timeout, wait => wait.Until(d => element.FindElement(elementLocator)));
        }
        public static IWebElement WaitUntilElementExistsAndVisible(this WebElement element, By elementLocator, int timeout = TIMEOUT) {
            return element.Page.Driver.waitUntilElement(elementLocator, timeout, wait => {
                wait.Until(d => element.FindElement(elementLocator).Enabled);
                wait.Until(d => element.FindElement(elementLocator).Displayed);
                return wait.Until(d => element.FindElement(elementLocator));
            });
        }
        private static T waitUntilElement<T>(this IWebDriver driver, By elementLocator, int timeout, Func<WebDriverWait, T> setup) {
            try {
                return setup(new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)));
            } catch (NoSuchElementException) {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
    }
}
