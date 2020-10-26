using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.WebElements {
    public static partial class WebElementExtensions {
        public static InformationDialog ToInformationDialog(this WebElement element) {
            return new InformationDialog(element.Page, () => element.Element);
        }
        public static InformationDialog ToInformationDialog(this IWebElement element, BasePage page) {
            return new InformationDialog(page, () => element);
        }
    }
    public class InformationDialog : WebElement {
        public InformationDialog(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
        public WebElement Message { get {
                return WebElementExtensions.ToWebElement(() => Element.FindElement(By.ClassName("ext-mb-text")), Page);
            } 
        }
    }
}
