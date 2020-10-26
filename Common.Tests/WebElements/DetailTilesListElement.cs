using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.WebElements {
    public static partial class WebElementExtensions {
        public static DetailTilesListElement ToDetailTiles(this WebElement element) {
            return new DetailTilesListElement(element.Page, () => element.Element);
        }
        public static DetailTilesListElement ToDetailTiles(this IWebElement element, BasePage page) {
            return new DetailTilesListElement(page, () => element);
        }
    }
    public class DetailTilesListElement : WebElement {
        public DetailTilesListElement(BasePage page, Func<IWebElement> getElement) : base(page, getElement) {
        }

        public WebElement Items {
            get {
                return new WebElement(Page, () => Element.FindElement(By.CssSelector(".grid-row div")));
            }
        }
    }
}
