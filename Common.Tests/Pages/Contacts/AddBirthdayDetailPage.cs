using Common.Tests.Base;
using Common.Tests.WebElements;
using OpenQA.Selenium;

namespace Common.Tests.Pages.Contacts
{
    public class AddBirthdayDetailPage : BPMInternalBasePage
    {
        internal AddBirthdayDetailPage(IWebDriver driver) : base(driver)
        {

        }
        internal WebElement SaveButton
        {
            get
            {
                return TryGetElement(By.Id("ContactAnniversaryPageV2SaveButtonButton-textEl"));
            }
        }
        internal WebElement BirthdayField
        {
            get
            {
                return TryGetElement(By.Id("ContactAnniversaryPageV2DateDateEdit-el"));
            }
        }
        internal void Close()
        {

        }
    }
}