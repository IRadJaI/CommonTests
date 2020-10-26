using Common.Tests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.WebElements {
    public class NotificationCenterTab : WebElement {
        public NotificationCenterTab(BasePage page, Func<IWebElement> getElement) : base(page, getElement) {
        }
        [SkipElement]
        public List<EsnNotificationMessageListElement> EsnNotificationMessages {
            get {
                return Page.Driver.FindElements(By.CssSelector("#ESNNotificationSchemaNotificationsContainerContainerList .notification-container"))
                    .Select(element => new EsnNotificationMessageListElement(Page, () => element)).ToList();
            }
        }
        [SkipElement]
        public List<VisaListElement> VisaMessages {
            get {
                return Page.Driver.FindElements(By.CssSelector("#VisaNotificationsSchemaNotificationsContainerContainerList .notification-container"))
                    .Select(element => new VisaListElement(Page, () => element)).ToList();
            }
        }
        [SkipElement]
        public List<SystemListElement> SystemMessages {
            get {
                return Page.Driver.FindElements(By.CssSelector("#SystemNotificationsSchemaNotificationsContainerContainerList .notification-container"))
                    .Select(element => new SystemListElement(Page, () => element)).ToList();
            }
        }
        [SkipElement]
        public WebElement EsnNotificationCount {
            get {
                return WebElementExtensions.ToWebElement(() => this.WaitUntilElementExistsAndVisible(By.CssSelector("#CenterNotificationSchemaImageTabPanelImageTabPanel-tabpanel-items>li[data-item-marker^=Esn]>span")), Page);
            }
        }
        [SkipElement]
        public WebElement ReminderTab {
            get {
                return WebElementExtensions.ToWebElement(() => this.WaitUntilElementExistsAndVisible(By.CssSelector("#CenterNotificationSchemaImageTabPanelImageTabPanel-tabpanel-items>li[data-item-marker^=Reminder]")), Page);
            }
        }
        [SkipElement]
        public WebElement EsnTab {
            get {
                return WebElementExtensions.ToWebElement(() => this.WaitUntilElementExistsAndVisible(By.CssSelector("#CenterNotificationSchemaImageTabPanelImageTabPanel-tabpanel-items>li[data-item-marker^=Esn]")), Page);
            }
        }
        [SkipElement]
        public WebElement VisaTab {
            get {
                return WebElementExtensions.ToWebElement(() => this.WaitUntilElementExistsAndVisible(By.CssSelector("#CenterNotificationSchemaImageTabPanelImageTabPanel-tabpanel-items>li[data-item-marker^=Visa]")), Page);
            }
        }
        [SkipElement]
        public WebElement SystemTab {
            get {
                return WebElementExtensions.ToWebElement(() => this.WaitUntilElementExistsAndVisible(By.CssSelector("#CenterNotificationSchemaImageTabPanelImageTabPanel-tabpanel-items>li[data-item-marker^=System]")), Page);
            }
        }
    }

}
