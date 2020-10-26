using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.WebElements {
    public static partial class WebElementExtensions {
        public static Input ToInput(this WebElement element) {
            return new Input(element.Page, () => element.Element);
        }
    }
    public class Input : WebElement, IInput {
        public Input(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
        [SkipElement]
        public string Value {
            get {
                return GetAttribute("value");
            }
            set {
                Type(value);
            }
        }
        [SkipElement]
        public bool Focus {
            get {
                bool isWebElement = true;
                IWebElement currentElement = Element;
                while (isWebElement) {
                    try {
                        currentElement = ((WebElement)currentElement).Element;
                    } catch {
                        isWebElement = false;
                    }
                }
                return Page.Driver.SwitchTo().ActiveElement().Equals(currentElement);
            }
        }
        public void Type(string typeString) {
            Click();
            Executor.SpinWait(() => Focus);
            Clear();
            SendKeys(typeString);
            Executor.SpinWait(() => Value.Equals(typeString));
        }
    }
}
