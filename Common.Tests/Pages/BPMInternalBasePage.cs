using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;

namespace Common.Tests.Pages {
    public class BPMInternalBasePage : BasePage {
        [SkipElement]
        public WebElement MyProfile {
            get {
                return TryGetElement(By.Id("profile-user-button-wrapperEl"));
            }
        }
        [SkipElement]
        public WebElement Logout { 
            get { 
                return TryGetElement(By.Id("exit-menu-item")); 
            } 
        }
        [SkipElement]
        public CommunicationPanel CommunicationPanel {
            get {
                return new CommunicationPanel(this, () => TryGetElement(By.XPath(".")));
            }
        }
        public LeftMenu LeftMenu {
            get {
                return new LeftMenu(this, () => TryGetElement(By.Id("leftPanelContent")));
            }
        }
        [SkipElement]
        public VisaMessageBox VisaMessageBox {
            get {
                return new VisaMessageBox(this, () => TryGetElement(By.CssSelector(".ts-messagebox-box.visa-action")));
            }
        }
        public BPMInternalBasePage(IWebDriver driver) : base(driver, pageIndicator: By.Id("centerPanelContainer")) {}
        public void LogoutProcess() {
            MyProfile.Click();
            Logout.Click();
            Driver.WaitForReady();
        }

    }
}
