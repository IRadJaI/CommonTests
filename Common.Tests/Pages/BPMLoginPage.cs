using Common.Tests.Base;
using OpenQA.Selenium;
using Common.Tests.Entity;
using Common.Tests.WebElements;

namespace Common.Tests.Pages
{
    public class BPMLoginPage : BasePage
    {
        public WebElement LoginInput {
            get {
                return WebElementExtensions.ToWebElement(() => TryGetElement(By.Id("loginEdit-el")), this);
            }
        }
        public WebElement PasswordInput {
            get {
                return WebElementExtensions.ToWebElement(() => TryGetElement(By.Id("passwordEdit-el")), this);
            }
        }
        public WebElement EnterButton {
            get {
                return WebElementExtensions.ToWebElement(() => TryGetElement(By.ClassName("login-button-login")), this);
            }
        }
        public BPMLoginPage(IWebDriver driver) : base(driver, pageIndicator: By.Id("IndexForm"), realyReload: false) { }
        public BPMInternalBasePage Login(TestUser user)
        {
            LoginInput.Clear();
            LoginInput.SendKeys(user.Login);
            PasswordInput.Clear();
            PasswordInput.SendKeys(user.Password);
            EnterButton.Click();
            Driver.WaitForReady();
            Driver.WaitAjax();
            return new BPMInternalBasePage(Driver);
        }
    }
}
