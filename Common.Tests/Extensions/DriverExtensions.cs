using Common.Tests.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics.Contracts;
using System.Threading;

namespace Common.Tests {
    public static class DriverExtensions {
        const int TIMEOUT = 240;
        const int INTERVAL = 100;
        public static object ExecuteJavaScript(this IWebDriver driver, string javaScript, params object[] args) {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            return javaScriptExecutor.ExecuteScript(javaScript, args);
        }
        public static void WaitForReady(this IWebDriver driver) {
            Contract.Assume(driver != null);
            Func<bool> ready = new Func<bool>(() => (bool)driver.ExecuteJavaScript("return document.readyState == 'complete'"));
            Contract.Assert(Executor.SpinWait(ready, TimeSpan.FromSeconds(TIMEOUT), TimeSpan.FromMilliseconds(INTERVAL)));
        }

        public static void WaitAjax(this IWebDriver driver) {
            Func<bool> ready = new Func<bool>(() => (bool)driver.ExecuteJavaScript("return (typeof($) === 'undefined') ? true : !$.active;"));
            Contract.Assert(Executor.SpinWait(ready, TimeSpan.FromSeconds(TIMEOUT), TimeSpan.FromMilliseconds(INTERVAL)));
        }
    }
}
