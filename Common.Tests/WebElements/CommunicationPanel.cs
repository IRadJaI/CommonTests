using Common.Tests.Base;
using OpenQA.Selenium;
using System;

namespace Common.Tests.WebElements {
    public class CommunicationPanel : WebElement {
        [SkipElement]
        public NotificationCenterTab NotificationCenterTab {
            get {
                return new NotificationCenterTab(Page, () => this.WaitUntilElementExists(By.Id("CenterNotificationModule_WrapContainer")));
            }
        }
        public CommunicationPanel(BasePage page, Func<IWebElement> getElement) : base(page, getElement, checkExistsElement: false) {

        }
        public void Close() {
            EsnFeedButton.Click();
            Page.Driver.WaitForReady();
            NotificationsButton.Click();
            Page.Driver.WaitForReady();
            NotificationsButton.Click();
            Page.Driver.WaitForReady();
        }
        public void OpenNotificationsPanel() {
            if(!NotificationsButton.GetAttribute("class").Contains("t-btn-pressed")) {
                NotificationsButton.Click();
            }
        }
        public WebElement RightPanel {
            get {
                return WebElementExtensions.ToWebElement(() => this.WaitUntilElementExists(By.Id("rightPanel")), Page);
            }
        }
        public WebElement NotificationsButton {
            get {
                return WebElementExtensions.ToWebElement(() => this.WaitUntilElementExistsAndVisible(By.Id("view-button-centerNotification-wrapperEl")), Page);
            }
        }
        public WebElement EsnFeedButton {
            get {
                return
                    WebElementExtensions.ToWebElement(() => this.WaitUntilElementExistsAndVisible(By.Id("view-button-esnFeed-imageEl")), Page); ;
            }
        }

    }

}
