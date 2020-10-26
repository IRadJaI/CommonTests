using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Tests.Base;
using System.Threading;

namespace Common.Tests.WebElements {
    public static partial class WebElementExtensions {
        public static ControlDropSelect ToControlDropSelect(this WebElement element) {
            return new ControlDropSelect(element.Page, () => element.Element);
        }
        public static ControlDropSelect ToControlDropSelect(this IWebElement element, BasePage page) {
            return new ControlDropSelect(page, () => element);
        }
    }
    public class ControlDropSelect : WebElement, IInput {
        string dataItemMarker;
        public ControlDropSelect(BasePage page, Func<IWebElement> element) : base(page, element) {
            dataItemMarker = Element.GetAttribute("data-item-marker");
            if (string.IsNullOrEmpty(dataItemMarker)) {
                dataItemMarker = Element.FindElement(By.CssSelector("*[data-item-marker]")).GetAttribute("data-item-marker");
            }
        }
        public Input SearchInput {
            get {
                return new Input(Page, () => Element.FindElement(By.ClassName("base-edit-input")));
            }
        }
        [SkipElement]
        public WebElement ListView {
            get {
                return WebElementExtensions.ToWebElement(() => Page.Driver.FindElement(By.CssSelector($".listview[data-item-marker='{dataItemMarker}']")), Page);
            }
        }
        [SkipElement]
        public List<WebElement> List {
            get {
                return ListView.FindElements(By.CssSelector($"ul>li"))
                    .Select(iw => WebElementExtensions.ToWebElement(() => iw, Page))
                    .ToList();
            }
        }
        [SkipElement]
        public string Value {
            get {
                return SearchInput.Value;
            }
            set {
                Select(value);
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
        public void Select(string option/*, int iteration = 4*/) {
            /*
            if (iteration == 0) {
                throw new Exception($"Select dont sucess {option}");
            }*/
            SearchInput.Click();
            Executor.SpinWait(() => SearchInput.Focus);
            SearchInput.Value = option;
            Page.Driver.WaitForReady();
            Page.Driver.WaitAjax();/*
            if (List.Where(o => o.Text == option).Count() == 0) {
                Select(option, iteration - 1);
                return;
            }*/
            Executor.SpinWait(() => {
                try {
                    List.Single(o => o.Text == option).Click();
                    return true;
                } catch {
                    return false;
                }
            });
        }
    }
}
