using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.WebElements {
    public static partial class WebElementExtensions {
        public static SchemaProperties ToSchemaProperties(this WebElement element) {
            return new SchemaProperties(element.Page, () => element.Element);
        }
        public static SchemaProperties ToSchemaProperties(this IWebElement element, BasePage page) {
            return new SchemaProperties(page, () => element);
        }
    }
    public class SchemaProperties : WebElement {
        public SchemaProperties(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
        public WebElement InheritanceGroup {
            get {
                return this.GetChild(By.Id("Inheritance_group"));
            }
        }
        public WebElement GeneralGroup {
            get {
                return this.GetChild(By.Id("General_group"));
            }
        }
        public SchemaPropertiesControlItem Name {
            get {
                return new SchemaPropertiesControlItem(Page, () => GeneralGroup.FindElements(By.ClassName("x-control-layout-item"))
                    .Single(p => p.Text.Contains("Название")));
            }
        }
        public SchemaPropertiesControlItem Title {
            get {
                return new SchemaPropertiesControlItem(Page, () => GeneralGroup.FindElements(By.ClassName("x-control-layout-item"))
                    .Single(p => p.Text.Contains("Заголовок")));
            }
        }
        public SchemaPropertiesControSelect Inheritance {
            get {
                return new SchemaPropertiesControSelect(Page, () => InheritanceGroup.FindElements(By.ClassName("x-control-layout-item"))
                    .Single(p => p.Text.Contains("Родительский объект")));
            }
        }
    }
}
