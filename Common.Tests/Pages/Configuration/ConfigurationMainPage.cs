using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.Pages {
    public class ConfigurationMainPage : BasePage {
        public ConfigurationMainPage(IWebDriver driver) : base(driver, pageIndicator: By.Id("Workspace")) { }
        List<WebElement> packageList;
        public List<WebElement> PackagesList { 
            get {
                if(packageList == null) {
                    packageList = TryGetElement(By.Id("Packages"))
                        .FindElements(By.ClassName("x-treegrid-row"))
                        .Select(iw => new WebElement(this, () => iw)).ToList();
                }
                return packageList;
            }
        }

        List<WebElement> schemas;
        public List<WebElement> Schemas {
            get {
                if(schemas == null) {
                    schemas = TryGetElement(By.Id("SchemaGrid"))
                        .FindElements(By.ClassName("x-treegrid-row"))
                        .Select(iw => new WebElement(this, () => iw)).ToList();
                }
                return schemas;
            }
        }

        public WebElement AddSchema {
            get {
                return WebElementExtensions.ToWebElement(() => TryGetElement(By.Id("AddSchema")), this);
            }
        }
        AddSchemaDropMenu addSchemaDropMenu;
        [SkipElement]
        public AddSchemaDropMenu AddSchemaDropMenu {
            get {
                if (addSchemaDropMenu == null) {
                    addSchemaDropMenu = new AddSchemaDropMenu(this, () => TryGetElement(By.CssSelector(".x-menu[data-item-marker^=AddSchema]")));
                }
                return addSchemaDropMenu;
            }
        }
    }
}
