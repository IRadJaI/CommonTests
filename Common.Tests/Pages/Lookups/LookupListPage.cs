using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.Pages {
    public class LookupListPage : BasePage {
        public LookupListPage(IWebDriver driver) : base(driver, pageIndicator: By.Id("centerPanelContainer")) { 
        }
        public WebElement AddLookup {
            get {
                return TryGetElement(By.ClassName("t-btn-style-green"));
            }
        }
    }
}
