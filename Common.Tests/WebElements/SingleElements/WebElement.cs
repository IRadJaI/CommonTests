using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace Common.Tests.WebElements {
    public static partial class WebElementExtensions {
        public static WebElement GetChild(this WebElement parent, By locator) {
            return new WebElement(parent.Page, () => parent.WaitUntilElementExistsAndVisible(locator));
        }
        public static WebElement ToWebElement(Func<IWebElement> getElement, BasePage page) {
            return new WebElement(page, getElement);
        }
    }
    public class ListElement<T> : List<T> where T : WebElement { }
    public class WebElement : TestProperies, IWebElement {
        public Func<IWebElement> getElement;
        IWebElement element;
        public BasePage Page;
        [SkipElement]
        public IWebElement Element {
            get{
                Page.TestUrl();
                if(element == null) {
                    element = getElement();
                }
                return element;
            }
        }
        public WebElement(BasePage page, Func<IWebElement> getElement, bool checkExistsElement = true) : base(checkExistsElement) {
            Page = page;
            this.getElement = getElement;
            testElements();
        }
        [SkipElement]
        public bool Exist {
            get {
                Page.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                try {
                    if (Element.Displayed) {
                        return true;
                    } else {
                        return true;
                    }
                } catch {
                    return false;
                }
            }
        }
        [SkipElement]
        public string TagName => Element.TagName;

        [SkipElement]
        public string Text => Element.Text;

        [SkipElement]
        public bool Enabled => Element.Enabled;

        [SkipElement]
        public bool Selected => Element.Selected;

        [SkipElement]
        public Point Location => Element.Location;

        [SkipElement]
        public Size Size => Element.Size;

        [SkipElement]
        public bool Displayed => Element.Displayed;

        public void Clear() {
            Element.Clear();
        }

        public void Click() {
            Executor.SpinWait(() => {
                try {
                    Element.Click();
                    return true;
                }catch(ElementNotInteractableException) {
                    return false;
                }
            }, timeout: TimeSpan.FromSeconds(30));
        }

        public IWebElement FindElement(By by) {
#warning подумать            //return Element.FindElements(by).Single();
            return Element.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by) {
            return Element.FindElements(by);
        }

        public string GetAttribute(string attributeName) {
            return Element.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName) {
            return Element.GetCssValue(propertyName);
        }

        public string GetProperty(string propertyName) {
            return Element.GetProperty(propertyName);
        }

        public void SendKeys(string text) {
            Element.SendKeys(text);
        }

        public void Submit() {
            Element.Submit();
        }
    }
}
