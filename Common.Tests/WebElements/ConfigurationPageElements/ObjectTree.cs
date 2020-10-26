using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.WebElements {
    public static partial class WebElementExtensions {
        public static TreeChildNode ToTreeChildNode(this WebElement element) {
            return new TreeChildNode(element.Page, () => element.Element);
        }
        public static TreeChildNode ToTreeChildNode(this IWebElement element, BasePage page) {
            return new TreeChildNode(page, () => element);
        }
        public static TreeChildNodes ToTreeChildNodes(this WebElement element) {
            return new TreeChildNodes(element.Page, () => element.Element);
        }
        public static TreeChildNodes ToTreeChildNodes(this IWebElement element, BasePage page) {
            return new TreeChildNodes(page, () => element);
        }
        public static ObjectTree ToObjectTree(this WebElement element) {
            return new ObjectTree(element.Page, () => element.Element);
        }
        public static ObjectTree ToObjectTree(this IWebElement element, BasePage page) {
            return new ObjectTree(page, () => element);
        }
    }
    public class ObjectTree : WebElement {
        public ObjectTree(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
        public WebElement Root {
            get {
                return WebElementExtensions.ToWebElement(() => this.WaitUntilElementExistsAndVisible(By.CssSelector(".x-treegrid-row-table")), Page);
            }
        }
        public TreeChildNodes ChildList {
            get {
                return this.WaitUntilElementExistsAndVisible(By.CssSelector(".x-tree-node-ct"))
                    .ToTreeChildNodes(Page);
            }
        }
    }
    public class TreeChildNodes : WebElement {
        public TreeChildNodes(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
        public TreeChildNode Columns {
            get {
                return Element.FindElements(By.ClassName("x-tree-node-el"))
                    .Single(iw => iw.Text == "Columns").ToTreeChildNode(Page);
            }
        }
    }
    public class TreeChildNode : WebElement {
        public TreeChildNode(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
        [SkipElement]
        public WebElement PlusIcon {
            get {
                WebElement icon = WebElementExtensions.ToWebElement(() => Element.FindElement(By.ClassName("x-tree-elbow-plus")), Page);
                if (icon.Exist) {
                    return icon;
                } else {
                    return null;
                }
            }
        }
    }
}
