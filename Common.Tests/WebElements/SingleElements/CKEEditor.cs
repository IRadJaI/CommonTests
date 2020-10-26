using Common.Tests.Base;
using OpenQA.Selenium;
using System;

namespace Common.Tests.WebElements
{
    public class CKEEditor : WebElement, IInput {
        string id { get; set; }
        [SkipElement]
        public WebElement ClickAreaEditor {
            get {
                return WebElementExtensions.ToWebElement(() => this.WaitUntilElementExists(By.Id(string.Format("cke_{0}", id))), Page);
            }
        }
        public CKEEditor(BasePage page, Func<IWebElement> getElement, string id) : base(page, getElement) {
            this.id = id;
        }
        [SkipElement]
        public string Value {
            get {
                IJavaScriptExecutor js = (IJavaScriptExecutor)Page.Driver;
                return js.ExecuteScript($"CKEDITOR.instances['{id}'].getData()").ToString();
            }
            set {
                TypeText(value);
            }
        }
        public void TypeText(string text)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Page.Driver;
            js.ExecuteScript($"CKEDITOR.instances['{id}'].setData('{text}')");
        }
    }
}
