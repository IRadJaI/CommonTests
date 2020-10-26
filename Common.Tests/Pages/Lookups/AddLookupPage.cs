using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.Pages {
    public class AddLookupPage : BasePage {
        public AddLookupPage(IWebDriver driver) : base(driver, pageIndicator: By.Id("centerPanelContainer"), realyReload: false) { }
        public WebElement NameInput {
            get {
                return TryGetElement(By.Id("LookupEditPageNameTextEdit-el"));
            }
        }
        public ControlDropSelect SelectObject {
            get {
                return TryGetElement(By.Id("LookupEditPageSysEntitySchemaLookupEdit-wrap"))
                    .ToControlDropSelect();
            }
        }
    }
}
