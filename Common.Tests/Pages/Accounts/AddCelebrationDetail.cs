using Common.Tests.Base;
using Common.Tests;
using Common.Tests.WebElements;
using OpenQA.Selenium;

namespace Common.Tests.Pages.Accounts {
    public class AddCelebrationDetail : BPMInternalBasePage {
        public AddCelebrationDetail(IWebDriver driver) : base(driver) {

        }
        public WebElement SaveButton {
            get {
                return TryGetElement(By.Id("AccountAnniversaryPageV2SaveButtonButton-textEl"));
            }
        }
        public Input BirthdayField {
            get {
                return TryGetElement(By.Id("AccountAnniversaryPageV2DateDateEdit-el")).ToInput();
            }
        }
        public void Close() {

        }
    }
}