using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.WebElements {
    public class ContentTileElement : WebElement {
        public ContentTileElement(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
        WebElement caption;
        public WebElement Caption { get { 
                if(caption == null) {
                    caption = WebElementExtensions.ToWebElement(() => this.WaitUntilElementExistsAndVisible(By.ClassName("tile-caption")), Page);
                }
                return caption;
            } 
        }
        List<WebElement> items;
        public List<WebElement> Items {
            get {
                if(items == null) {
                    items = Element
                        .FindElement(By.ClassName("items-container"))
                        .FindElements(By.TagName("a"))
                        .Select(iw => new WebElement(Page, () => iw)).ToList();
                }
                return items;
            }
        }
    }
}
