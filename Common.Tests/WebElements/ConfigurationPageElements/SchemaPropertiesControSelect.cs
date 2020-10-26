using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Tests.WebElements {
    public class SchemaPropertiesControSelect : SchemaPropertiesControlItem {
        public SchemaPropertiesControSelect(BasePage page, Func<IWebElement> getElement) : base(page, getElement) { }
        [SkipElement]
        public List<WebElement> Options {
            get {
                return Page.Driver.FindElements(By.ClassName("x-combo-list-item"))
                    .Select(iw => WebElementExtensions.ToWebElement(() => iw, Page)).ToList();
            }
        }
        public void Select(string option, int iteration = 4) {
            if (iteration == 0) {
                throw new Exception($"Select dont sucess {option}");
            }
            Input.Click();
            Thread.Sleep(1000);
            Input.Clear();
            Page.Driver.WaitForReady();
            Page.Driver.WaitAjax();
            Input.SendKeys(option);
            Page.Driver.WaitForReady();
            Page.Driver.WaitAjax();
            if (Options.Where(o => o.Text == option).Count() == 0) {
                Select(option, iteration-1);
                return;
            }
            Options.Single(o => o.Text == option).Click();
        }
    }
}
