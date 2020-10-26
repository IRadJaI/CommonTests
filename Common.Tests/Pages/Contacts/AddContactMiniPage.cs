using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Tests.Pages.Contacts {
    public class AddContactMiniPage : BPMInternalBasePage {
        public string ContactName;
        const string CONTACT_TYPE = "Бывший сотрудник";
        public AddContactMiniPage(IWebDriver driver) : base(driver) {
        }
        public void DataFilling() {
            ContactName = "Тестовый Тест Теста";
            AddNameInput.SendKeys(ContactName);
            Driver.WaitForReady();
            AddTypeInput.Select(CONTACT_TYPE);
            SaveButton.Click();
            Executor.SpinWait(() => !MiniPageOverlay.Exist, TimeSpan.FromMinutes(4), TimeSpan.FromMilliseconds(200));
        }
        public WebElement SaveButton {
            get {
                return TryGetElement(By.Id("ContactMiniPageSaveEditButtonButton-textEl"));
            }
        }
        public WebElement GoToFullCardButton {
            get {
                return TryGetElement(By.Id("ContactMiniPageOpenCurrentEntityPageButton-imageEl"));
            }
        }
        public WebElement AddNameInput {
            get {
                return TryGetElement(By.Id("ContactMiniPageNameTextEdit-el"));
            }
        }
        public ControlDropSelect AddTypeInput {
            get {
                return TryGetElement(By.Id("ContactMiniPageTypeComboBoxEdit-wrap")).ToControlDropSelect();
            }
        }
        [SkipElement]
        public List<WebElement> ContactTypeElements {
            get {
                return TryGetElements(By.CssSelector(".listview>ul>li"));
            }
        }
        [SkipElement]
        public WebElement MiniPageOverlay {
            get {
                return WebElementExtensions.ToWebElement(() => Driver.FindElements(By.Id("AlignableMiniPageContainer-overlay")).Single(), this);
            }
        }
    }
}
