using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.WebElements {
    public class VisaMessageBox : WebElement {
        public VisaMessageBox(BasePage page, Func<IWebElement> getElement) : base(page, getElement) {
        }
        public WebElement ButtonOk {
            get {
                return WebElementExtensions.ToWebElement(() => this.WaitUntilElementExistsAndVisible(By.ClassName("t-btn-style-blue")), Page);
                }
        }
        public WebElement ButtonCancel {
            get {
                return WebElementExtensions.ToWebElement(() => this.WaitUntilElementExistsAndVisible(By.ClassName("t-btn-style-default")), Page);
            }
        }
    }
}
