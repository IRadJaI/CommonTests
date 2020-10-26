using Common.Tests.Base;
using OpenQA.Selenium;
using System;

namespace Common.Tests.WebElements {
    public static partial class WebElementExtensions {
        public static A ToLinkMapper(this WebElement element) {
            return new A(element.Page, () => element.Element);
        }
        public static A ToLinkMapper(this IWebElement element, BasePage page) {
            return new A(page, () => element);
        }
    }
    public class A : WebElement {
        const string HREF_ATTRIBUTE_NAME = "href";
        public A(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
        [SkipElement]
        public string Href {
            get {
                return Element.GetAttribute(HREF_ATTRIBUTE_NAME);
            }
        }
    }
}
